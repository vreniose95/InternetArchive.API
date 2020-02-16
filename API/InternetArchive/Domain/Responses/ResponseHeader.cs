using System.Diagnostics;
using Newtonsoft.Json;

namespace InternetArchive.API.InternetArchive.Domain.Responses
{
  [DebuggerDisplay("{DebuggerDisplay}")]
  internal class ResponseHeader
  {
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("QTime")]
    public int QueryTime { get; set; }

    [JsonProperty("params")]
    public Params Parameters { get; set; }

    [JsonIgnore]
    public string DebuggerDisplay
    {
      get => $"Header: {QueryTime}ms | {Status}";
    }
  }
}