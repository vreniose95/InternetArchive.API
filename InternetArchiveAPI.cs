using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ccr.Scraping.API.Common;
using Ccr.Scraping.API.Infrastructure;
using Ccr.Scraping.API.Web;
using InternetArchive.API.Domain;
using InternetArchive.API.Domain.Responses;
using InternetArchive.API.Interpreters;
using InternetArchive.API.Query;
using Newtonsoft.Json;

namespace InternetArchive.API
{
	public class InternetArchiveAPI
		: APIBase<IAItem, IAQueryBuilder>
	{
		private const string _domain = "https://www.archive.org/";
		private const string _uploadDomain = "http://s3.us.archive.org/";

		private DomainFragment _requestBuilder;
		private DomainFragment _uploadRequestBuilder;
		

		protected override DomainFragment RequestBuilder
		{
			get => _requestBuilder ??= new DomainFragment(_domain);
		}

		protected DomainFragment UploadRequestBuilder
		{
			get => _uploadRequestBuilder ??= new DomainFragment(_uploadDomain);
		}

		

		public override IEnumerable<IAItem> Query(
			IAQueryBuilder queryBuilder)
		{
			var url = queryBuilder.BuildRequestUrl(RequestBuilder);

			using var httpClient = new HttpClientWrapper();

			var response = httpClient
				.GetContentAsync(url)
				.GetAwaiter()
				.GetResult();

			var formattedResponse = response;
			if (formattedResponse.StartsWith("callback("))
			{
				formattedResponse = formattedResponse
					.Substring("callback(".Length)
					.TrimEnd(')');
			}

			var archiveResponse = JsonConvert
				.DeserializeObject<RootObject>(
					formattedResponse);

			var archiveItems = archiveResponse
				.Response
				.Docs
				.Select(
					IAItemInterpreter.CreateArchiveItem);

			return archiveItems;
		}

		/// <summary>
		/// TODO this doesn't work yet
		/// </summary>
		/// <param name="collectionID"></param>
		/// <param name="fileInfo"></param>
		/// <returns></returns>
		[Obsolete]
		internal async Task<string> UploadFile(
			string collectionID,
			FileInfo fileInfo)
		{
			var urlBuilder = UploadRequestBuilder
				.Builder
				.WithPath(collectionID)
				.WithPath(fileInfo.Name);

			var url = urlBuilder.Build();

			using var httpClient = new HttpClient();

			using var request = new HttpRequestMessage(
				new HttpMethod("PUT"), url);

			request.Headers.TryAddWithoutValidation("Authorization", "LOW $accesskey:$secret");
			request.Headers.TryAddWithoutValidation("x-amz-auto-make-bucket", "1");
			request.Headers.TryAddWithoutValidation("x-archive-meta01-collection", "opensource_movies");
			request.Headers.TryAddWithoutValidation("x-archive-meta-mediatype", "movies");
			request.Headers.TryAddWithoutValidation("x-archive-meta-sponsor", "");
			request.Headers.TryAddWithoutValidation("x-archive-meta-creator", "");
			request.Headers.TryAddWithoutValidation("x-archive-meta-title", "");
			request.Headers.TryAddWithoutValidation("x-archive-meta-date", "");
			request.Headers.TryAddWithoutValidation("x-archive-meta-year", "");
			request.Headers.TryAddWithoutValidation("x-archive-meta-month", "");
			request.Headers.TryAddWithoutValidation("x-archive-meta-description", "description");
			request.Headers.TryAddWithoutValidation("x-archive-meta-subject", "subject1;subject2");
			request.Headers.TryAddWithoutValidation("x-archive-meta-language", "eng");
			request.Headers.TryAddWithoutValidation("x-archive-meta-licenseurl", "http://creativecommons.org/licenses/by-nc/3.0/us/");


			request.Content = new ByteArrayContent(File.ReadAllBytes("ben-2009-05-09.avi"));

			var response = await httpClient.SendAsync(request);

			return url;
		}
	}
}