using System.Text.Json.Serialization;

namespace Serti.Client.SharedPage.DX.Input
{
    public partial class DX_CheckBox
    {
    }

    public class DX_CheckBox_Options
    {
        [JsonPropertyName("Target")]
        public string Target { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }
    }
}
