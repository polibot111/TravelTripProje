using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Project.Entities
{
    public class Address:BaseEntity
    {
        public string LayoutAdress { get; set; }
        public string Description { get; set; }
        public string AdressOpen { get; set; }
        public string Mail { get; set; }
        public string WhatsApp { get; set; }
        public string Location { get; set; }
    }
}