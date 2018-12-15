using PhotoFlux.Models;
using PhotoFlux.Settings;
using RestSharp;
using System;


namespace PhotoFlux.Domain
{

    public class FlickrApi : IPhotoStore
    {

        private FlickrSettings _flickrSettings;
        private readonly IMapper<PhotoDetails, PhotoMetadata> _photoDetailMapper;


        public FlickrApi(FlickrSettings flickrSettings, IMapper<PhotoDetails, PhotoMetadata> photoDetailMapper)
        {
            _flickrSettings = flickrSettings;
            _photoDetailMapper = photoDetailMapper;
        }


        public IPhotoMetadata GetPhotoDetails(string id)
        {
            var apiResult = CallFlickrFor<FlickrPhotoDetail>(request =>
            {
                request.AddParameter("method", "flickr.photos.getInfo");
                request.AddParameter("photo_id", id);
            });
            
            return _photoDetailMapper.Map(apiResult.Photo);
            
        }



        public IPaged<IPhoto> Search(string q)
        {
            return null;
            //return CallFlickrFor<FlickrResponse>(request =>
            //{
            //    request.AddParameter("method", "flickr.photos.search");
            //    request.AddParameter("text", q);
            //}).Photos.Photo;
        }


        private T CallFlickrFor<T>(Action<RestRequest> addParameters) where T : new()
        {
            var client = FlickrClient();
            var request = FlickrRequest();
            addParameters(request);

            return client.Execute<T>(request).Data;
        }


        private RestClient FlickrClient()
        {
            return new RestClient("https://api.flickr.com");
        }


        private RestRequest FlickrRequest()
        {
            var request = new RestRequest("services/rest", Method.GET);
            request.AddParameter("format", "rest");
            request.AddParameter("api_key", _flickrSettings.Key);
            request.AddParameter("format", "json");
            request.AddParameter("nojsoncallback", "1");
            request.AddHeader("Accept", "application/json");

            return request;
        }
    }
}
