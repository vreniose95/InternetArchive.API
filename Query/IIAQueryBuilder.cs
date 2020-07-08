using InternetArchive.API.Domain;
using InternetArchive.API.Domain.Fields;
using InternetArchive.API.Domain.Sorting;

namespace InternetArchive.API.Query
{
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
}