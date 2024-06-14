using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    IImageService _imageService;
    public ImageController(IImageService imageService)
    {   
        _imageService = imageService;
    }

    [HttpGet("{imgName}")]
    public IActionResult GetImage(string imgName)
    {
        var file = _imageService.Get(imgName);
        if (file is null) return BadRequest("File not found");
        return Ok(file);
    }

    [HttpPost("[action]")]
    [Authorize]
    public IActionResult UploadImage(IFormFile img)
    {
        return Ok(_imageService.Upload(img));
    }

    [HttpDelete("{imgName}")]
    [Authorize]
    //TODO ownership check
    public IActionResult DeleteImage(string imgName)
    {
        _imageService.Delete(imgName);
        return Ok();
    }
}