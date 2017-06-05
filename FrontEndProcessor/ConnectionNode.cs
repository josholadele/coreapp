using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace FrontEndProcessor
{
    public class ConnectionNode
    {
        public string NodeName
        {
            get
            {
                return ConfigurationManager.AppSettings["NodeName"];
            }
        }
        public string NodeIP
        {
            get
            {
                return ConfigurationManager.AppSettings["NodeIP"];
            }
        }
        public int NodePort
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["NodePort"]);
            }
        }
        public static string LinkedAccount
        {
            get
            {
                return ConfigurationManager.AppSettings["LinkedAccount"];
            }
        }

        public static string OriginalDataElement
        {
            get
            {
                return ConfigurationManager.AppSettings["OriginalDataElement"];
            }
        }

    }
}
