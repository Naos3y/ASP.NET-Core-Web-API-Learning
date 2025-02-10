namespace udemy_project.Models.DTO
{
    public class CreateRegionRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
