using Ccr.Std.Core.Extensions;
using InternetArchive.API.Domain.Fields;

namespace InternetArchive.API.Domain.Sorting
{
	public class QuerySort
	{
		private readonly IQueryField _queryField;
		public string _customField;
		private readonly IASortDirection _sortDirection;


		public IQueryField Field
		{
			get => _queryField;
		}

		public string CustomField
		{
			get => _customField;
		}
		
		public IASortDirection SortDirection
		{
			get => _sortDirection;
		} 


		public QuerySort(
			IQueryField field,
			IASortDirection sortDirection)
		{
			_queryField = field;
			_sortDirection = sortDirection;
		}


		public override string ToString()
		{
			if (!CustomField.IsNullOrEmptyEx())
				return $"{CustomField}+{(SortDirection.SortKey)}";

			return $"{Field.FieldName}+{SortDirection.SortKey}";
		}
	}
}