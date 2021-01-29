using System.Text.Json.Serialization;

namespace De.Berndnet2000.MsfsToolbarGenerator.LayoutJson {
    public class File {
        [JsonPropertyName("path")] public string Path { get; set; }
        [JsonPropertyName("size")] public long Size { get; set; }
        [JsonPropertyName("date")] public long Date { get; set; }
    }
}