using System;
using System.Collections.Generic;

namespace WhatIsMyIpApi.Results
{
    public abstract class ApiResponseBase
    {
        public bool Success => Status == "ok";
        public abstract string RawResult { get; set; }
        public abstract string Status { get; set; }
        public abstract string ParseError { get; set; }
        public string StatusMessage => StatusMessages.ContainsKey(Status) ? StatusMessages[Status] : StatusMessages["unknown"];

        internal static readonly Dictionary<string, string> StatusMessages = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "ok", "Okay" },
            { "0", "API key was not entered" },
            { "1", "API key is invalid" },
            { "2", "API key is inactive" },
            { "3", "Too many lookups" },
            { "4", "No input" },
            { "5", "Invalid input" },
            { "6", "Unknown error" },
            { "unknown", "Unknown error" }
        };

    }
}