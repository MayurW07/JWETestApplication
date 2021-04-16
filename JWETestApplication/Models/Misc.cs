using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWETestApplication.Models
{
    public class ConsumerContext
    {
        public string requesterId { get; set; }
    }

    public class ServiceContext
    {
        public string serviceName { get; set; }
        public string reqRefNum { get; set; }
        public string reqRefTimeStamp { get; set; }
        public string serviceVersionNo { get; set; }
    }

    public class ReqHdr
    {
        public ConsumerContext consumerContext { get; set; }
        public ServiceContext serviceContext { get; set; }
    }

    public class CustDetails
    {
        public string panNumber { get; set; }
    }

    public class ReqBody
    {
        public CustDetails custDetails { get; set; }
    }

    public class PanBasedDeailsReq
    {
        public ReqHdr reqHdr { get; set; }
        public ReqBody reqBody { get; set; }
    }

    public class CustomerDetailRequestModel
    {
        public PanBasedDeailsReq panBasedDeailsReq { get; set; }
    }
}
