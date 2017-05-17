using System;
using System.Net;
using System.Threading.Tasks;

namespace WhatIsMyIpApi
{
    public static class WhatIsMyIp
    {
        private const string GetIpApiString = "http://api.whatismyip.com/ip.php?key={0}";
        private const string GetIpAddressLookupApiString = "http://api.whatismyip.com/ip-address-lookup.php?key={0}&input={1}&output={2}";

        public static string GetIp(string apiKey)
        {
            return GetIpAsync(apiKey).Result;
        }

        public static async Task<string> GetIpAsync(string apiKey)
        {
            using (var client = new WebClient())
                return await client.DownloadStringTaskAsync(new Uri(string.Format(GetIpApiString, apiKey)));
        }

        public static string GetIpAddressLookup(string apiKey, string ip, OutputType outputType)
        {
            return GetIpAddressLookupAsync(apiKey, ip, outputType).Result;
        }
        
        public static async Task<string> GetIpAddressLookupAsync(string apiKey, string ip, OutputType outputType)
        {
            using (var client = new WebClient())
                return await client.DownloadStringTaskAsync(new Uri(string.Format(GetIpAddressLookupApiString, apiKey, ip, outputType.Value)));
        }
    }
}
