using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningWellTest.Models
{
    // Motsvarar "key" listan i DataFromSCB.json
    public class Key
    {
        // Motsvarar första element i "key" listan i DataFromSCB.json, Code refererar till staden
        public string Code { get; set; }

        // Motsvarar andra element i "key" listan i DataFromSCB.json, Year refererar till valåret
        public string Year { get; set; }
    }
}