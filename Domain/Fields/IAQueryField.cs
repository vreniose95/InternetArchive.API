using System;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace InternetArchive.API.Domain.Fields
{
	public class IAQueryField<TValue>
		: IQueryField
	{
		public ulong Value { get; }

		public string FieldName { get; }

		public string MemberName { get; }

		public Type ValueType
		{
			get => typeof(TValue);
		}


		internal IAQueryField(
			[NotNull] string fieldName,
			ulong value,
			string memberName)
		{
			Value = value;
			FieldName = fieldName;
			MemberName = memberName;
		}


		/// <inheritdoc />
		public override string ToString()
		{
			return $"{MemberName} -> {FieldName.Quote()} - [{Value:x8}]";
		}
	}
}