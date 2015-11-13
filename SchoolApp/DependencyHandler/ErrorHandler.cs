using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class ErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            try
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(error));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            if (error is FaultException)
            {
                return;
            }
            var faultException = new FaultException("An Error Occurred");
            var mfault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, mfault, null);
        }
    }
}
