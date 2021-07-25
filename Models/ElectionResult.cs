using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningWellTest.Models
{
    // Motsvarar ElectionResults.json
    // Denna klass skapades för att spara valresultat i "finare" ordning är original json file: DataFromSCB.json
    public class ElectionResult
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string Year { get; set; }
        public string Percent { get; set; }
    }
}