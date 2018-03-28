using Newtonsoft.Json;
using System;

namespace WhatIsMyIpApi.Results
{
    public class UserAgentInfoResult : ApiResponseBase
    {
        public override string RawResult { get; set; }
        public override string Status { get; set; }
        public override string ParseError { get; set; }

        public string UserAgent { get; set; }

        public static UserAgentInfoResult Parse(string json)
        {
            try
            {
                dynamic jObject = JsonConvert.DeserializeObject(json);
                var result = new UserAgentInfoResult()
                {
                    RawResult = json,
                    Status = jObject["user_agent"][0].status.ToString(),
                    UserAgent = jObject["user_agent"][1].result.ToString()
                };
                return result;
            }
            catch (Exception ex)
            {
                return new UserAgentInfoResult
                {
                    ParseError = ex.Message,
                    RawResult = json,
                    Status = json
                };
            }
        }
    }
}