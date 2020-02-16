using InternetArchive.API.InternetArchive.Domain;

namespace InternetArchive.API.InternetArchive.Query
{
	public enum Month
	{
		January = 1,
		February = 2,
		March = 3,
		April = 4,
		May = 5,
		June = 6,
		July = 7,
		August = 8,
		September = 9,
		October = 10,
		November = 11,
		December = 12
	}

	
	public interface IIAQueryBuilder
	{
		IAQueryBuilder FromCreator(
			string creator);

		IAQueryBuilder WithUploader(
			string uploader);

		IAQueryBuilder WithSubject(
			string subject);

		IAQueryBuilder WithDescription(
			string description);

		IAQueryBuilder OfMediaType(
			IAMediaType mediaType);

		IAQueryBuilder InMonth(
			Month month);

		IAQueryBuilder InYear(
			int year);

		IAQueryBuilder WithField<TValue>(
			IAQueryField<TValue> queryField,
			TValue value);


		IAQueryBuilder WithFields(
			params IQueryField[] fields);

		IAQueryBuilder WithSort(
			IQueryField field,
			IASortDirection direction);

		IAQueryBuilder WithRows(
			uint rowCount);

		IAQueryBuilder OnPageNumber(
			uint pageNumber);

		IAQueryBuilder WithOutputKind(
			APIDataOutputKind dataOutputKind);

		IAQueryBuilder WithCallback(
			string callback);

		IAQueryBuilder WithShouldSave(
			bool shouldSave);
	}
}//creator:("Opie and Anthony") AND uploader:("opieandanthonylive@gmail.com")