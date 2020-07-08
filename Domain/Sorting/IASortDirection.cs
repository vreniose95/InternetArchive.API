using System.Runtime.CompilerServices;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace InternetArchive.API.Domain.Sorting
{
	public readonly struct IASortDirection
	{
		public string SortKey { get; }

		public string MemberName { get; }

		
		private IASortDirection(
			[NotNull] string sortKey,
			[CallerMemberName] string memberName = "")
		{
			SortKey = sortKey;
			MemberName = memberName;
		}


		/// <inheritdoc />
		public override string ToString()
		{
			return $"{nameof(IASortDirection).SQuote()}.{MemberName} -> {SortKey.Quote()}";
		}


		public static readonly IASortDirection Ascending = new IASortDirection("asc");

		public static readonly IASortDirection Descending = new IASortDirection("desc");
	}
}