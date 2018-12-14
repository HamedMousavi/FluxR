using System.Collections.Generic;

namespace PhotoFlux.Models
{

    public class FlickrResponse
    {
        public PagedPhotos Photos { get; set; }
        public string Stat { get; set; }
    }

    public class Photo
    {
        public string Id { get; set; }
        public string Owner { get; set; }
        public string Secret { get; set; }
        public string Server { get; set; }
        public string Farm { get; set; }
        public string Title { get; set; }
        public string IsPublic { get; set; }
        public string IsFriend { get; set; }
        public string IsFamily { get; set; }
    }


    public class Paged
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
    }


    public class PagedPhotos : Paged
    {
        public List<Photo> Photo { get; set; }
    }

}
