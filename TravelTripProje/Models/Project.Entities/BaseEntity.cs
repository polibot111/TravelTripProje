using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelTripProje.Models.Enums;

namespace TravelTripProje.Models.Project.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Modification { get; set; }
        public DateTime? DeleteTime { get; set; }

        public Status Status{ get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = Status.Active;
        }
    }
}