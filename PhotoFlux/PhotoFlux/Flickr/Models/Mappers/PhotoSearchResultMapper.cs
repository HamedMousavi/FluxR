using Microsoft.AspNetCore.Hosting;
using PhotoFlux.Domain;
using PhotoFlux.Models;
using System;
using System.Linq;


namespace PhotoFlux.Flickr.Models.Mappers
{

    public class PhotoSearchResultMapper : BaseMapper<PagedFlickrPhotos, PagedPhotoSearchResult>
    {

        private readonly IHostingEnvironment _host;


        public PhotoSearchResultMapper(IHostingEnvironment host)
        {
            _host = host;
        }


        protected override void Copy(PagedPhotoSearchResult source, PagedFlickrPhotos target)
        {
            throw new NotImplementedException();
        }


        protected override void Copy(PagedFlickrPhotos source, PagedPhotoSearchResult target)
        {
            target.Items = source.Photo.Select(p =>
             new PhotoSearchResult
             {
                 Id = p.Id,
                 IsFamily = string.Equals(p.IsFamily, "1", StringComparison.InvariantCultureIgnoreCase),
                 IsFriend = string.Equals(p.IsFriend, "1", StringComparison.InvariantCultureIgnoreCase),
                 IsPublic = string.Equals(p.IsPublic, "1", StringComparison.InvariantCultureIgnoreCase),
             }
            );
        }
    }
}
