using convertirdor_imagenes.Class;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace convertirdor_imagenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        // POST api/<ImagesController>
        [HttpPost("convert-img")]
        public async Task<string> SaveImg([FromForm] UploadImgApi file )
        {
            var ruta = String.Empty;
            if (file.File.Length > 0)
            {
                var newFileName = Guid.NewGuid().ToString() + file.File.FileName;
                ruta = $"Images/{newFileName}";
                using(var stream = new FileStream(ruta, FileMode.Create))
                {
                    await file.File.CopyToAsync(stream);
                }
            }
            return ruta;
        }

    }
}
