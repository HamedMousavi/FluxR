using System;
using System.Collections.Generic;


namespace PhotoFlux.Domain
{

    public interface IPhotoStore
    {
        IPaged<IPhoto> Search(string q);
        IPhotoMetadata GetPhotoDetails(string id);
    }


    public interface IPhoto
    {
    }


    public interface IPhotoMetadata
    {
        string Id { get; set; }
        string Title { get; set; }
        string License { get; set; }
        string Owner { get; set; }
        string Description { get; set; }
        DateTime? DatePosted { get; set; }
        DateTime? DateTaken { get; set; }
        DateTime? DateUpdated { get; set; }
        int ViewCount { get; set; }
        bool IsFavorite { get; set; }
    }


    public interface IPaged<T>
    {
        IEnumerable<T> Items { get; set; }
    }
}
