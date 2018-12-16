using Microsoft.AspNetCore.Mvc;
using PhotoFlux.Domain;
using PhotoFlux.Models;
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<IPhotoSearchResult>>> Search([FromQuery]string q, [FromQuery]decimal? latitude, [FromQuery]decimal? longitude, [FromQuery]double? radiusInKm, [FromQuery]string address)
        {
            return (string.IsNullOrWhiteSpace(address))
                ? Ok(await _photoStore.SearchAsync(q, new GeoRegion(latitude, longitude, radiusInKm)))
                : Ok(await _photoStore.SearchAsync(q, address));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IPhotoMetadata>> Get([FromRoute]string id)
        {
            return Ok(await _photoStore.GetPhotoDetailsAsync(id));
        }


    }
}
