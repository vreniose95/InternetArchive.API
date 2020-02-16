using System;
using System.Runtime.CompilerServices;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace InternetArchive.API.InternetArchive.Domain
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
			[CallerMemberName] string memberName = "")
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