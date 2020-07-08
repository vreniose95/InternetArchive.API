using System;
using System.Linq;
using System.Text;
using Ccr.Scraping.API.Common.Query;
using Ccr.Scraping.API.Infrastructure;
using Ccr.Std.Core.Extensions;
using InternetArchive.API.Domain;
using InternetArchive.API.Domain.Fields;
using InternetArchive.API.Domain.Sorting;

namespace InternetArchive.API.Query
{
	public class IAQueryBuilder
		: IIAQueryBuilder,
			IQueryBuilder
	{
		private string _creator;
		private string _uploader;
		private string _subject;
		private IQueryField[] _fields;
		private IQueryField _sortField;
		private IASortDirection? _sortDirection;
		private uint? _rowCount;
		private uint? _onPageNumber;
		private APIDataOutputKind? _dataOutputKind;
		private string _callback;
		private bool? _shouldSave;


		public static IIAQueryBuilder Builder
		{
			get => new IAQueryBuilder();
		}


		/// <inheritdoc />
		IAQueryBuilder IIAQueryBuilder.FromCreator(
			string creator)
		{
			if (_creator != null)
				throw new InvalidOperationException(
					$"The uploader cannot be set to {creator.Quote()} because the instance of " +
					$"{nameof(IAQueryBuilder).SQuote()} already has the creator {_creator.Quote()}.");

			_creator = creator;
			return this;
		}

		IAQueryBuilder IIAQueryBuilder.WithUploader(
			string uploader)
		{
			if (_uploader != null)
				throw new InvalidOperationException(
					$"The uploader cannot be set to {uploader.Quote()} because the instance of " +
					$"{nameof(IAQueryBuilder).SQuote()} already has the uploader {_uploader.Quote()}.");

			_uploader = uploader;
			return this;
		}

		IAQueryBuilder IIAQueryBuilder.WithSubject(
			string subject)
		{
			if (_subject != null)
				throw new InvalidOperationException(
					$"The subject cannot be set to {subject.Quote()} because the instance of " +
					$"{nameof(IAQueryBuilder).SQuote()} already has the subject {_subject.Quote()}.");

			_subject = subject;
			return this;
		}

		/// <inheritdoc />
		IAQueryBuilder IIAQueryBuilder.WithDescription(
			string description)
		{

			throw new NotImplementedException();
		}

		/// <inheritdoc />
		IAQueryBuilder IIAQueryBuilder.OfMediaType(
			IAMediaType mediaType)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		IAQueryBuilder IIAQueryBuilder.InMonth(
			Month month)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		IAQueryBuilder IIAQueryBuilder.InYear(
			int year)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		IAQueryBuilder IIAQueryBuilder.WithField<TValue>(
			IAQueryField<TValue> queryField,
			TValue value)
		{
			throw new NotImplementedException();
		}

		IAQueryBuilder IIAQueryBuilder.WithFields(
			params IQueryField[] fields)
		{
			if (_fields != null)
				throw new InvalidOperationException(
					$"The fields cannot be set to {fields.Aggregate("", (s, i) => s += i.ToString().ToLower()).Quote()} " +
					$"because the instance of {nameof(IAQueryBuilder).SQuote()} already has the fields " +
					$"{_fields.Aggregate("", (s, i) => s += i.ToString().ToLower()).Quote()}.");

			_fields = fields;
			return this;
		}

		IAQueryBuilder IIAQueryBuilder.WithSort(
			IQueryField sortField,
			IASortDirection sortDirection)
		{
			if (_sortField != null)
				throw new InvalidOperationException(
					$"The sortField cannot be set to {sortField.ToString().ToLower().Quote()} because the " +
					$"instance of {nameof(IAQueryBuilder).SQuote()} already has the sortField " +
					$"{_sortField.ToString().ToLower().SQuote()}.");

			_sortField = sortField;

			if (_sortDirection != null)
				throw new InvalidOperationException(
					$"The sortDirection cannot be set to {sortDirection.ToString().ToLower().Quote()} because the " +
					$"instance of {nameof(IAQueryBuilder).SQuote()} already has the sortDirection " +
					$"{_sortDirection.ToString().ToLower().SQuote()}.");

			_sortDirection = sortDirection;

			return this;
		}

		IAQueryBuilder IIAQueryBuilder.WithRows(
			uint rowCount)
		{
			if (_rowCount != null)
				throw new InvalidOperationException(
					$"The rowCount cannot be set to {rowCount.ToString().SQuote()} because the instance of " +
					$"{nameof(IAQueryBuilder).SQuote()} already has the rowCount " +
					$"{_rowCount.ToString().Quote()}.");

			_rowCount = rowCount;
			return this;
		}

		IAQueryBuilder IIAQueryBuilder.OnPageNumber(
			uint pageNumber)
		{
			if (_onPageNumber != null)
				throw new InvalidOperationException(
					$"The pageNumber cannot be set to {pageNumber.ToString().SQuote()} because the instance of " +
					$"{nameof(IAQueryBuilder).SQuote()} already has the pageNumber " +
					$"{_onPageNumber.ToString().Quote()}.");

			_onPageNumber = pageNumber;
			return this;
		}

		IAQueryBuilder IIAQueryBuilder.WithOutputKind(
			APIDataOutputKind dataOutputKind)
		{
			if (_dataOutputKind != null)
				throw new InvalidOperationException(
					$"The dataOutputKind cannot be set to {dataOutputKind.ToString().ToLower().SQuote()} " +
					$"because the instance of {nameof(IAQueryBuilder).SQuote()} already has the " +
					$"dataOutputKind {_dataOutputKind.ToString().ToLower().SQuote()}.");

			_dataOutputKind = dataOutputKind;
			return this;
		}

		IAQueryBuilder IIAQueryBuilder.WithCallback(
			string callback)
		{
			if (_callback != null)
				throw new InvalidOperationException(
					$"The callback cannot be set to {callback.Quote()} because the instance of " +
					$"{nameof(IAQueryBuilder).SQuote()} already has the callback {_callback.Quote()}.");

			_callback = callback;
			return this;
		}

		IAQueryBuilder IIAQueryBuilder.WithShouldSave(
			bool shouldSave)
		{
			if (_shouldSave != null)
				throw new InvalidOperationException(
					$"The shouldSave cannot be set to {shouldSave.ToString().SQuote()} because the instance of " +
					$"{nameof(IAQueryBuilder).SQuote()} already has the shouldSave " +
					$"{_shouldSave.ToString().Quote()}.");

			_shouldSave = shouldSave;
			return this;
		}


		public string BuildRequestUrl(
			DomainFragment requestBuilder)
		{
			var uriBuilder = requestBuilder
				.Builder
				.WithPath("advancedsearch.php");

			void _setQueryString()
				//string uploader,
				//string subject)
			{
				var sb = new StringBuilder();
				var hasConstraint = false;

				if (_creator != null)
				{
					sb.Append($"creator:(\"{_creator}\")");
					hasConstraint = true;
				}
				if (_uploader != null)
				{
					if (hasConstraint)
						sb.Append($" AND ");

					sb.Append($"uploader:{_uploader}");
					hasConstraint = true;
				}
				if (_subject != null)
				{
					if (hasConstraint)
						sb.Append($" AND ");

					sb.Append($"subject:({_subject})");
					hasConstraint = true;
				}

				uriBuilder
					.WithParameter(
						"q",
						sb.ToString());
			}

			_setQueryString();
				//_uploader,
				//_subject);

			if (_fields != null)
			{
				foreach (var field in _fields)
				{
					uriBuilder.WithParameter("fl[]", field.FieldName.ToLower());
				}
			}

			if (_sortDirection.HasValue && _sortField != null)
			{
				var sb = new StringBuilder();

				sb.Append(_sortField.FieldName.ToLower());
				sb.Append("Sorter ");
				sb.Append(_sortDirection.Value.SortKey);


				//switch (_sortDirection)
				//{
				//	case IASortDirection.Ascending:
				//		sb.Append("asc");
				//		break;
				//	case IASortDirection.Descending:
				//		sb.Append("desc");
				//		break;
				//	default:
				//		throw new ArgumentOutOfRangeException();
				//}

				uriBuilder.WithParameter("sort[]", sb.ToString());
			}

			if (_rowCount.HasValue)
			{
				uriBuilder.WithParameter("rows", _rowCount.ToString());
			}
			if (_onPageNumber.HasValue)
			{
				uriBuilder.WithParameter("page", _onPageNumber.ToString());
			}
			if (_dataOutputKind.HasValue)
			{
				uriBuilder.WithParameter("output", _dataOutputKind.ToString().ToLower());
			}
			if (_callback != null)
			{
				uriBuilder.WithParameter("callback", _callback);
			}
			if (_shouldSave.HasValue)
			{
				uriBuilder.WithParameter("save", _shouldSave.Value ? "yes" : "no");
			}

			return uriBuilder.Build();
		}
	}
}

/*			void _setQueryString(
				string uploader,
				string subject)
			{
				var sb = new StringBuilder();

				if (uploader != null)
				{
					sb.Append($"creator:{uploader}");

					if (subject != null)
					{
						sb.Append($" AND ");
						sb.Append($"subject:({subject})");
					}
				}
				else
				{
					if (subject != null)
					{
						sb.Append($"subject:({subject})");
					}
				}

				uriBuilder
					.WithParameter(
						"q",
						sb.ToString());
			}*/
