using System;
using System.Collections.Generic;
using System.Linq;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace InternetArchive.API.Domain
{
	/// <summary>
	///	Represents an Internet Archive Item that contains a set of files and related metadata.
	/// </summary>
	public class IAItem
	{
		/// <summary>
		///	Indicates the unique <see cref="IAItem"/> Item Identifier.
		/// </summary>
		[NotNull]
		public string Identifier { get; }

		/// <summary>
		///	The <see cref="IAItem"/> Title metadata <see cref="string"/>.
		/// </summary>
		[NotNull]
		public string Title { get; }

		public string ChannelName { get; }

		public string Collection { get; }

		public string Creator { get; }

		public DateTime UploadDate { get; }

		public string Description { get; }

		public string Language { get; }

		[NotNull, ItemNotNull]
		public IReadOnlyList<IASubjectTag> SubjectTags { get; }



		public IAItem(
			[NotNull] string identifer,
			[NotNull] string title,
			[NotNull] string channelName,
			[NotNull] string collection,
			[NotNull] string creator,
			DateTime uploadDate,
			[NotNull] string description,
			[NotNull] string language,
			[NotNull, ItemNotNull] IEnumerable<IASubjectTag> subjectTags)
		{
			identifer.IsNotNull(nameof(identifer));
			title.IsNotNull(nameof(title));
			channelName.IsNotNull(nameof(channelName));
			collection.IsNotNull(nameof(collection));
			//creator.IsNotNull(nameof(creator));
			//description.IsNotNull(nameof(description));
			language.IsNotNull(nameof(language));
			subjectTags.IsNotNull(nameof(subjectTags));
			
			Identifier = identifer;
			Title = title;
			ChannelName = channelName;
			Collection = collection;
			Creator = creator;
			UploadDate = uploadDate;
			Description = description;
			Language = language;
			SubjectTags = subjectTags.ToList();
		}
	}
}