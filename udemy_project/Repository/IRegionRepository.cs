using udemy_project.Models.Domain;

namespace udemy_project.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreateRegionAsync(Region region);
        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);
    }
}
