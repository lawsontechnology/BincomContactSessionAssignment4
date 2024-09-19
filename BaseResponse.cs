namespace APIs___SWAGGER_DOCS;

public record BaseResponse
{
   public bool Success { get; set; }
   public string? Message { get; set; }
   public GalleryDto? Data { get; set; }
}
