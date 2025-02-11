using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using udemy_project.Data;
using udemy_project.Models.Domain;
using udemy_project.Models.DTO;
using udemy_project.Repository;

namespace udemy_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase {
        private readonly WalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(WalksDbContext walksDbContext, 
            IRegionRepository regionRepository,
            IMapper mapper)
        {
            this.dbContext = walksDbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // get data from db
            var regionsDomain = await regionRepository.GetAllAsync();

            // map domain models to dto
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            // return dtos
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            // Find apenas pode ser utilizado com a PK
            // return Ok(dbContext.Regions.Find(id));

            // FirstOrDefault pode não está limitado à PK
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null) 
                return NotFound();

            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] CreateRegionRequest addRegionDto)
        {
            // map dto to domain model
            var regionDomainModel = mapper.Map<Region>(addRegionDto);

            // use domain model to create region
            regionDomainModel = await regionRepository.CreateRegionAsync(regionDomainModel);

            // map domain model back to dto
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id}, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionDto)
        {
            var regionDomainModel = mapper.Map<Region>(updateRegionDto);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
                return NotFound();

            // convert domain to dto
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
                return NotFound();

            return Ok();
        }

    }
}
