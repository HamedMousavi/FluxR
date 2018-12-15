using PhotoFlux.Domain;
using PhotoFlux.Models;
using RestSharp;
using System;
using System.Threading.Tasks;


namespace PhotoFlux.Flickr
{

    public class FlickrApi : IPhotoStore
    {

        public FlickrApi(FlickrSettings flickrSettings
            , IMapper<FlickrPhotoDetails, PhotoMetadata> photoDetailMapper
            , IMapper<PagedFlickrPhotos, PhotoSearchResult> photoSearchMapper)
        {
            _flickrSettings = flickrSettings;
            _photoDetailMapper = photoDetailMapper;
            _PhotoSearchMapper = photoSearchMapper;
        }


        public async Task<IPhotoMetadata> GetPhotoDetailsAsync(string id)
        {
            var apiResult = await CallFlickrFor<FlickrPhotoDetail>(request =>
            {
                request.AddParameter("method", "flickr.photos.getInfo");
                request.AddParameter("photo_id", id);
            });

            return _photoDetailMapper.Map(apiResult.Photo);
        }



        public async Task<IPaged<IPhotoSearchResult>> SearchAsync(string q)
        {
            var apiResult = await CallFlickrFor<FlickrSearchResult>(request =>
            {
                request.AddParameter("method", "flickr.photos.search");
                request.AddParameter("text", q);
            });

            return _PhotoSearchMapper.Map(apiResult.Photos);
        }


        private async Task<T> CallFlickrFor<T>(Action<RestRequest> addParameters) where T : new()
        {
            var client = new RestClient("https://api.flickr.com"); ;
            var request = new RestRequest("services/rest", Method.GET);
            request.AddParameter("format", "rest");
            request.AddParameter("api_key", _flickrSettings.Key);
            request.AddParameter("format", "json");
            request.AddParameter("nojsoncallback", "1");
            request.AddHeader("Accept", "application/json");

            addParameters(request);

            return (await client.ExecuteTaskAsync<T>(request)).Data;
        }


        private FlickrSettings _flickrSettings;
        private readonly IMapper<FlickrPhotoDetails, PhotoMetadata> _photoDetailMapper;
        private readonly IMapper<PagedFlickrPhotos, PhotoSearchResult> _PhotoSearchMapper;
    }
}
