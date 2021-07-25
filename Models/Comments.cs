using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningWellTest.Models
{
    // Motsvarar "comments" i DataFromSCB.json
    public class Comments
    {
        public string Variable { get; set; }
        public string Value { get; set; }
        public string Comment { get; set; }
    }
}