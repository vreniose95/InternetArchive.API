namespace InternetArchive.API.InternetArchive.Domain
{
	public class IACredentials
	{
		public string AccessApiKey { get; }

		public string SecretApiKey { get; }


		public IACredentials(
			string accessApiKey,
			string secretApiKey)
		{
			AccessApiKey = accessApiKey;
			SecretApiKey = secretApiKey;
		}
	}
}
