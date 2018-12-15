using Microsoft.AspNetCore.Mvc;
using PhotoFlux.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;


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
        public async Task<ActionResult<IEnumerable<IPhotoSearchResult>>> Search([FromQuery]string q)
        {
            return Ok(await _photoStore.SearchAsync(q));
        }


        // GET api/photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IPhotoMetadata>> Get([FromRoute]string id)
        {
            return Ok(await _photoStore.GetPhotoDetailsAsync(id));
        }


    }
}
