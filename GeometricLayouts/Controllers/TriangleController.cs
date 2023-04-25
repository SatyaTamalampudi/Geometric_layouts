using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeometricLayouts.Domain;
using GeometricLayouts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeometricLayouts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        private readonly ILogger<GridController> _logger;
        private readonly ICalculator _gridCalculator;

        public TriangleController(ILogger<GridController> logger, ICalculator gridCalculator)
        {
            _logger = logger;
            _gridCalculator = gridCalculator;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<Coordinates>))]
        public List<Coordinates> Post([FromBody] Grid grid)
        {
            List<Coordinates> coordinates;
            try
            {
                coordinates = _gridCalculator.GetTriangleVertices(grid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while calling grid calculator");
                throw;
            }
            return coordinates;
        }
    }
}
