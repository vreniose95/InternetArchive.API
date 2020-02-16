using Ccr.Std.Core.Extensions;
using InternetArchive.API.InternetArchive.Domain;
using InternetArchive.API.InternetArchive.Query;

namespace InternetArchive.API.InternetArchive.Extensions
{
  public static class InternetArchiveQueryBuilderExtensions
  {
	  public static IAQueryBuilder FromCreator(
		  this IAQueryBuilder @this,
		  string creator)
	  {
		  return @this
			  .As<IIAQueryBuilder>()
			  .FromCreator(creator);
	  }

    public static IAQueryBuilder WithUploader(
      this IAQueryBuilder @this,
      string uploader)
    {
      return @this
        .As<IIAQueryBuilder>()
        .WithUploader(uploader);
    }

    public static IAQueryBuilder WithSubject(
      this IAQueryBuilder @this,
      string subject)
    {
      return @this
        .As<IIAQueryBuilder>()
        .WithSubject(subject);
    }

    public static IAQueryBuilder WithDescription(
	    this IAQueryBuilder @this,
	    string description)
    {
	    return @this
		    .As<IIAQueryBuilder>()
		    .WithDescription(description);
    }

    public static IAQueryBuilder OfMediaType(
	    this IAQueryBuilder @this,
      IAMediaType mediaType)
    {
	    return @this
		    .As<IIAQueryBuilder>()
		    .OfMediaType(mediaType);
    }

    public static IAQueryBuilder InMonth(
	    this IAQueryBuilder @this,
	    Month month)
    {
	    return @this
		    .As<IIAQueryBuilder>()
		    .InMonth(month);
    }

    public static IAQueryBuilder InYear(
	    this IAQueryBuilder @this,
	    int year)
    {
	    return @this
		    .As<IIAQueryBuilder>()
		    .InYear(year);
    }

    public static IAQueryBuilder WithField<TValue>(
	    this IAQueryBuilder @this,
      IAQueryField<TValue> queryField,
	    TValue value)
    {
	    return @this
		    .As<IIAQueryBuilder>()
		    .WithField(queryField, value);
    }
    
    public static IAQueryBuilder WithFields(
      this IAQueryBuilder @this,
      params IQueryField[] fields)
    {
      return @this
        .As<IIAQueryBuilder>()
        .WithFields(fields);
    }

    public static IAQueryBuilder WithSort(
      this IAQueryBuilder @this,
      IQueryField field,
      IASortDirection direction)
    {
      return @this
        .As<IIAQueryBuilder>()
        .WithSort(field, direction);
    }

    public static IAQueryBuilder WithRows(
      this IAQueryBuilder @this,
      uint rowCount)
    {
      return @this
        .As<IIAQueryBuilder>()
        .WithRows(rowCount);
    }

    public static IAQueryBuilder OnPageNumber(
      this IAQueryBuilder @this,
      uint pageNumber)
    {
      return @this
        .As<IIAQueryBuilder>()
        .OnPageNumber(pageNumber);
    }

    public static IAQueryBuilder WithOutputKind(
      this IAQueryBuilder @this,
      APIDataOutputKind dataOutputKind)
    {
      return @this
        .As<IIAQueryBuilder>()
        .WithOutputKind(dataOutputKind);
    }

    public static IAQueryBuilder WithCallback(
      this IAQueryBuilder @this,
      string callback)
    {
      return @this
        .As<IIAQueryBuilder>()
        .WithCallback(callback);
    }

    public static IAQueryBuilder WithShouldSave(
      this IAQueryBuilder @this,
      bool shouldSave)
    {
      return @this
        .As<IIAQueryBuilder>()
        .WithShouldSave(shouldSave);
    }
  }
}