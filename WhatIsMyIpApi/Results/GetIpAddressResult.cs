using System;
using Newtonsoft.Json;

namespace WhatIsMyIpApi.Results
{
    public class GetIpAddressResult : ApiResponseBase
    {
        public override string RawResult { get; set; }
        public override string Status { get; set; }
        public override string ParseError { get; set; }
        public string Result { get; set; }
        
        public static GetIpAddressResult Parse(string json)
        {
            try
            {
                dynamic jObject = JsonConvert.DeserializeObject(json);
                var result = new GetIpAddressResult()
                {
                    RawResult = json,
                    Status = jObject.ip_address[0].status,
                    Result = jObject.ip_address[1].result
                };
                return result;
            }
            catch (Exception ex)
            {
                return new GetIpAddressResult
                {
                    Status = json,
                    RawResult = json,
                    ParseError = ex.Message
                };
            }
        }
    }
}