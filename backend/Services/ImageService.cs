
namespace Services;

public class ImageService : IImageService
{
    string _imagesPath;
    public ImageService(IWebHostEnvironment hostEnvironment)
    {
        _imagesPath = Path.Combine(hostEnvironment.ContentRootPath, "images");
        if (!Directory.Exists(_imagesPath))
            Directory.CreateDirectory(_imagesPath);
    }
    public void Delete(string fileName)
    {
        var path = Path.Combine(_imagesPath, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        return;
    }

    public FileStream? Get(string fileName)
    {
        try 
        {
            var file = new FileStream(Path.Combine(_imagesPath, fileName), FileMode.Open);
            return file;
        }
        catch
        {
            return null;
        }
    }

    public string Upload(IFormFile file)
    {
        if (file is null) throw new ArgumentException("FILEEE");
        var imageId = Guid.NewGuid();
        var newName = imageId.ToString() + Path.GetExtension(file.FileName);
        using (var fStream = new FileStream(Path.Combine(_imagesPath, newName), FileMode.Create))
        {
            file.CopyTo(fStream);
        }
        return newName;
    }
}