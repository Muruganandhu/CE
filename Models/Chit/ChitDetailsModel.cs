using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChitEngine.Models.Chit
{
    public class ChitDetailsModel
    {
        public decimal ChitId { get; set; }
        public String ChitName { get; set; }
        public string ChitMonth { get; set; }
        public decimal ChitAmount { get; set; }
        public decimal ChitBade { get; set; }
        public decimal PayPerHead { get; set; }
        public decimal BeetAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public String CustomerName { get; set; }

    }
}