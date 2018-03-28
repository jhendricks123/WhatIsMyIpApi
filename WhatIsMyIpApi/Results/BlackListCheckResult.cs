using Newtonsoft.Json;
using System;

namespace WhatIsMyIpApi.Results
{
    public class BlackListCheckResult : ApiResponseBase
    {
        public override string RawResult { get; set; }
        public override string Status { get; set; }
        public override string ParseError { get; set; }

        public bool BarracudaCentral { get; set; }
        public bool SpamCop { get; set; }
        public bool SpamHaus { get; set; }

        public static BlackListCheckResult Parse(string json)
        {
            try
            {
                dynamic jObject = JsonConvert.DeserializeObject(json);
                var result = new BlackListCheckResult()
                {
                    RawResult = json,
                    Status = jObject["domain_blacklist"][0].status.ToString(),
                    BarracudaCentral = bool.Parse(jObject["domain_blacklist"][0]["b.barracudacentral.org"].ToString()),
                    SpamCop = bool.Parse(jObject["domain_blacklist"][0]["bl.spamcop.net"].ToString()),
                    SpamHaus = bool.Parse(jObject["domain_blacklist"][0]["sbl-xbl.spamhaus.org"].ToString())
                };
                return result;
            }
            catch (Exception ex)
            {
                return new BlackListCheckResult
                {
                    Status = json,
                    RawResult = json,
                    ParseError = ex.Message
                };
            }
        }
    }
}