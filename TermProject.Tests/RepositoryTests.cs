using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TermProject.Controllers;
using TermProject.Models;
using Xunit;

namespace TermProject.Tests
{
    public class RepositoryTests
    {
        public IRepository Repository = new FakeRepository();

        public RepositoryTests()
        {
            // Fill the empty repository with data for testing
            Repository.AddRestaurantReview(new RestaurantReview
            {
                Name = "McDonald's",
                City = "London",
                Country = "England",
                Rating = 3,
                Comment = "Average"
            });
            
            Repository.AddRestaurantReview(new RestaurantReview
            {
                Name = "KFC",
                City = "Paris",
                Country = "France",
                Rating = 5,
                Comment = "Wicked"
            });

            Repository.AddClassified(new Classified
            {
                Item = "Car",
                Text = "Good condition"
            });

            Repository.AddClassified(new Classified
            {
                Item = "Bike",
                Text = "Poor condition"
            });

            Repository.AddSuccessSecret(new SuccessSecret
            {
                Success = "Money",
                Secret = "Save"
            });

            Repository.AddSuccessSecret(new SuccessSecret
            {
                Success = "Happiness",
                Secret = "Prozac"
            });
        }

        // This test verifies that a restaurant review is added correctly
        [Fact]
        public void AddRestaurantReviewTest()
        {
            // Arrange
            var restaurantReviewController = new RestaurantReviewController(Repository);

            // Act
            restaurantReviewController.Add(new RestaurantReview
            {
                Name = "Peter",
                City = "Rome",
                Country = "Italy",
                Rating = 2,
                Comment = "Boring"
            });

            // Assert
            Assert.Equal("Peter", Repository.RestaurantReviews[^1].Name);
            Assert.Equal("Rome", Repository.RestaurantReviews[^1].City);
            Assert.Equal("Italy", Repository.RestaurantReviews[^1].Country);
            Assert.Equal(2, Repository.RestaurantReviews[^1].Rating);
            Assert.Equal("Boring", Repository.RestaurantReviews[^1].Comment);
        }

        // This test verifies that a classified is added correctly
        [Fact]
        public void AddClassified()
        {
            // Arrange
            var classifiedController = new ClassifiedController(Repository);

            // Act
            classifiedController.Add(new Classified
            {
                Item = "Shirt",
                Text = "Torn"
            });

            // Assert
            Assert.Equal("Shirt", Repository.Classifieds[^1].Item);
            Assert.Equal("Torn", Repository.Classifieds[^1].Text);
        }

        // This test verifies that a success secret is added correctly
        [Fact]
        public void AddSuccessSecret()
        {
            // Arrange
            var successSecretController = new SuccessSecretController(Repository);

            // Act
            successSecretController.Add(new SuccessSecret()
            {
                Success = "Love",
                Secret = "Money"
            });

            // Assert
            Assert.Equal("Love", Repository.SuccessSecrets[^1].Success);
            Assert.Equal("Money", Repository.SuccessSecrets[^1].Secret);
        }

        // This test verifies the search results
        [Fact]
        public void GetRestaurantsByRatingsTest()
        {
            // Arrange
            var restaurantReviewController = new RestaurantReviewController(Repository);

            // Act
            // Get surveys with a ratings of 4 and 5
            var result = (ViewResult)restaurantReviewController.Search(4);
            var rating4 = ((IEnumerable<RestaurantReview>)result.Model).ToList();
            result = (ViewResult)restaurantReviewController.Search(5);
            var rating5 = ((IEnumerable<RestaurantReview>)result.Model).ToList();

            // Assert
            // The restaurants with a rating of 4 should be empty
            Assert.Empty(rating4);
            // There should be only one restaurant of a rating of 5
            Assert.Single(rating5);
            // Check that it is KFC in Paris
            Assert.Equal("KFC", rating5[0].Name);
            Assert.Equal("Paris", rating5[0].City);
        }
    }
}
