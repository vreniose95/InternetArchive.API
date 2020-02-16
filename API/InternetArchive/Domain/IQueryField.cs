using System;
using JetBrains.Annotations;

namespace InternetArchive.API.InternetArchive.Domain
{
	public interface IQueryField
	{
		[NotNull]
		string FieldName { get; }

		[NotNull]
		string MemberName { get; }

		Type ValueType { get; }
	}
}