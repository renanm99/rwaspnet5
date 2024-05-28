using rwaspnet5.Hypermedia;
using rwaspnet5.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace rwaspnet5.Data.VO
{
    public class BookVO : ISupportHyperMedia
    {
        [JsonPropertyName("ID")]
        public long Id { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }
        public decimal Price { get; set; }

        [JsonPropertyName("Launch_Date")]
        public DateTime launchDate { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
