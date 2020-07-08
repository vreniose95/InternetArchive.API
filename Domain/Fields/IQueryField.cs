using System;
using JetBrains.Annotations;

namespace InternetArchive.API.Domain.Fields
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