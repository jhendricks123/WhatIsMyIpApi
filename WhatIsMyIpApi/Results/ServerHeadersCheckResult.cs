using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace WhatIsMyIpApi.Results
{
    public class ServerHeadersCheckResult : ApiResponseBase
    {
        public override string RawResult { get; set; }
        public override string Status { get; set; }
        public override string ParseError { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public static ServerHeadersCheckResult Parse(string json)
        {
            try
            {
                dynamic jObject = JsonConvert.DeserializeObject(json);
                var result = new ServerHeadersCheckResult
                {
                    RawResult = json,
                    Status = jObject["server_headers"].status.ToString(),
                    Headers = new Dictionary<string, string>()
                };
                foreach (JProperty prop in jObject["server_headers"].results)
                {
                    result.Headers.Add(prop.Name, prop.Value.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                return new ServerHeadersCheckResult
                {
                    Status = json,
                    RawResult = json,
                    ParseError = ex.Message
                };
            }
        }
    }
}