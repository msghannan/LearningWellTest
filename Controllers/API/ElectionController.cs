using LearningWellTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LearningWellTest.Controllers.API
{
    // Tillåter CORS för olika frontend 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]/[action]")]


    public class ElectionController : ApiController
    {
        AllViewModel allViewModel = new AllViewModel();

        // Hämtar all data från originalfilen: DataFromSCB.json
        [HttpGet]
        [Route("API/Election/GetDataFromSCB/")]
        public IHttpActionResult GetDataFromSCB()
        {
            var SCBData = allViewModel.Results.ToList();

            return Ok(SCBData);
        }


        // Hämtar valresultat från filen ElectionResults.json
        [Route("API/Election/GetElectionResults/")]
        [HttpGet]
        public IHttpActionResult GetElectionResults()
        {
            var results = allViewModel.GetElectionResults();

            return Ok(results);
        }


        // Hämtar högsta procent för varje år från filen MaximumPersents.json
        [Route("API/Election/GetMaximumPercents/")]
        [HttpGet]
        public IHttpActionResult GetMaximumPercents()
        {
            var maximumPercent = allViewModel.GetMaximumPercents();

            return Ok(maximumPercent);
        }

    }
}
