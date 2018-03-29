# WhatIsMyIpApi

The API for WhatIsMyIp.com is relatively simple, but I thought I'd create a basic wrapper for it for simplified use in .NET projects.

Version 1 was limited to only two of the tools available in their API while the current version now implements all tools at the time of publishing.

## Getting Started
First you will need to obtain an API key by registering for a Gold Membership here: https://www.whatismyip.com/membership-options/

Next, click "Generate API Key" here: https://www.whatismyip.com/login-welcome-page/

### Instantiate a WhatIsMyIpClient "proxy"
    var client = new WhatIsMyIpClient("ABCDEF123456789ABCDEF123456789AB");

### Retrieve Current IP Address
    GetIpAddressResponse result = client.GetIpAddress();
    var ip = result.Result;

### Get GeoLocation Information
    Ipv4AddressLookupResponse response = client.Ipv4AddressLookup("8.8.8.8");
    var country = result.Location.Country;
    var region = result.Location.Region;
    var city = result.Location.City;
    var postcode = result.Location.PostCode;
    var isp = result.Location.Isp;
    var timeOffset = result.Location.UtcOffset;
    GeoCoordinate coordinates = result.Location.Coordinates;

### Check Domain Blacklists
    BlackListCheckResult result = client.BlackListCheck("www.google.com");
    bool isBlacklisted = result.BarracudaCentral || result.SpamCop || result.SmapHaus;

### Reverse DNS Lookup
    var result = client.HostnameLookup("8.8.8.8");
    var hostname = result.HostnameOrIp; // If no PTR record is found, the IP used in the lookup will be returned

### Retrieve Whois Information
    var whois = client.Ipv4WhoisLookup.Text;

### Retrieve Server Headers
    var result = client.ServerHeadersCheck("https://www.google.com");
    foreach (var kvp in result.Headers)
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }

### Get User-Agent Information
This doesn't make a lot of sense to include in this library since the user-agent will always be the same (WhatIsMyIpApi <version>). But it's here anyway.
    
    var result = client.UserAgentInfo();
    string userAgent = result.UserAgent;

### Handling Errors
All API responses are derived from the ApiResponseBase class which has boolean property named Success. This will return true if the Status property == "ok". Otherwise it will return false, and you can get more detail by accessing the following properties:

    response.Status // returns the raw status code from the API which is either "ok" or a number from 0 to 6
    response.StatusMessage // returns a descriptive message like "Too many lookups" or "API key is invalid"
    response.RawResult // returns the raw response from the WhatIsMyIP.com API. This library mostly uses JSON formatted output
    response.ParseError // Contains the Exception.Message text in the event the library fails to parse the server response
