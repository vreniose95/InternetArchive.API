using System;

namespace InternetArchive.API.Domain.Fields
{
	public static class IAQueryFields
	{
		public static readonly IAQueryField<string> BackupLocation 
			= FieldFactory.DefineSortable<string>("backup_location", 0x2);

		public static readonly IAQueryField<string> BTIH 
			= FieldFactory.Define<string>("btih", 0x4);

		public static readonly IAQueryField<string[]> Collection
			= FieldFactory.Define<string[]>("collection", 0x10);

		public static readonly IAQueryField<string> Contributor 
			= FieldFactory.Define<string>("contributor", 0x20);

		public static readonly IAQueryField<string> Coverage 
			= FieldFactory.Define<string>("coverage", 0x40);

		/// <summary>
		/// Author
		/// </summary>
		public static readonly IAQueryField<string> Creator
			= FieldFactory.DefineSortable<string>("creator", 0x80);

		//range and wildcard
		public static readonly IAQueryField<DateTime> Date 
			= FieldFactory.DefineSortable<DateTime>("date", 0x100);

		/// <summary>
		/// The text description of the item. The field type is a <see cref="string"/>.
		/// </summary>
		public static readonly IAQueryField<string> Description
			= FieldFactory.Define<string>("description", 0x200);

		//range and range with one side being NULL for > / <
		public static readonly IAQueryField<int> Downloads
			= FieldFactory.DefineSortable<int>("downloads", 0x400);

		public static readonly IAQueryField<string[]> Format 
			= FieldFactory.Define<string[]>("format", 0x2000);

		/// <summary>
		/// The identifier of the item. The field type is a <see cref="string"/>..
		/// </summary>
		public static readonly IAQueryField<string> Identifier
			= FieldFactory.DefineSortable<string>("identifier", 0x10000);
		
		public static readonly IAQueryField<string[]> IndexFlag 
			= FieldFactory.Define<string[]>("indexflag", 0x40000);

		public static readonly IAQueryField<long> ItemSize
			= FieldFactory.DefineSortable<long>("item_size", 0x80000);

		public static readonly IAQueryField<string> Language 
			= FieldFactory.DefineSortable<string>("language", 0x100000);

		/// <summary>
		/// The media type of the item. The field type is a <see cref="IAMediaType"/>.
		/// </summary>
		public static readonly IAQueryField<IAMediaType> MediaType 
			= FieldFactory.DefineSortable<IAMediaType>("mediatype", 0x400000);

		public static readonly IAQueryField<int> Month 
			= FieldFactory.DefineSortable<int>("month", 0x1000000);

		public static readonly IAQueryField<DateTime[]> OaiUpdateDate 
			= FieldFactory.Define<DateTime[]>("oai_updatedate", 0x10000000);

		public static readonly IAQueryField<DateTime> PublicDate 
			= FieldFactory.DefineSortable<DateTime>("publicdate", 0x20000000);

		public static readonly IAQueryField<string[]> Subject 
			= FieldFactory.Define<string[]>("subject", 0x2000000000);

		/// <summary>
		/// The title of the item. The field type is a <see cref="string"/>.
		/// </summary>
		public static readonly IAQueryField<string> Title 
			= FieldFactory.DefineSortable<string>("title", 0x4000000000);

		public static readonly IAQueryField<int> Week
			= FieldFactory.DefineSortable<int>("week", 0x20000000000);

		public static readonly IAQueryField<int> Year
			= FieldFactory.DefineSortable<int>("year", 0x40000000000);
	}
}


#region old
//public static class IAQueryFields
//{
//	//public static readonly IAQueryField<double> AverageRating = new IAQueryField<double>("avg_rating", 0x1);

//	public static readonly IAQueryField<string> BackupLocation = new IAQueryField<string>("backup_location", 0x2);

//	public static readonly IAQueryField<string> BTIH = new IAQueryField<string>("btih", 0x4);

//	//public static readonly IAQueryField<string> CallNumber = new IAQueryField<string>("call_number", 0x8);

//	public static readonly IAQueryField<string[]> Collection = new IAQueryField<string[]>("collection", 0x10);

//	public static readonly IAQueryField<string> Contributor = new IAQueryField<string>("contributor", 0x20);

//	public static readonly IAQueryField<string> Coverage = new IAQueryField<string>("coverage", 0x40);

//	/// <summary>
//	/// Author
//	/// </summary>
//	public static readonly IAQueryField<string> Creator = new IAQueryField<string>("creator", 0x80);

//	//range and wildcard
//	public static readonly IAQueryField<string> Date = new IAQueryField<string>("date", 0x100);

//	/// <summary>
//	/// The text description of the item. The field type is a <see cref="string"/>.
//	/// </summary>
//	public static readonly IAQueryField<string> Description = new IAQueryField<string>("description", 0x200);

//	//range and range with one side being NULL for > / <
//	public static readonly IAQueryField<int> Downloads = new IAQueryField<int>("downloads", 0x400);

//	//public static readonly IAQueryField<string> ExternalIdentifier = new IAQueryField<string>("external-identifier", 0x800);

//	//public static readonly IAQueryField<int> FoldoutCount = new IAQueryField<int>("foldoutcount", 0x1000);

//	public static readonly IAQueryField<string[]> Format = new IAQueryField<string[]>("format", 0x2000);

//	//public static readonly IAQueryField<string> Genre = new IAQueryField<string>("genre", 0x4000);

