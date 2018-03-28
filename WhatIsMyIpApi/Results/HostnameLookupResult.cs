using System;
using Newtonsoft.Json;

namespace WhatIsMyIpApi.Results
{
    public class HostnameLookupResult : ApiResponseBase
    {
        public override string RawResult { get; set; }
        public override string Status { get; set; }
        public override string ParseError { get; set; }

        public string HostnameOrIp { get; set; }

        public static HostnameLookupResult Parse(string json)
        {
            try
            {
                dynamic jObject = JsonConvert.DeserializeObject(json);
                var result = new HostnameLookupResult()
                {
                    RawResult = json,
                    Status = jObject["host_name"][0].status.ToString(),
                    HostnameOrIp = jObject["host_name"][1].result.ToString()
                };
                return result;
            }
            catch (Exception ex)
            {
                return new HostnameLookupResult
                {
                    ParseError = ex.Message,
                    RawResult = json,
                    Status = json
                };
            }
        }
    }
}