# WhatIsMyIpApi

The API for WhatIsMyIp.com is extremely simple, but I thought I'd create a basic wrapper for it. Currently it supports the ip.php tool, and the ip-address-lookup.php tool.

That's all I need, but if you feel the need to add to it, please send a PR!

## Getting Started

Retrieving your current IP is as simple as...

    var ip = WhatIsMyIp.GetIp("APIKEY");

Retrieving the results of an IP lookup which includes location data, use...

    var lookup = WhatIsMyIp.GetIpAddressLookup("APIKEY", "8.8.8.8", OutputType.Text)

