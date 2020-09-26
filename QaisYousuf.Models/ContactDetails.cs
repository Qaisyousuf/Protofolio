using System;
using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.Models
{
    public class ContactDetails:EntityBase
    {
        public string Title { get; set; }

        public string HomeAddress { get; set; }

        public string CountryName { get; set; }

        public string Moible { get; set; }

        public string Email { get; set; }

        public string SaleEamil { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime WorkingTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime WorkingDateTimeOfWeek { get; set; }


    }
}
