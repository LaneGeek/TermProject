using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context) => _context = context;

        public List<RestaurantReview> RestaurantReviews => _context.RestaurantReviews.ToList();
        public List<Classified> Classifieds => _context.Classifieds.ToList();
        public List<SuccessSecret> SuccessSecrets => _context.SuccessSecrets.ToList();

        public void AddRestaurantReview(RestaurantReview restaurantReview)
        {
            _context.RestaurantReviews.Add(restaurantReview);
            _context.SaveChanges();
        }

        public void AddClassified(Classified classified)
        {
            _context.Classifieds.Add(classified);
            _context.SaveChanges();
        }

        public void AddSuccessSecret(SuccessSecret successSecret)
        {
            _context.SuccessSecrets.Add(successSecret);
            _context.SaveChanges();
        }
    }
}
