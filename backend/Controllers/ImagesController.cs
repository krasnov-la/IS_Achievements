using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    IImageService _imageService;
    public ImagesController(IImageService imageService)
    {
        _imageService = imageService;
    }

    /// <summary>
    /// Retrieves an image by name.
    /// </summary>
    /// <param name="imgName">The name of the image.</param>
    /// <response code="200">Returns the image file.</response>
    /// <response code="400">If the file is not found.</response>
    /// <remarks>
    /// This method retrieves an image file based on the provided image name.
    /// Example request:
    /// 
    ///     GET /Images/sample.jpg
    /// </remarks>
    [HttpGet("{imgName}")]
    public IActionResult GetImage(string imgName)
    {
        var file = _imageService.Get(imgName);
        if (file is null) return BadRequest("File not found");
        return Ok(file);
    }

    /// <summary>
    /// Uploads a new image.
    /// </summary>
    /// <param name="img">The image file to upload.</param>
    /// <response code="200">If the upload is successful.</response>
    /// <response code="400">If the upload fails.</response>
    /// <remarks>
    /// This method uploads a new image file.
    /// Example request:
    /// 
    ///     POST /Images
    ///     { file: (image file) }
    /// </remarks>
    [HttpPost]
    [Authorize]
    public IActionResult UploadImage(IFormFile img)
    {
        return Ok(_imageService.Upload(img));
    }

    /// <summary>
    /// Deletes an image by name.
    /// </summary>
    /// <param name="imgName">The name of the image to delete.</param>
    /// <response code="200">If the deletion is successful.</response>
    /// <response code="400">If the file is not found.</response>
    /// <remarks>
    /// This method deletes an image file based on the provided image name.
    /// Example request:
    /// 
    ///     DELETE /Images/sample.jpg
    /// </remarks>
    [HttpDelete("{imgName}")]
    [Authorize]
    //TODO ownership check
    public IActionResult DeleteImage(string imgName)
    {
        _imageService.Delete(imgName);
        return Ok();
    }
}