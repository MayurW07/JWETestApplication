using System;
using System.Collections.Generic;
using System.ComponentModel;
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


    public class Recipient
    {
        public string encrypted_key { get; set; }
    }

    public class JWEResponse
    {
        public string ciphertext { get; set; }
        public string @protected { get; set; }
        public string iv { get; set; }
        public string tag { get; set; }
        public List<Recipient> recipients { get; set; }
    }


    //public class JWEResponse
    //{
    //    public string ciphertext { get; set; }
    //    public string Protected { get; set; }
    //    public string iv { get; set; }
    //    public string tag { get; set; }
    //    public Header header { get; set; }
    //    public string encrypted_key { get; set; }
    //}

    //public class Header
    //{
    //    public string alg { get; set; }
    //}

}
