namespace Services;

public interface IImageService
{
    public string Upload(IFormFile file);
    public FileStream? Get(string fileName);
    public void Delete(string fileName);
}