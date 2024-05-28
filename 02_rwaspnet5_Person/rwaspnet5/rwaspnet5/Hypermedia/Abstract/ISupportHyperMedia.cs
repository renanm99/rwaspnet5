using Microsoft.AspNetCore.Mvc.Filters;

namespace rwaspnet5.Hypermedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
