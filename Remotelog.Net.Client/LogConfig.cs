using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Remotelog.Net.Client
{
    public class LogConfig
    {
        /// <summary>
        /// The web.config section name our settings are place in.
        /// </summary>
        private const string ConfigSectionName = "remotelogClient";
        
        public static LogConfig GetConfig()
        {
            return ConfigurationManager.GetSection(ConfigSectionName) as LogConfig;
        }

        public string Name { get; set; }

        public string Endpoint{ get; set; }

    }
}
