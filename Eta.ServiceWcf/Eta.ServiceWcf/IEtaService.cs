using Eta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Eta.ServiceWcf
{
    [ServiceContract]
    public interface IEtaService
    {
        [OperationContract]
        List<Training> GetTrainings();
        [OperationContract]
        List<Review> GetReviews(int trainingId);
        [OperationContract]
        void AddReview(Review review);
    }
}
