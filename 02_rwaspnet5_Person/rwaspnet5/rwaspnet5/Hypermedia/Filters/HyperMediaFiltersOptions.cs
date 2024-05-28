using rwaspnet5.Hypermedia.Abstract;

namespace rwaspnet5.Hypermedia.Filters
{
    public class HyperMediaFiltersOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
