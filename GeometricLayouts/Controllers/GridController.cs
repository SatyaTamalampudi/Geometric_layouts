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
    public class GridController : ControllerBase
    {
        private readonly ILogger<GridController> _logger;
        ICalculator _gridCalculator;

        public GridController(ILogger<GridController> logger, ICalculator gridCalculator)
        {
            _logger = logger;
            _gridCalculator = gridCalculator;
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Grid))]
        public Grid Post([FromBody] Triangle traingle)
        {
            Grid grid;
            try
            {
                grid = _gridCalculator.GetTriangleLocation(traingle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while calling grid calculator");
                throw;
            }
            return grid;
        }
    }
}
