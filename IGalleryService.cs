namespace APIs___SWAGGER_DOCS;
public interface IGalleryService 
{
    Task<BaseResponse> AddImage(GalleryRequestModel request);
    Task<ICollection<BaseResponse>> GetAll();
}
