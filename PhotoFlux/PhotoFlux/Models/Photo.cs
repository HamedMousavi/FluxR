using PhotoFlux.Domain;
using System;
using System.Collections.Generic;


namespace PhotoFlux.Models
{

    public class PhotoMetadata : IPhotoMetadata
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string License { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? DateTaken { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int ViewCount { get; set; }
        public bool IsFavorite { get; set; }
    }


    public class PhotoSearchResult : IPaged<IPhotoSearchResult>
    {
        public IEnumerable<IPhotoSearchResult> Items { get; set; }
    }
}
