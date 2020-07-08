using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace InternetArchive.API.Domain.Fields
{
	public class IASortableQueryField<TValue>
		: IAQueryField<TValue>,
			ISortableQueryField
	{
		internal IASortableQueryField(
			[NotNull] string fieldName,
			ulong value,
			string memberName) : base(
			fieldName, 
			value,
			memberName)
		{
		}


		/// <inheritdoc/>
		public override string ToString()
		{
			return $"{MemberName} -> {FieldName.Quote()} - [{Value:x8}] - Sortable";
		}
	}
}