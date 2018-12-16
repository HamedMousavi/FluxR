using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PhotoFlux.Domain
{

    public interface IPhotoStore
    {
        Task<IPaged<IPhotoSearchResult>> SearchAsync(string q);
        Task<IPaged<IPhotoSearchResult>> SearchAsync(string q, string address);
        Task<IPaged<IPhotoSearchResult>> SearchAsync(string q, IGeoRegion region);
        Task<IPhotoMetadata> GetPhotoDetailsAsync(string id);
    }


    public interface IGeoRegion
    {
        decimal Latitude { get; }
        decimal Longitude { get; }
        double RadiusInKm { get; }

        bool IsValid();
    }


    public interface IPhotoSearchResult
    {
        string Id { get; set; }
        string Title { get; set; }
        bool IsPublic { get; set; }
        bool IsFriend { get; set; }
        bool IsFamily { get; set; }
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
