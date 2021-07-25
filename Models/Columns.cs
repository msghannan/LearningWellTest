using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningWellTest.Models
{
    // Motsvarar "columns" i DataFromSCB.json
    public class Columns
    {
        public string Code { get; set; }
        public string Text  { get; set; }
        public string Type  { get; set; }
    }
}