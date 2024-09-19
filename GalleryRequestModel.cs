namespace APIs___SWAGGER_DOCS;
public class GalleryRequestModel
{
    public IFormFile FilePath { get; set; } = null!;
}

public class GalleryDto
{
    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public DateTime UploadDate { get; set; }
}