//	//public static readonly IAQueryField<string> HeaderImage = new IAQueryField<string>("headerImage", 0x8000);

//	/// <summary>
//	/// The identifier of the item. The field type is a <see cref="string"/>..
//	/// </summary>
//	public static readonly IAQueryField<string> Identifier = new IAQueryField<string>("identifier", 0x10000);

//	//public static readonly IAQueryField<int> ImageCount = new IAQueryField<int>("imagecount", 0x20000);

//	public static readonly IAQueryField<string[]> IndexFlag = new IAQueryField<string[]>("indexflag", 0x40000);

//	public static readonly IAQueryField<long> ItemSize = new IAQueryField<long>("item_size", 0x80000);

//	public static readonly IAQueryField<string> Language = new IAQueryField<string>("language", 0x100000);

//	// range ? weird
//	//public static readonly IAQueryField<string> LicenseUrl = new IAQueryField<string>("licenseurl", 0x200000);

//	/// <summary>
//	/// The media type of the item. The field type is a <see cref="IAMediaType"/>.
//	/// </summary>
//	public static readonly IAQueryField<IAMediaType> MediaType = new IAQueryField<IAMediaType>("mediatype", 0x400000);

//	//public static readonly IAQueryField<string> Members = new IAQueryField<string>("members", 0x800000);

//	public static readonly IAQueryField<int> Month = new IAQueryField<int>("month", 0x1000000);

//	//public static readonly IAQueryField<string> Name = new IAQueryField<string>("name", 0x2000000);

//	//public static readonly IAQueryField<string> NoIndex = new IAQueryField<string>("noindex", 0x4000000);

//	//public static readonly IAQueryField<int> NumberOfReviews = new IAQueryField<int>("num_reviews", 0x8000000);

//	public static readonly IAQueryField<DateTime[]> OaiUpdateDate = new IAQueryField<DateTime[]>("oai_updatedate", 0x10000000);

//	public static readonly IAQueryField<DateTime> PublicDate = new IAQueryField<DateTime>("publicdate", 0x20000000);

//	//public static readonly IAQueryField<string> Publisher = new IAQueryField<string>("publisher", 0x40000000);

//	//public static readonly IAQueryField<string> RelatedExternalId = new IAQueryField<string>("related-external-id", 0x80000000);

//	//public static readonly IAQueryField<string> ReviewDate = new IAQueryField<string>("reviewdate", 0x100000000);

//	//public static readonly IAQueryField<string> Rights = new IAQueryField<string>("rights", 0x200000000);

//	//public static readonly IAQueryField<string> ScanningCentre = new IAQueryField<string>("scanningcentre", 0x400000000);

//	//public static readonly IAQueryField<string> Source = new IAQueryField<string>("source", 0x800000000);

//	//public static readonly IAQueryField<string> StrippedTags = new IAQueryField<string>("stripped_tags", 0x1000000000);

//	public static readonly IAQueryField<string[]> Subject = new IAQueryField<string[]>("subject", 0x2000000000);

//	/// <summary>
//	/// The title of the item. The field type is a <see cref="string"/>.
//	/// </summary>
//	public static readonly IAQueryField<string> Title = new IAQueryField<string>("title", 0x4000000000);

//	// should be an IAFileKind 
//	//public static readonly IAQueryField<string> Type = new IAQueryField<string>("type", 0x8000000000);

//	//public static readonly IAQueryField<string> Volume = new IAQueryField<string>("volume", 0x10000000000);

//	public static readonly IAQueryField<int> Week = new IAQueryField<int>("week", 0x20000000000);

//	public static readonly IAQueryField<int> Year = new IAQueryField<int>("year", 0x40000000000);
//}
#endregion

/*
__random desc
__random asc
__sort desc
__sort asc
addeddate desc
addeddate asc
avg_rating desc
avg_rating asc
call_number desc
call_number asc
createdate desc
createdate asc
creatorSorter desc
creatorSorter asc
creatorSorterRaw desc
creatorSorterRaw asc
date desc
date asc
downloads desc
downloads asc
foldoutcount desc
foldoutcount asc
headerImage desc
headerImage asc
identifier desc
identifier asc
identifierSorter desc
identifierSorter asc
imagecount desc
imagecount asc
indexdate desc
indexdate asc
item_size desc
item_size asc
languageSorter desc
languageSorter asc
licenseurl desc
licenseurl asc
mediatype desc
mediatype asc
mediatypeSorter desc
mediatypeSorter asc
month desc
month asc
nav_order desc
nav_order asc
num_reviews desc
num_reviews asc
programSorter desc
programSorter asc
publicdate desc
publicdate asc
reviewdate desc
reviewdate asc
stars desc
stars asc
titleSorter desc
titleSorter asc
titleSorterRaw desc
titleSorterRaw asc
week desc
week asc
year desc
year asc





//__random asc
//__sort asc
//addeddate asc
avg_rating asc
//call_number asc
//createdate asc
creatorSorter asc
creatorSorterRaw asc
date asc
downloads asc
//foldoutcount asc
//headerImage asc
identifier asc
identifierSorter asc
//imagecount asc
//indexdate asc
item_size asc
languageSorter asc
//licenseurl asc
mediatype asc
mediatypeSorter asc
month asc
//nav_order asc
//num_reviews asc
//programSorter asc
publicdate asc
//reviewdate asc
//stars asc
titleSorter asc
titleSorterRaw asc
week asc
year asc

 */
