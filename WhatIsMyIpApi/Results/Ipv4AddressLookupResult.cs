using Newtonsoft.Json;
using System;
using System.Device.Location;

namespace WhatIsMyIpApi.Results
{
    public class Ipv4AddressLookupResult : ApiResponseBase
    {
        public override string RawResult { get; set; }
        public override string Status { get; set; }
        public override string ParseError { get; set; }
        public string Ip { get; set; }
        public GeoLocationData Location { get; set; }

        public static Ipv4AddressLookupResult Parse(string json)
        {
            try
            {
                dynamic jObject = JsonConvert.DeserializeObject(json);
                var result = new Ipv4AddressLookupResult()
                {
                    RawResult = json,
                    Status = jObject["ip_address_lookup"][0].status.ToString(),
                    Ip = jObject["ip_address_lookup"][1].ip.ToString(),
                    Location = new GeoLocationData()
                    {
                        Country = jObject["ip_address_lookup"][1].country.ToString(),
                        City = jObject["ip_address_lookup"][1].city.ToString(),
                        Region = jObject["ip_address_lookup"][1].region.ToString(),
                        Isp = jObject["ip_address_lookup"][1].isp.ToString(),
                        PostCode = jObject["ip_address_lookup"][1].postalcode.ToString(),
                        UtcOffset = jObject["ip_address_lookup"][1].time.ToString(),
                        Coordinates = new GeoCoordinate(double.Parse(jObject["ip_address_lookup"][1].latitude.ToString()), double.Parse(jObject["ip_address_lookup"][1].longitude.ToString()))
                    }
                };
                return result;
            }
            catch (Exception ex)
            {
                return new Ipv4AddressLookupResult
                {
                    Status = json,
                    RawResult = json,
                    ParseError = ex.Message
                };
            }
        }
    }
}