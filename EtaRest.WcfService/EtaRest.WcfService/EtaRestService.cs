using EtaRest.Business;
using EtaRest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EtaRest.WcfService
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class EtaRestService : IEtaService
    {

        public void AddReview(Review review)
        {
            var reviewManager = new ReviewManager();
            reviewManager.AddReview(review);
        }


        public List<Review> GetReviews(string trainingId)
        {
            var reviewManager = new ReviewManager();
            int iTrainingId = 0;
            if(!Int32.TryParse(trainingId, out iTrainingId))
            {
                return null;
            }
            return reviewManager.GetReviewsForTraining(iTrainingId);
        }

        public List<Training> GetTrainings()
        {
            var reviewManager = new ReviewManager();
            return reviewManager.GetTrainings();
        }
        public List<Training> GetTrainingsJson()
        {
            var reviewManager = new ReviewManager();
            return reviewManager.GetTrainings();
        }
    }
}
