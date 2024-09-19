using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace APIs___SWAGGER_DOCS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        [HttpPost("Upload")]
        [OpenApiOperation("Upload An Image", "Upload A New Images")]
        public async Task<IActionResult> Upload(GalleryRequestModel model)
        {
          var gallery = await _galleryService.AddImage(model);
            if(gallery.Success)
            {
                return Ok(gallery);
            }
            return BadRequest();
        }

        [HttpGet("GetAll")]
        [OpenApiOperation("Get All Image", "Retrieving All Images")]
        public async Task<IActionResult> RetrieveAll()
        {
            var galleries = await _galleryService.GetAll();
            return Ok(galleries);
        }
    }
}

