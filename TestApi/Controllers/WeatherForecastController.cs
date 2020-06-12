using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JHC.DataManager;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private DapperClient mysql;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IDapperClientFactory dapperFactory)
        {
            _logger = logger;
            System.Console.WriteLine(dapperFactory);
            mysql = dapperFactory.GetClient("mysql1");
        }

        [HttpGet]
        public Object Get()
        {
            var result = mysql.Query<dynamic>("select * from user");
            return Ok(result);
        }
    }
}
