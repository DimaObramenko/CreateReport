using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialTestTracker.Model
{
    public class MainInfoOfReportModel
    {
        public string FirstAndSecondName { get; set; }
        public string ProtocolNumber { get; set; }
        public string Material { get; set; }
        public string Indicators { get; set; }
        public string Customer { get; set; }
        public string NumberOfContractWithCustomer { get; set; }
        public DateTime Date { get; set; }

    }
}
