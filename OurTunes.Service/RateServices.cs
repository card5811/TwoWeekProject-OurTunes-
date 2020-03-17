using OurTunes.Data;
using OurTunes.Model.SongRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurTunes.Service
{
    public class RateServices
    {
         public bool RateASong(RateCreate model)
         {

             SongRating addRate = new SongRating();
             addRate.SongId = model.SongId;
             addRate.SongRate = model.MyRating;

             using (var context = new ApplicationDbContext())
             {
                 context.SongRatings.Add(addRate);
                 context.SaveChanges();
                 SongServices myRate = new SongServices();
                 myRate.AverageRating(model.SongId);
                 return context.SaveChanges() == 0;
             };
         }

        public IOrderedEnumerable<Song> GetHighToLowList()
        {
            using(var context = new ApplicationDbContext())
            {
               var rateList = context.Songs.Where(j => j.SongId == j.SongId).ToList().OrderByDescending(rate => rate.RateAdverage);
                return rateList;
            }
        }
    }
}
