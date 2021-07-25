using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LearningWellTest.Models
{
    // All logik och beräkninar finns i denna klass
    public class AllViewModel
    {

        public List<Result> Results { get; set; }
        public List<ElectionResult> ElectionResults { get; set; }


        List<ElectionResult> ElectionResultsList = new List<ElectionResult>();
        List<MaximumPercent> MaximumPercentList = new List<MaximumPercent>();


        string electionResultsPath = HttpContext.Current.Server.MapPath("~/DAL/ElectionResults.json");
        string maximumPercentsPath = HttpContext.Current.Server.MapPath("~/DAL/MaximumPercents.json");


        public AllViewModel()
        {
            var jsonSCBData = File.ReadAllText(HttpContext.Current.Server.MapPath("~/DAL/DataFromSCB.json"));
            Results = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Result>>(jsonSCBData);

            var jsonElectionResults = File.ReadAllText(HttpContext.Current.Server.MapPath("~/DAL/ElectionResults.json"));
            ElectionResults = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ElectionResult>>(jsonElectionResults);
        }


        // Hämtar valresultat för varje stad
        public List<ElectionResult> GetElectionResults()
        {

            // Koden nedan hämtar resultaten från originalfilen: DataFromSCB.json och sätter de i filen: ElectionResults.json
            // för att presentera det på "finare" sätt

            foreach (var result in Results)
            {
                foreach (var data in result.Data)
                {
                    for (int i = 2; i <= data.Key.Count; i++)
                    {
                        var percent = data.Values[0];

                        var values = new ElectionResult
                        {
                            CityCode = data.Key[0],
                            Year = data.Key[1],
                            Percent = percent
                        };

                        ElectionResultsList.Add(values);
                    }
                }
            }

            string output = JsonConvert.SerializeObject(ElectionResultsList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(electionResultsPath, output);

            return ElectionResultsList;
        }


        // Presenterar högsta procent för varje år
        public List<MaximumPercent> GetMaximumPercents()
        {
            GetElectionResults();

            // LINQ kod som beräknar högsta procent för varje år

            var maxPer = from m in ElectionResultsList
                         group m by m.Year into yearGrp
                         let percent = yearGrp.Max(x => x.Percent)
                         select new
                         {
                             Year = yearGrp.Key,
                             City = yearGrp.First(s => s.Percent == percent).CityCode,
                             Percent = percent
                         };


            // Sparar resultatet från LINQ koden ovan i MaimumPercentList som sedan sparas i MaximumPersents.json
            foreach (var p in maxPer)
            {
                var max = new MaximumPercent
                {
                    Year = p.Year,
                    CityCode = p.City,
                    Percent = p.Percent
                };

                MaximumPercentList.Add(max);
            }

            string output = JsonConvert.SerializeObject(MaximumPercentList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(maximumPercentsPath, output);

            return MaximumPercentList;
        }
    }
}