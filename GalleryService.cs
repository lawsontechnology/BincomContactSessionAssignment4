
namespace APIs___SWAGGER_DOCS;

public class GalleryService : IGalleryService
{
    private readonly IGalleryRepository _galleryRepository;

    public GalleryService(IGalleryRepository galleryRepository)
    {
        _galleryRepository = galleryRepository;
    }
    public async Task<BaseResponse> AddImage(GalleryRequestModel request)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqueFileName = Guid.NewGuid().ToString() + "_" + request.FilePath.FileName;
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await request.FilePath.CopyToAsync(fileStream);  
        }

        var gallery = new Gallery()
        {
            FileName = uniqueFileName,
            FilePath = filePath,
            UploadDate = DateTime.Now,
        };

        await _galleryRepository.AddAsync(gallery);
        await _galleryRepository.SaveChanges();

        return new BaseResponse
        {
            Message = "Image successfully created",
            Success = true,
            Data = new GalleryDto
            {
                FileName = gallery.FileName,
                Id = gallery.Id,
                FilePath = gallery.FilePath,
                UploadDate = gallery.UploadDate
            }
        };
    }


    public async Task<ICollection<BaseResponse>> GetAll()
    {
        List<GalleryDto> galleryDtos = new List<GalleryDto>();
        var gallery = await _galleryRepository.GetAll();

        foreach (var gallerys in gallery)
        {
            var galleryList = new GalleryDto
            {
                FileName = gallerys.FileName,
                Id = gallerys.Id,
                FilePath = gallerys.FilePath,
                UploadDate = gallerys.UploadDate 
            };
            galleryDtos.Add(galleryList);
        }

        var responseList = new List<BaseResponse>();

        if (galleryDtos.Any())
        {
            foreach (var galleryDto in galleryDtos)
            {
                var response = new BaseResponse
                {
                    Success = true,
                    Message = "Gallery item retrieved successfully",
                    Data = galleryDto
                };
                responseList.Add(response);
            }
        }
        else
        {
            var response = new BaseResponse
            {
                Success = false,
                Message = "No gallery items found",
                Data = null
            };
            responseList.Add(response);
        }

        return responseList;
    }

}
