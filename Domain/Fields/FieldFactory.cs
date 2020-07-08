using System.Runtime.CompilerServices;

namespace InternetArchive.API.Domain.Fields
{
	public static class FieldFactory
	{
		public static IAQueryField<TValue> Define<TValue>(
			string name,
			ulong value,
			[CallerMemberName] string memberName = "")
		{
			return new IAQueryField<TValue>(
				name,
				value,
				memberName);
		}

		public static IASortableQueryField<TValue> DefineSortable<TValue>(
			string name,
			ulong value,
			[CallerMemberName] string memberName = "")
		{
			return new IASortableQueryField<TValue>(
				name,
				value,
				memberName);
		}
	}
}