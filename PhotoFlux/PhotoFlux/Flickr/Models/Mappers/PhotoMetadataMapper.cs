using PhotoFlux.Domain;
using PhotoFlux.Models;
using System;
using System.Linq;

namespace PhotoFlux.Flickr.Models.Mappers
{


    public class PhotoMetadataMapper : BaseMapper<FlickrPhotoDetails, PhotoMetadata>
    {


        protected override void Copy(PhotoMetadata source, FlickrPhotoDetails target)
        {
            throw new NotImplementedException();
        }


        protected override void Copy(FlickrPhotoDetails source, PhotoMetadata target)
        {
            target.Id = source.Id;
            target.DatePosted = ParseDate(source.Dates.Posted);
            target.DateTaken = ParseDate(source.Dates.Taken);
            target.DateUpdated = ParseDate(source.Dates.LastUpdate);
            target.Description = source.Description.Content;
            target.IsFavorite = string.Equals(source.IsFavorite, "1", StringComparison.InvariantCultureIgnoreCase);
            target.Owner = source.Owner.RealName;
            target.License = source.License;
            target.Title = source.Title.Content;
            target.ViewCount = Int32.Parse(source.Views);
            target.Url = source.Urls != null && source.Urls.Url != null && source.Urls.Url.Any() ? source.Urls.Url[0].Content : string.Empty;
        }


        private DateTime? ParseDate(string date)
        {
            var result = DateTime.MinValue;
            if (DateTime.TryParse(date, out result)) return result;

            return null;
        }
    }
}