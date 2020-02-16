using System;
using System.IO;
using Ccr.Scraping.API.Infrastructure;

namespace InternetArchive.API.InternetArchive.Uploader
{
	//public class ArchiveUploadAPI
	//{
	//	private const string domainPrefix = "https://www.";
	//	private const string domainName = "youtube";
	//	private const string domainSuffix = ".com";

	//	public static readonly string domain =
	//		$"{domainPrefix}{domainName}{domainSuffix}";


	//	public ArchiveUploadAPI()
	//	{

	//	}
	//}{

	public class EMJArchiveUploadTemplate
	{
		private const string _creator = "Dr. E. Michael Jones";
		private const string _uploadNamePrefix = "Dr. E. Michael Jones Archive - ";
		private const string _archiveIdentifierPrefix = "emj-archive-";
		
		private readonly DirectoryInfo _rootDirectory = new DirectoryInfo(
			@"X:\media\shows\emichaeljones\youtube\videos\renamed formatted videos\");
		private readonly DirectoryInfo _uploadDirectory;

		private readonly string _description;
		private readonly string _subjectTags;


		private const string domainPrefix = "http://";
		private const string domainName = "archive";
		private const string domainSuffix = ".org";

		public static readonly string domain =
			$"{domainPrefix}{domainName}{domainSuffix}";

		private DomainFragment _requestBuilder;
		protected DomainFragment RequestBuilder
		{
			get => _requestBuilder
				?? (_requestBuilder = new DomainFragment(domain));
		}
		

		public DateTime UploadDate { get; }
		
		public int UploadNumber { get; }

		public string Description { get; }// => $"description={_description}".HTMLEncode();
		//Ron%20and%20Fez%20Archive%20-%20April%202003"

		public string Subjects { get; }//=> $"subject={_subjectTags}".HTMLEncode();
																	//&subject=R&F%2C%20Ron%20and%20Fez%2C%20Ron%2C%20Fez%2C%20Comedy%2C%20Radio

		public string Creator { get; }//=> $"creator={_creator}".HTMLEncode();
																	//&creator=Ron%20and%20Fez&date=2004-04

		public string Date { get; }		//=> $"date={UploadDate:yyyy-MM-dd}".HTMLEncode();
																	//&date={AirDate:yyyy-MM}

		public string ArchiveIdentifier { get; }	// => $"{_archiveIdentifierPrefix}-{UploadNumber:000}";

		public string UploadName => $"{_uploadNamePrefix}-{UploadNumber:000}";



		public EMJArchiveUploadTemplate(
			int uploadNumber)
		{
			//if (Description.IsNullOrEmptyEx())
			//		Description.
		//	UploadDate = DateTime.Today;
			 UploadNumber = uploadNumber;

			_uploadDirectory = new DirectoryInfo(
				_rootDirectory.FullName + $@"\{UploadNumber:000}\");


			var descriptionManifestFile = new FileInfo(
				_uploadDirectory.FullName + $@"\{UploadNumber:000}-description-manifest.txt");

			using (var reader = descriptionManifestFile.OpenRead())
			{
				using (var streamReader = new StreamReader(reader))
				{
					Description = streamReader.ReadToEnd();
				}
			}


			var subjectTagManifestFile = new FileInfo(
				_uploadDirectory.FullName + $@"\{UploadNumber:000}-manifest.txt");

			using (var reader = subjectTagManifestFile.OpenRead())
			{
				using (var streamReader = new StreamReader(reader))
				{
					Subjects = streamReader.ReadToEnd();
				}
			}
		}


		public override string ToString()
		{
			var builder = RequestBuilder
				.Builder
				.WithPath("upload")
				.WithParameter("description", Description)
				.WithParameter("subject", Subjects)
				.WithParameter("creator", Creator)
				.WithParameter("date", $"{UploadDate:yyy-MM-dd}")
				.WithParameter("collection", "community video")
				.WithParameter("language", "eng");
			
			return builder.Build();

			//return
			//	$"http://archive.org/" +
			//	$"upload/" +
			//	$"?{Description}" +
			//	$"&{Subject}" +
			//	$"&{Creator}" +
			//	$"&{Date}" +
			//	$"&collection=community_video" +
			//	$"&language=eng";
		}
	}
}
