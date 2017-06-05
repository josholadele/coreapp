using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace FrontEndProcessor
{
    public class SwitchNode
    {
        public string NodeName
        {
            get
            {
                return ConfigurationManager.AppSettings["SwitchName"];
            }
        }
        public string NodeIP
        {
            get
            {
                return ConfigurationManager.AppSettings["SwitchIP"];
            }
        }
        public int NodePort
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["SwitchPort"]);
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
