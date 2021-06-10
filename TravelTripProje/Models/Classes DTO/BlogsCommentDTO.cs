using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelTripProje.Models.Project.Entities;

namespace TravelTripProje.Models.Classes_DTO
{
    public class BlogsCommentDTO
    {
        public List<Comments> Comments { get; set; }
        public List<Blogs> Blogs { get; set; }
        public List<Blogs> LastBlogs { get; set; }
    }
}