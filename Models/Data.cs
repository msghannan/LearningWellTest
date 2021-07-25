using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningWellTest.Models
{
    // Motsvarar "data" i DataFromSCB.json
    public class Data
    {
        // Motsvarar "key" listan i DataFromSCB.json
        public List<string> Key { get; set; }

        // Motsvarar "values" listan i DataFromSCB.json
        public List<string> Values { get; set; }
    }
}