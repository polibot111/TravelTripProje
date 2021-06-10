using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bogus.DataSets;
using TravelTripProje.Models.Project.Entities;

namespace TravelTripProje.Models.Project.DAL
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext>
    {
        Random z = new Random();
        Random d = new Random();
        Random t = new Random();
        Random p = new Random();
        Random h = new Random();
        string[] images = { "https://i.imgyukle.com/2018/10/30/xbMIt.jpg", "https://www.img.gen.tr/images/2018/04/07/manzara-resimleri-3.jpg", "https://fotolifeakademi.com/uploads/2020/04/manzara-ve-doga-fotografciligi.jpg", "https://www.arthenos.com/wp-content/uploads/2017/08/Manzara_fotografciligi_2-696x522.jpg", "https://www.pratikbilgisi.com/upload/stblog/1/36/39/3639medium.jpg", "https://cdn.pixabay.com/photo/2016/10/18/21/22/beach-1751455__340.jpg", "https://cdn.pixabay.com/photo/2015/12/01/20/28/forest-1072828__340.jpg", "https://cdn.pixabay.com/photo/2016/10/22/17/46/mountains-1761292__340.jpg", "https://cdn.pixabay.com/photo/2016/11/06/05/36/lake-1802337__340.jpg", "https://cdn.pixabay.com/photo/2017/05/09/03/46/alberta-2297204__340.jpg", "https://cdn.pixabay.com/photo/2017/02/01/22/02/mountain-landscape-2031539__340.jpg" };
        protected override void Seed(MyContext context)
        {
            Adminss admn = new Adminss();
            admn.Password = "1234";
            admn.UserName = "admin";
            context.Adminss.Add(admn);
            context.SaveChanges();

            AboutUss ab = new AboutUss();
            ab.AboutDescription = new Lorem("tr").Sentence(50);
            ab.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR44YzaiSsL9RYYG7tIs2SHLpEcoprJ7k8oaA&usqp=CAU";
            context.AboutUss.Add(ab);
            context.SaveChanges();

            for (int i = 0; i < 11; i++)
            {
                Blogs bg = new Blogs();
                bg.LayoutBlog = new Bogus.DataSets.Address("tr").City() + " " + new Lorem("tr").Sentence(h.Next(1,3));
                bg.BlogDescription = new Lorem("tr").Sentence(t.Next(250,500));
                bg.BlogImage = images[i];
                bg.BlogPuan = p.Next(50, 100);
                bg.VisitTime = bg.CreatedDate;

                for (int r = 0; r < z.Next(3, 8); r++)
                {
                    Comments cm = new Comments();
                    cm.Commentator = new Name("tr").FirstName();
                    cm.CommentTor = new Lorem("tr").Sentence(d.Next(10, 50));
                    cm.Mail = new Internet("tr").Email();
                    bg.Comments.Add(cm);
                }
                context.Blogs.Add(bg);
                context.SaveChanges();
            }

        }
    }
}