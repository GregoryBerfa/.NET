using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eta.Data;
using Eta.Business;
using System.ServiceModel;

namespace Eta.ServiceWcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode =ConcurrencyMode.Single)]
    public class EtaService : IEtaService
    {

        public void AddReview(Review review)
        {
            var reviewManager = new ReviewManager();
            reviewManager.AddReview(review);
        }

        public List<Review> GetReviews(int trainingId)
        {
            var reviewManager = new ReviewManager();
            return reviewManager.GetReviewsForTraining(trainingId);
        }

        public List<Training> GetTrainings()
        {
            var reviewManager = new ReviewManager();
            return reviewManager.GetTrainings();
        }
    }
}
