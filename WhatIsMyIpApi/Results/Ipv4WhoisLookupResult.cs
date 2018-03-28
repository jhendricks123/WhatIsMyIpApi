namespace WhatIsMyIpApi.Results
{
    public class Ipv4WhoisLookupResult : ApiResponseBase
    {
        public override string RawResult { get; set; }
        public override string Status { get; set; }
        public override string ParseError { get; set; }

        public string Text { get; set; }

        public static Ipv4WhoisLookupResult Parse(string result)
        {
            if (result != null && result.Length > 2)
            {
                return new Ipv4WhoisLookupResult
                {
                    Status = "ok",
                    RawResult = result,
                    Text = result
                };
            }

            return new Ipv4WhoisLookupResult
            {
                Status = result,
                RawResult = result
            };
        }
    }
}