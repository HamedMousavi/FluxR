using System.Collections.Generic;


namespace PhotoFlux.Models
{

    public class FlickrResponse
    {
        public PagedPhotos Photos { get; set; }
        public string Stat { get; set; }
    }

    public class FlickrPhotoDetail
    {
        public PhotoDetails Photo { get; set; }
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


    public class PhotoDetails
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
        public PhotoOwner Owner { get; set; }
        public PhotoTitle Title { get; set; }
        public PhotoDescription Description { get; set; }
        public PhotoVisibility Visibility { get; set; }
        public PhotoDates Dates { get; set; }
        public string Views { get; set; }
    }


    public class PhotoOwner
    {
        public string Nsid { get; set; }
        public string Username { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public string IconServer { get; set; }
        public string IconFarm { get; set; }
        public string PathAlias { get; set; }
    }


    public class PhotoTitle
    {
        public string Content { get; set; }
    }


    public class PhotoDescription
    {
        public string Content { get; set; }
    }


    public class PhotoVisibility
    {
        public string IsPublic { get; set; }
        public string IsFriend { get; set; }
        public string IsFamily { get; set; }
    }


    public class PhotoDates
    {
        public string Posted { get; set; }
        public string Taken { get; set; }
        public string TakenGranularity { get; set; }
        public string TakenUnknown { get; set; }
        public string LastUpdate { get; set; }
    }


    public class PhotoEditability
    {
        public string CanComment { get; set; }
        public string CanAddMeta { get; set; }
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
