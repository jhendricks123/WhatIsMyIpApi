namespace WhatIsMyIpApi
{
    public class OutputType
    {
        private OutputType(string value) => Value = value;
        public string Value { get; private set; }

        public static OutputType Text => new OutputType("");
        public static OutputType Xml => new OutputType("xml");
        public static OutputType Json => new OutputType("json");
        public static OutputType Csv => new OutputType("csv");
    }
}