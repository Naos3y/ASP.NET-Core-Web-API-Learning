namespace udemy_project.Models.Domain
{
    public class Region
    {
        // Guid - identificador unico 
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        // ? - Nullable -> permite que tipos de valor aceitem null
        public string? RegionImageUrl { get; set; }
    }
}
