using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;

namespace Remotelog.Net.Client
{
    public class LogConfigHandler : IConfigurationSectionHandler
    {
        object IConfigurationSectionHandler.Create(object parent, object configContext, XmlNode section)
        {
            if (section == null)
                throw new ConfigurationErrorsException("Required attributes missing.");

            if (section.Attributes["name"] == null || section.Attributes["name"].Value.Length == 0)
                throw new ConfigurationErrorsException("Required attribute 'name' missing from config item.");
            string name = section.Attributes["name"].Value;

            if (section.Attributes["endpoint"] == null || section.Attributes["endpoint"].Value.Length == 0)
                throw new ConfigurationErrorsException("Required attribute 'endpoint' missing from config item.");
            string endpoint = section.Attributes["endpoint"].Value;

            return new LogConfig 
            {
                Name = name,
                Endpoint = endpoint
            };
        }
    }
}
