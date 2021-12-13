using System.Text.Json.Serialization;

namespace Serti.Client.SharedPage.DX.Input
{
    public partial class DX_Switch
    {
    }

    public class DX_Switch_Options
    {
        [JsonPropertyName("Target")]
        public string Target { get; set; }
    }
}
