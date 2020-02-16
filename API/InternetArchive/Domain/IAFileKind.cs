using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace InternetArchive.API.InternetArchive.Domain
{
	public class IAFileKind
	{
		public string Extension { get; }

		public string FileKindKey { get; }



		public static readonly IAFileKind MPEG4 = new IAFileKind("mp4", "MPEG4");

		public static readonly IAFileKind MPEG4_512Kb = new IAFileKind("mp4", "512Kb+MPEG4");

		public static readonly IAFileKind H264 = new IAFileKind("mp4", "h.264");

		public static readonly IAFileKind WAVE = new IAFileKind("wav", "WAVE");

		public static readonly IAFileKind QuickTime = new IAFileKind("mov", "QuickTime");

		public static readonly IAFileKind MP3_160Kbps = new IAFileKind("mp3", "160Kbps+MP3");

		public static readonly IAFileKind MP3_128Kbps = new IAFileKind("mp3", "128Kbps+MP3");

		public static readonly IAFileKind MP3_64Kbps = new IAFileKind("mp3", "64Kbps+MP3");

		public static readonly IAFileKind MP3_56Kbps = new IAFileKind("mp3", "56Kbps+MP3");

		public static readonly IAFileKind MP3_VBR = new IAFileKind("mp3", "VBR+MP3");

		public static readonly IAFileKind JPEG = new IAFileKind("jpeg", "JPEG");

		public static readonly IAFileKind JPEG_Thumb = new IAFileKind("jpeg", "JPEG+Thumb");

		public static readonly IAFileKind Item_Image = new IAFileKind("?", "Item+Image");

		public static readonly IAFileKind Text_PDF = new IAFileKind("pdf", "Text+PDF");


		private IAFileKind(
			[NotNull] string extension,
			[NotNull] string fileKindKey)
		{
			extension.IsNotNull(nameof(extension));
			fileKindKey.IsNotNull(nameof(fileKindKey));

			Extension = extension;
			FileKindKey = fileKindKey;
		}


		public static IAFileKind GetOther(
			[NotNull] string extension)
		{
			extension.IsNotNull(nameof(extension));

			return new IAFileKind(
				extension,
				"Other");
		} 
	}
}