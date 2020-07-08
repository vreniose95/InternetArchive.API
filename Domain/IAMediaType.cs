using System.Runtime.CompilerServices;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace InternetArchive.API.Domain
{
	public readonly struct IAMediaType
	{
		public string MediaTypeKey { get; }

		public string MemberName { get;}

		
		private IAMediaType(
			[NotNull] string mediaTypeKey,
			[CallerMemberName] string memberName = null)
		{
			mediaTypeKey.IsNotNull(nameof(mediaTypeKey));
			memberName.IsNotNull(nameof(memberName));

			MediaTypeKey = mediaTypeKey;
			MemberName = memberName;
		}

		
		/// <summary>
		///	The majority of <see cref="Audio"/> items should receive this mediatype value. Items for
		///	the Live Music Archive should instead use the <see cref="ETree"/> value.
		/// </summary>
		public static readonly IAMediaType Audio = new IAMediaType("audio");

		/// <summary>
		///	Denotes the item as a <see cref="Collection"/> to which other collections and items can
		///	belong.
		/// </summary>
		public static readonly IAMediaType Collection = new IAMediaType("collection");

		/// <summary>
		///	This is the default value for mediatype. Items with a mediatype of <see cref="Data"/> will
		///	be available in Internet Archive but you will not be able to browse to them. In addition
		///	there will be no online reader/player for the files.
		/// </summary>
		public static readonly IAMediaType Data = new IAMediaType("data");

		/// <summary>
		///	Items which contain files for the Live Music Archive should have a mediatype value of
		///	<see cref="ETree"/>. The Live Music Archive has very specific upload requirements. Please
		///	consult the documentation for the Live Music Archive prior to creating items for it.
		/// </summary>
		public static readonly IAMediaType ETree = new IAMediaType("etree");

		/// <summary>
		///	Items which predominantly consist of <see cref="Image"/> files should receive a mediatype
		///	value of image. Currently these items will not be available for browsing or online viewing
		///	in Internet Archive but they will require no additional changes when this mediatype
		///	receives additional support in the Archive.
		/// </summary>
		public static readonly IAMediaType Image = new IAMediaType("image");

		/// <summary>
		///	All videos (television, features, shorts, etc.) should receive a mediatype value of
		///	<see cref="Movies"/>. These items will be displayed with an online video player.
		/// </summary>
		public static readonly IAMediaType Movies = new IAMediaType("movies");

		/// <summary>
		///	Items with a mediatype of <see cref="Software"/> are accessible to browse via Internet
		///	Archive’s software collection. There is no online viewer for software but all files are
		///	available for download.
		/// </summary>
		public static readonly IAMediaType Software = new IAMediaType("software");

		/// <summary>
		///	All text items (PDFs, EPUBs, etc.) should receive a mediatype value of <see cref="Texts"/>.
		/// </summary>
		public static readonly IAMediaType Texts = new IAMediaType("texts");

		/// <summary>
		///	The <see cref="Web"/> mediatype value is reserved for items which contain web archive
		///	WARC files.
		/// </summary>
		public static readonly IAMediaType Web = new IAMediaType("web");
	}
}
