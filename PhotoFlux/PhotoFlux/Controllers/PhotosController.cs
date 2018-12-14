using Microsoft.AspNetCore.Mvc;
using PhotoFlux.Models;
using RestSharp;
using System.Collections.Generic;


namespace PhotoFlux.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        // GET api/photos/keyword
        [HttpGet]
        public ActionResult<IEnumerable<Photo>> Get([FromQuery]string q)
        {
            var client = new RestClient("https://api.flickr.com");

            var request = new RestRequest("services/rest", Method.GET);
            request.AddParameter("format", "rest");
            request.AddParameter("method", "flickr.photos.search");
            request.AddParameter("api_key", "");
            request.AddParameter("text", q);
            request.AddParameter("format", "json");
            request.AddParameter("nojsoncallback", "1");

            request.AddHeader("Accept", "application/json");

            var result = client.Execute<FlickrResponse>(request);

            return result.Data.Photos.Photo;
        }


        // GET api/photos/5
        [HttpGet("{id}")]
        public ActionResult<FlickrResponse> Get(int id)
        {


            var client = new RestClient("https://api.flickr.com");

            var request = new RestRequest("services/rest", Method.GET);
            request.AddParameter("format", "rest");
            request.AddParameter("method", "flickr.photos.getInfo");
            request.AddParameter("api_key", "");
            request.AddParameter("photo_id", id);
            request.AddParameter("format", "json");
            request.AddParameter("nojsoncallback", "1");

            request.AddHeader("Accept", "application/json");

            var result = client.Execute<FlickrResponse>(request);

            return result.Data;
        }
    }
}
