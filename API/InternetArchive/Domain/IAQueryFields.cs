using System;

namespace InternetArchive.API.InternetArchive.Domain
{
	public static class IAQueryFields
	{
		public static readonly IAQueryField<double> AverageRating = new IAQueryField<double>("avg_rating", 0x1);

		public static readonly IAQueryField<string> BackupLocation = new IAQueryField<string>("backup_location", 0x2);

		public static readonly IAQueryField<string> BTIH = new IAQueryField<string>("btih", 0x4);

		public static readonly IAQueryField<string> CallNumber = new IAQueryField<string>("call_number", 0x8);

		public static readonly IAQueryField<string> Collection = new IAQueryField<string>("collection", 0x10);

		public static readonly IAQueryField<string> Contributor = new IAQueryField<string>("contributor", 0x20);

		public static readonly IAQueryField<string> Coverage = new IAQueryField<string>("coverage", 0x40);

		/// <summary>
		/// Author
		/// </summary>
		public static readonly IAQueryField<string> Creator = new IAQueryField<string>("creator", 0x80);

		//range and wildcard
		public static readonly IAQueryField<string> Date = new IAQueryField<string>("date", 0x100);

		/// <summary>
		/// The text description of the item. The field type is a <see cref="string"/>..
		/// </summary>
		public static readonly IAQueryField<string> Description = new IAQueryField<string>("description", 0x200);

		//range and range with one side being NULL for > / <
		public static readonly IAQueryField<int> Downloads = new IAQueryField<int>("downloads", 0x400);

		public static readonly IAQueryField<string> ExternalIdentifier = new IAQueryField<string>("external-identifier", 0x800);

		public static readonly IAQueryField<int> FoldoutCount = new IAQueryField<int>("foldoutcount", 0x1000);

		public static readonly IAQueryField<string> Format = new IAQueryField<string>("format", 0x2000);

		public static readonly IAQueryField<string> Genre = new IAQueryField<string>("genre", 0x4000);

		public static readonly IAQueryField<string> HeaderImage = new IAQueryField<string>("headerImage", 0x8000);

		/// <summary>
		/// The identifier of the item. The field type is a <see cref="string"/>..
		/// </summary>
		public static readonly IAQueryField<string> Identifier = new IAQueryField<string>("identifier", 0x10000);

		public static readonly IAQueryField<int> ImageCount = new IAQueryField<int>("imagecount", 0x20000);

		public static readonly IAQueryField<string> IndexFlag = new IAQueryField<string>("indexflag", 0x40000);

		public static readonly IAQueryField<long> ItemSize = new IAQueryField<long>("item_size", 0x80000);

		public static readonly IAQueryField<string> Language = new IAQueryField<string>("language", 0x100000);

		// range ? weird
		public static readonly IAQueryField<string> LicenseUrl = new IAQueryField<string>("licenseurl", 0x200000);

		/// <summary>
		/// The media type of the item. The field type is a <see cref="IAMediaType"/>.
		/// </summary>
		public static readonly IAQueryField<IAMediaType> MediaType = new IAQueryField<IAMediaType>("mediatype", 0x400000);

		public static readonly IAQueryField<string> Members = new IAQueryField<string>("members", 0x800000);

		public static readonly IAQueryField<int> Month = new IAQueryField<int>("month", 0x1000000);

		public static readonly IAQueryField<string> Name = new IAQueryField<string>("name", 0x2000000);

		public static readonly IAQueryField<string> NoIndex = new IAQueryField<string>("noindex", 0x4000000);

		public static readonly IAQueryField<int> NumberOfReviews = new IAQueryField<int>("num_reviews", 0x8000000);

		public static readonly IAQueryField<string> OaiUpdateDate = new IAQueryField<string>("oai_updatedate", 0x10000000);

		public static readonly IAQueryField<DateTime> PublicDate = new IAQueryField<DateTime>("publicdate", 0x20000000);

		public static readonly IAQueryField<string> Publisher = new IAQueryField<string>("publisher", 0x40000000);

		public static readonly IAQueryField<string> RelatedExternalId = new IAQueryField<string>("related-external-id", 0x80000000);

		public static readonly IAQueryField<string> ReviewDate = new IAQueryField<string>("reviewdate", 0x100000000);

		public static readonly IAQueryField<string> Rights = new IAQueryField<string>("rights", 0x200000000);

		public static readonly IAQueryField<string> ScanningCentre = new IAQueryField<string>("scanningcentre", 0x400000000);

		public static readonly IAQueryField<string> Source = new IAQueryField<string>("source", 0x800000000);

		public static readonly IAQueryField<string> StrippedTags = new IAQueryField<string>("stripped_tags", 0x1000000000);

		public static readonly IAQueryField<string> Subject = new IAQueryField<string>("subject", 0x2000000000);

		/// <summary>
		/// The title of the item. The field type is a <see cref="string"/>.
		/// </summary>
		public static readonly IAQueryField<string> Title = new IAQueryField<string>("title", 0x4000000000);

		// should be an IAFileKind 
		public static readonly IAQueryField<string> Type = new IAQueryField<string>("type", 0x8000000000);

		public static readonly IAQueryField<string> Volume = new IAQueryField<string>("volume", 0x10000000000);

		public static readonly IAQueryField<int> Week = new IAQueryField<int>("week", 0x20000000000);

		public static readonly IAQueryField<int> Year = new IAQueryField<int>("year", 0x40000000000);
	}
}
