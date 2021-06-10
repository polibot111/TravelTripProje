using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Project.Entities
{
    public class Blogs:BaseEntity
    {
        public Blogs()
        {
            Comments = new List<Comments>();
        }
        public string LayoutBlog { get; set; }
        public string BlogImage { get; set; }
        public string BlogDescription { get; set; }
        public  int BlogPuan { get; set; }

        public DateTime? VisitTime { get; set; }

        //R.L
        public virtual List<Comments> Comments { get; set; }
    }
}