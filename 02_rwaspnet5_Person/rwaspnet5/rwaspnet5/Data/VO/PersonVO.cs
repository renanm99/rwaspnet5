using rwaspnet5.Hypermedia;
using rwaspnet5.Hypermedia.Abstract;
using System.Text.Json.Serialization;

namespace rwaspnet5.Data.VO
{
    public class PersonVO : ISupportHyperMedia
    {
        [JsonPropertyName("ID")]
        public long Id { get; set; }
        [JsonPropertyName("Name")]
        public string FirstName { get; set; }
        [JsonPropertyName("Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [JsonPropertyName("Sex")]
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
