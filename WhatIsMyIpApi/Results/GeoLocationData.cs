using System.Device.Location;

namespace WhatIsMyIpApi.Results
{
    public class GeoLocationData
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Isp { get; set; }
        public string UtcOffset { get; set; }
        public GeoCoordinate Coordinates { get; set; }
    }
}