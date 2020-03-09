using System.Collections.Generic;

namespace TermProject.Models
{
    public class FakeRepository : IRepository
    {
        private readonly List<RestaurantReview> _restaurantReviews = new List<RestaurantReview>();
        private readonly List<Classified> _classifieds = new List<Classified>();
        private readonly List<SuccessSecret> _successSecrets = new List<SuccessSecret>();

        public List<RestaurantReview> RestaurantReviews => _restaurantReviews;
        public List<Classified> Classifieds => _classifieds;
        public List<SuccessSecret> SuccessSecrets => _successSecrets;

        public void AddRestaurantReview(RestaurantReview restaurantReview) => RestaurantReviews.Add(restaurantReview);
        public void AddClassified(Classified classified) => Classifieds.Add(classified);
        public void AddSuccessSecret(SuccessSecret successSecret) => SuccessSecrets.Add(successSecret);
    }
}
