﻿namespace Hangfire.IO.Extensions
{
    public static class ConfigurationHelperExtensions
    {
        public static IConfiguration config;
        public static void Initialize(IConfiguration Configuration)
        {
            config = Configuration;
        }
    }
}
