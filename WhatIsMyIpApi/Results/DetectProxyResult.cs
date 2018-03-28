using System;
using Newtonsoft.Json;

namespace WhatIsMyIpApi.Results
{
    public class DetectProxyResult : ApiResponseBase
    {
        public override string RawResult { get; set; }
        public override string Status { get; set; }
        public override string ParseError { get; set; }
        public string Ip { get; set; }
        public bool IsProxy { get; set; }
        public string ProxyType { get; set; }
        public bool IsTorNode { get; set; }

        public static DetectProxyResult Parse(string json)
        {
            try
            {
                dynamic jObject = JsonConvert.DeserializeObject(json);
                var result = new DetectProxyResult()
                {
                    RawResult = json,
                    Status = jObject["proxy-check"][0].status,
                    Ip = jObject["proxy-check"][1].ip,
                    IsProxy = jObject["proxy-check"][1].ip.Equals("yes"),
                    ProxyType = jObject["proxy-check"][1].proxy_type,
                    IsTorNode = jObject["proxy-check"][1].tor_node.Equals("yes")
                };
                return result;
            }
            catch (Exception ex)
            {
                return new DetectProxyResult
                {
                    Status = json,
                    RawResult = json,
                    ParseError = ex.Message
                };
            }
        }
    }
}