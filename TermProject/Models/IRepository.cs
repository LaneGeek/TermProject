using System.Collections.Generic;

namespace TermProject.Models
{
    public interface IRepository
    {
        List<RestaurantReview> RestaurantReviews { get; }
        List<Classified> Classifieds { get; }
        List<SuccessSecret> SuccessSecrets { get; }

        void AddRestaurantReview(RestaurantReview restaurantReview);
        void AddClassified(Classified classified);
        void AddSuccessSecret(SuccessSecret successSecret);
    }
}
