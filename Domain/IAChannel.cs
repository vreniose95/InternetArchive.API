using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace InternetArchive.API.Domain
{
	/// <summary>
	///	Represents information about a Internet Archive channel.
	/// </summary>
	public class IAChannel
	{
		/// <summary>
		///	The name of this channel.
		/// </summary>
		[NotNull]
		public string ChannelName { get; }

		/// <summary>
		///	The logo image URL of this channel.
		/// </summary>
		[NotNull]
		public string LogoUrl { get; }


		/// <summary>
		///	Initializes an instance of <see cref="IAChannel"/> type.
		/// </summary>
		public IAChannel(
			[NotNull] string channelName,
			[NotNull] string logoUrl)
		{
			channelName.IsNotNull(nameof(channelName));
			logoUrl.IsNotNull(nameof(logoUrl));
			
			ChannelName = channelName;
			LogoUrl = logoUrl;
		}


		/// <inheritdoc />
		public override string ToString()
		{
			return ChannelName;
		}
	}
}