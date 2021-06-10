using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Project.Entities
{
    public class Comments:BaseEntity
    {
        public string Commentator { get; set; }
        public string Mail { get; set; }
        public string CommentTor { get; set; }
        public int BlogID { get; set; }
        //R.L
        public virtual Blogs Blog { get; set; }
    }
}