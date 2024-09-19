
namespace APIs___SWAGGER_DOCS;
public class GalleryRepository : IGalleryRepository
{
    private ApplicationDBContext _dbContext;
    public GalleryRepository( ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Gallery> AddAsync(Gallery gallery)
    {
       await _dbContext.Galleries.AddAsync(gallery);
        return gallery;

    }

    public async Task<ICollection<Gallery>> GetAll()
    {
        return _dbContext.Galleries.ToList();
    }

    public async Task<int> SaveChanges()
    {
      return await _dbContext.SaveChangesAsync();
    }
}
