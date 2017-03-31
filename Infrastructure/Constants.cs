using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortner.Infrastructure
{
    /// <summary>
    /// Valores constantes que poderão ser utilizados
    /// </summary>
    class Constants
    {
        public const string UNKNOWN = "Unknown";

        /// <summary>
        /// Protocolo a ser usado na aplicação
        /// </summary>
        public class Protocolo
        {
            public const string HTTP = "http://";
            public const string HTTPS = "https://";
        }
    }
}