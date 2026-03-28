using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogiTrack.TrackingService.Controllers
{
    [ApiController]
    [Route("api/tracking")]
    public class TrackingController : ControllerBase
    {
        [HttpGet("gps")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetGpsHistory()
        {
            var data = new
            {
                TruckId = "TRK102",
                Location = "Delhi",
                Speed = "60 km/h"
            };

            return Ok(data);
        }
    }
}