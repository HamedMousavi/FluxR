using Microsoft.AspNetCore.Mvc;
using PhotoFlux.Domain;
using System.Collections.Generic;


namespace PhotoFlux.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {

        private readonly IPhotoStore _photoStore;


        public PhotosController(IPhotoStore photoStore)
        {
            _photoStore = photoStore;
        }


        // GET api/photos/keyword
        [HttpGet("{q}")]
        public ActionResult<IEnumerable<IPhoto>> Search([FromQuery]string q)
        {
            return Ok(_photoStore.Search(q));
        }


        // GET api/photos/5
        [HttpGet("{id}")]
        public ActionResult<IPhotoMetadata> Get([FromRoute]string id)
        {
            return Ok(_photoStore.GetPhotoDetails(id));
        }


    }
}
