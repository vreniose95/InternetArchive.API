using System.Collections.Generic;
using InternetArchive.API.Domain;
using InternetArchive.API.Domain.Responses;

namespace InternetArchive.API.Interpreters
{
	internal class IAItemInterpreter
	{
		public static IAItem CreateArchiveItem(
			Doc doc)
		{
			return new IAItem(
				doc.Identifier,
				doc.Title,
				"channelName",
				"collection",
				doc.Creator,
				doc.Date,
				doc.Description,
				"language",
				new List<IASubjectTag>());
		}
	}
}