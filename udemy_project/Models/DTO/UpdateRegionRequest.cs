﻿namespace udemy_project.Models.DTO
{
    public class UpdateRegionRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
