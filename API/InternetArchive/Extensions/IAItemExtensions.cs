using System.Collections.Generic;
using System.Linq;
using InternetArchive.API.InternetArchive.Domain;
using InternetArchive.API.InternetArchive.Interpreters;

namespace InternetArchive.API.InternetArchive.Extensions
{
	public static class IAItemExtensions
	{
		public static string GetItemDownloadPageUrl(
			this IAItem @this)
		{
			return $"https://www.archive.org/" +
				$"download/" +
				$"{@this.Identifier}/";
		}

		public static string GetItemThumbnailDownloadPageUrl(
			this IAItem @this)
		{
			return $"https://www.archive.org/" +
				$"download/" +
				$"{@this.Identifier}/" +
				$"{@this.Identifier}.thumbs/";
		}

		public static IReadOnlyList<IAFile> GetItemFiles(
			this IAItem @this)
		{
			return IAFileInterpreter.ScrapeArchiveFiles(@this)
				.ToArray();
		}

		public static IReadOnlyList<IAFile> GetItemThumbnailFiles(
			this IAItem @this)
		{
			return IAFileInterpreter.ScrapeArchiveThumbnailFiles(@this)
				.Where(t => t.FilePathUrl.EndsWith(".jpg"))
				.ToArray();
		}
	}
}