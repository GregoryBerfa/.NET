using Eta.ServiceWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Eta.Data;
using System.ServiceModel.Channels;

namespace Eta.ClientManual
{
    public class ProxyEtaService : ClientBase<IEtaService>, IEtaService
    {
        public ProxyEtaService()
        {

        }
        public ProxyEtaService(string endPoint):base(endPoint)
        {

        }
        public ProxyEtaService(Binding binding, string address) : base(binding,new EndpointAddress(address))
        {

        }

        public void AddReview(Review review)
        {
            try
            {
                Channel.AddReview(review);
            }
            catch(FaultException ex)
            {
                // faire qqchose
            }
            catch(CommunicationException ex)
            {
                // faire qqchose
            }
            catch (TimeoutException ex)
            {
                // faire qqchose
            }

        }

        public List<Review> GetReviews(int trainingId)
        {
           return Channel.GetReviews(trainingId);
        }

        public List<Training> GetTrainings()
        {
           return Channel.GetTrainings();
        }
    }
}
