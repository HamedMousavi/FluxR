using PhotoFlux.Domain;
using PhotoFlux.Models;
using System;


namespace PhotoFlux.Flickr.Models.Mappers
{
    public class PhotoSearchResultMapper : BaseMapper<PagedFlickrPhotos, PhotoSearchResult>
    {
        protected override void Copy(PhotoSearchResult source, PagedFlickrPhotos target)
        {
            throw new NotImplementedException();
        }

        protected override void Copy(PagedFlickrPhotos source, PhotoSearchResult target)
        {
            throw new NotImplementedException();
        }
    }
}
