using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace De.Berndnet2000.MsfsToolbarGenerator.LayoutJson {
    public class Layout {
        [JsonPropertyName("content")]
        public List<File> Content { get; set; } = new List<File>();
    }
}