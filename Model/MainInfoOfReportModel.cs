using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialTestTracker.Model
{
    public class MainInfoOfReportModel
    {
        /// <summary>
        /// First and second name of laborant
        /// </summary>
        public string FirstAndSecondName { get; set; }

        /// <summary>
        /// Number of protocol
        /// </summary>
        public string ProtocolNumber { get; set; }

        /// <summary>
        /// Type Material. TODO: Use Enum
        /// </summary>
        public string Material { get; set; }

        // "Показники"
        public string Indicators { get; set; }

        /// <summary>
        /// Customer
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// Number of Contract 
        /// </summary>
        public string NumberOfContractWithCustomer { get; set; }

        /// <summary>
        /// Number of Contract 
        /// </summary>
        public DateTime Date { get; set; }

    }
}
