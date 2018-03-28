using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WhatIsMyIpApi.Results;

namespace WhatIsMyIpApi
{
    /// <summary>
    /// Instantiate a client with your WhatIsMyIp.com API key and call any method you need. 
    /// The client encapsulates the API calls and parses the results into strongly typed objects to simplify use.
    /// </summary>
    public class WhatIsMyIpClient
    {
        private readonly string _apiKey;
        private const string ApiBaseUri = "https://api.whatismyip.com";

        public WhatIsMyIpClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public GetIpAddressResult GetIpAddress()
        {
            return GetIpAddressAsync().Result;
        }

        public async Task<GetIpAddressResult> GetIpAddressAsync()
        {
            var uri = new Uri($"{ApiBaseUri}/ip.php?key={_apiKey}&output=json");
            var json = await SendApiQuery(uri);
            return GetIpAddressResult.Parse(json);
        }

        public DetectProxyResult DetectProxy()
        {
            return DetectProxyAsync().Result;
        }

        public async Task<DetectProxyResult> DetectProxyAsync()
        {
            var uri = new Uri($"{ApiBaseUri}/proxy.php?key={_apiKey}&output=json");
            var json = await SendApiQuery(uri);
            return DetectProxyResult.Parse(json);
        }

        public Ipv4AddressLookupResult Ipv4AddressLookup(string address)
        {
            return Ipv4AddressLookupAsync(address).Result;
        }

        public async Task<Ipv4AddressLookupResult> Ipv4AddressLookupAsync(string address)
        {
            var uri = new Uri($"{ApiBaseUri}/ip-address-lookup.php?key={_apiKey}&input={address}&output=json");
            var json = await SendApiQuery(uri);
            return Ipv4AddressLookupResult.Parse(json);
        }

        public BlackListCheckResult BlackListCheck(string address)
        {
            return BlackListCheckAsync(address).Result;
        }

        public async Task<BlackListCheckResult> BlackListCheckAsync(string address)
        {
            var uri = new Uri($"{ApiBaseUri}/domain-black-list.php?key={_apiKey}&input={address}&output=json");
            var json = await SendApiQuery(uri);
            return BlackListCheckResult.Parse(json);
        }

        public HostnameLookupResult HostnameLookup(string address)
        {
            return HostnameLookupAsync(address).Result;
        }

        public async Task<HostnameLookupResult> HostnameLookupAsync(string address)
        {
            var uri = new Uri($"{ApiBaseUri}/host-name.php?key={_apiKey}&input={address}&output=json");
            var json = await SendApiQuery(uri);
            return HostnameLookupResult.Parse(json);
        }

        public Ipv4WhoisLookupResult Ipv4WhoisLookup(string address)
        {
            return Ipv4WhoisLookupAsync(address).Result;
        }

        public async Task<Ipv4WhoisLookupResult> Ipv4WhoisLookupAsync(string address)
        {
            var uri = new Uri($"{ApiBaseUri}/whois.php?key={_apiKey}&input={address}");
            var result = await SendApiQuery(uri);
            return Ipv4WhoisLookupResult.Parse(result);
        }

        public ServerHeadersCheckResult ServerHeadersCheck(string url)
        {
            return ServerHeadersCheckAsync(url).Result;
        }

        public async Task<ServerHeadersCheckResult> ServerHeadersCheckAsync(string url)
        {
            var uri = new Uri($"{ApiBaseUri}/server-headers.php?key={_apiKey}&input={url}&output=json");
            var result = await SendApiQuery(uri);
            return ServerHeadersCheckResult.Parse(result);
        }

        public UserAgentInfoResult UserAgentInfo()
        {
            return UserAgentInfoAsync().Result;
        }

        public async Task<UserAgentInfoResult> UserAgentInfoAsync()
        {
            var uri = new Uri($"{ApiBaseUri}/user-agent.php?key={_apiKey}&output=json");
            var result = await SendApiQuery(uri);
            return UserAgentInfoResult.Parse(result);
        }

        private static async Task<string> SendApiQuery(Uri uri)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "WhatIsMyIpApi " + Assembly.GetExecutingAssembly().GetName().Version);
                return await client.DownloadStringTaskAsync(uri);
            }
        }
    }
}
