using System.Collections.Generic;


namespace PhotoFlux.Models
{

    public class FlickrSearchResult
    {
        public PagedFlickrPhotos Photos { get; set; }
        public string Stat { get; set; }
    }


    public class FlickrPhotoDetail
    {
        public FlickrPhotoDetails Photo { get; set; }
        public string Stat { get; set; }
    }


    public class FlickrPhoto
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


    public class FlickrPhotoDetails
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Server { get; set; }
        public string Farm { get; set; }
        public string DateUploaded { get; set; }
        public string IsFavorite { get; set; }
        public string License { get; set; }
        public string SafetyLevel { get; set; }
        public string Rotation { get; set; }
        public string OriginalSecret { get; set; }
        public string OriginalFormat { get; set; }
        public FlickrPhotoOwner Owner { get; set; }
        public FlickrPhotoTitle Title { get; set; }
        public FlickrPhotoDescription Description { get; set; }
        public FlickrPhotoVisibility Visibility { get; set; }
        public FlickrPhotoDates Dates { get; set; }
        public string Views { get; set; }
        public FlickrPhotoUrlList Urls { get; set; }
    }


    public class FlickrPhotoOwner
    {
        public string Nsid { get; set; }
        public string Username { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public string IconServer { get; set; }
        public string IconFarm { get; set; }
        public string PathAlias { get; set; }
    }


    public class FlickrPhotoTitle
    {
        public string Content { get; set; }
    }


    public class FlickrPhotoDescription
    {
        public string Content { get; set; }
    }


    public class FlickrPhotoVisibility
    {
        public string IsPublic { get; set; }
        public string IsFriend { get; set; }
        public string IsFamily { get; set; }
    }


    public class FlickrPhotoDates
    {
        public string Posted { get; set; }
        public string Taken { get; set; }
        public string TakenGranularity { get; set; }
        public string TakenUnknown { get; set; }
        public string LastUpdate { get; set; }
    }


    public class FlickrPhotoEditability
    {
        public string CanComment { get; set; }
        public string CanAddMeta { get; set; }
    }


    public class FlickrPhotoUrlList
    {
        public List<FlickrPhotoUrl> Url { get; set; }
    }


    public class FlickrPhotoUrl
    {
        public string Type { get; set; }
        public string Content { get; set; }
    }


    public class Paged
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
    }


    public class PagedFlickrPhotos : Paged
    {
        public List<FlickrPhoto> Photo { get; set; }
    }

}
