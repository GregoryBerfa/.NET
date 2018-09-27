using EtaRest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EtaRest.WcfService
{
    [ServiceContract]
    public interface IEtaService
    {
        [OperationContract]
        [WebGet(UriTemplate = "trainings")]
        List<Training> GetTrainings();


        [WebGet(UriTemplate = "trainings?json", ResponseFormat = WebMessageFormat.Json)]
        List<Training> GetTrainingsJson();

        [OperationContract]
        [WebGet(UriTemplate = "training/{trainingId}/reviews")]
        List<Review> GetReviews(string trainingId);
        [OperationContract]
        [WebInvoke(UriTemplate ="addreview",Method ="POST")]
        void AddReview(Review review);

        //[WebInvoke(UriTemplate = "deletereview/{id}", Method = "DELETE")]
        //void DeleteReview(string id);
    }
}
