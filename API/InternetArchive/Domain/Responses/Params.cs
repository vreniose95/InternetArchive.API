using Newtonsoft.Json;

namespace InternetArchive.API.InternetArchive.Domain.Responses
{
	internal class Params
  {
    public string Query { get; set; }

    public string Qin { get; set; }

    public string Fields { get; set; }

    public string wt { get; set; }

    public string Sort { get; set; }

    public string Rows { get; set; }

    [JsonProperty("json.wrf")]
    public string JsonWrf { get; set; }

    public int Start { get; set; }
  }
}