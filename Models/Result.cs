using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningWellTest.Models
{
    // Result klassen används för att motsvara ordningen i originalfilen: DataFromSCB.json
    public class Result
    {
        public List<Columns> Columns { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Data> Data { get; set; }
    }
}