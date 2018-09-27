
using Eta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eta.Business
{
    public class ReviewManager
    {
        List<Training> Trainings = new List<Training>();
        List<Review> Reviews = new List<Review>();

        public ReviewManager()
        {
            Trainings.Add(new Training { Id = 1, Name = "WCF & C#" });
            Trainings.Add(new Training { Id = 2, Name = "LINQ & C#" });
            Trainings.Add(new Training { Id = 3, Name = "EntityFramework & C#" });

            Reviews.Add(new Review { Id = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusm", TrainingId=1 });
            Reviews.Add(new Review { Id = 2, Description = "Sed ut perspiciatis unde omnis iste natu", TrainingId = 1 });
            Reviews.Add(new Review { Id = 3, Description = "o eos et accusamus et iusto odio dignissi", TrainingId = 1 });

            Reviews.Add(new Review { Id = 4, Description = "Temporibus autem quibusdam et aut officiis debitis aut rerum", TrainingId = 2 });
            Reviews.Add(new Review { Id = 5, Description = " Excepteur sint occaecat cupidatat non proident,", TrainingId = 2 });
        }


        public List<Training> GetTrainings()
        {
            //plug access to database here or other business operation
            return Trainings;
        }

        public List<Review> GetReviewsForTraining(int trainingId)
        {
            return Reviews.Where(r=>r.TrainingId == trainingId).ToList();
        }

        public void AddReview(Review review)
        {
            //will not really work as data is not persisted in database
            Reviews.Add(review);
        }
    }
}
