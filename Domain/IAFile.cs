using System;
using Ccr.Std.Core.Extensions;
using InternetArchive.API.Extensions;
using JetBrains.Annotations;

namespace InternetArchive.API.Domain
{
	public class IAFile
	{
		public string FileName { get; }
		
		public IAFileKind FileKind { get; }
		
		public string Title { get; }

		public int IndexWithinItem { get; }
		
		public string FilePathUrl { get; }

		public DateTime LastModifiedDate { get; }
		
		public double ApproximateBytes { get; }

		public IAItem OwnerArchiveItem { get; }



		public IAFile(
			[NotNull] IAItem ownerArchiveItem,
			[NotNull] string fileName,
			[NotNull] IAFileKind fileKind,
			[NotNull] string title,
			DateTime lastModifiedDate,
			double approximateBytes,
			int indexWithinItem,
			bool isThumbnailFile = false)
		{
			ownerArchiveItem.IsNotNull(nameof(ownerArchiveItem));
			fileName.IsNotNull(nameof(fileName));
			fileKind.IsNotNull(nameof(fileKind));
			title.IsNotNull(nameof(title));

			OwnerArchiveItem = ownerArchiveItem;
			FileName = fileName;
			FileKind = fileKind;
			Title = title;
			IndexWithinItem = indexWithinItem;

			if (isThumbnailFile)
				FilePathUrl = $"{ownerArchiveItem.GetItemThumbnailDownloadPageUrl()}{fileName}";
			else
				FilePathUrl = $"{ownerArchiveItem.GetItemDownloadPageUrl()}{fileName}";
			
			LastModifiedDate = lastModifiedDate;
			ApproximateBytes = approximateBytes;
		}
	}
}