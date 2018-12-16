using PhotoFlux.Domain;
using PhotoFlux.Google;
using PhotoFlux.Models;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace PhotoFlux.Flickr
{

    public class FlickrApi : IPhotoStore
    {

        public FlickrApi(
            FlickrSettings flickrSettings
            , GoogleSettings googleSettings
            , IMapper<FlickrPhotoDetails, PhotoMetadata> photoDetailMapper
            , IMapper<PagedFlickrPhotos, PagedPhotoSearchResult> photoSearchMapper)
        {
            _flickrSettings = flickrSettings;
            _googleSettings = googleSettings;
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


        public async Task<IPaged<IPhotoSearchResult>> SearchAsync(string q, IGeoRegion region)
        {
            if (!region.IsValid()) return await SearchAsync(q);

            var apiResult = await CallFlickrFor<FlickrSearchResult>(request =>
            {
                request.AddParameter("method", "flickr.photos.search");
                request.AddParameter("text", q);
                request.AddParameter("lat", region.Latitude);
                request.AddParameter("lon", region.Longitude);
                request.AddParameter("radius", region.RadiusInKm);
                request.AddParameter("radius_units", "km");
            });

            return _PhotoSearchMapper.Map(apiResult.Photos);
        }


        public async Task<IPaged<IPhotoSearchResult>> SearchAsync(string q, string address)
        {
            // Todo: Google Api is our dependency and should not be placed here directly
            //var client = new RestClient("http://localhost:50674");
            //var request = new RestRequest("api/google", Method.GET);
            var client = new RestClient("https://maps.googleapis.com");
            var request = new RestRequest("maps/api/geocode/json", Method.GET);
            request.AddParameter("key", _googleSettings.ApiKey);
            request.AddParameter("address", address);

            var response = (await client.ExecuteTaskAsync<Google.Models.Geocoder>(request));
            var geocode = response.Data;

            if (geocode == null ||
                geocode.Results == null ||
                !geocode.Results.Any() ||
                geocode.Results[0].Geometry == null ||
                geocode.Results[0].Geometry.Location == null) return await SearchAsync(q);

            var region = geocode.Results[0].Geometry.Location;
            return await SearchAsync(q, new GeoRegion(region.Lat, region.Lng, 10));
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
        private readonly GoogleSettings _googleSettings;
        private readonly IMapper<FlickrPhotoDetails, PhotoMetadata> _photoDetailMapper;
        private readonly IMapper<PagedFlickrPhotos, PagedPhotoSearchResult> _PhotoSearchMapper;
    }
}
