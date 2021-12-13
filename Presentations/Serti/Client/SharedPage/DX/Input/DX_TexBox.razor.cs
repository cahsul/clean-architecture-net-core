using System.Text.Json.Serialization;

namespace Serti.Client.SharedPage.DX.Input
{
    public partial class DX_TexBox
    {
    }

    public class DX_TexBox_Options
    {
        [JsonPropertyName("Label")]
        public string Label { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Value")]
        public string Value { get; set; }


        [JsonPropertyName("Target")]
        public string Target { get; set; }

        [JsonPropertyName("Placeholder")]
        public string Placeholder { get; set; }

        [JsonPropertyName("Validator")]
        public List<Validator> Validator { get; set; }
    }

    public class Validator
    {
        public string Type { get; set; }
    }
}
