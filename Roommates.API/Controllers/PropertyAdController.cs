using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roommates.API.Domain.Models;
using Roommates.API.Domain.Services;
using Roommates.API.Extensions;
using Roommates.API.Resource;
using Swashbuckle.AspNetCore.Annotations;

namespace Roommates.API.Controllers
{
    [Produces("application/json")]
    [Route("api/properties/{propertyId}/ads")]
    [ApiController]
    public class PropertyAdController : ControllerBase
    {
        private readonly IAdService _adService;
        private readonly IMapper _mapper;

        public PropertyAdController(IAdService adService, IMapper mapper)
        {
            _adService = adService;
            _mapper = mapper;
        }

        [SwaggerOperation(
           Summary = "List ads by property",
           Description = "List of ads for an specific property",
           OperationId = "ListAdByProperty",
           Tags = new[] { "ads" }
           )]
        [HttpGet]
        public async Task<IEnumerable<AdResource>> GetAllByPropertyIdAsync(int propertyId)
        {
            var ads = await _adService.ListByPropertyIdAsync(propertyId);
            var resources = _mapper.Map<IEnumerable<Ad>, IEnumerable<AdResource>>(ads);
            return resources;
        }
        
        
    }
}
