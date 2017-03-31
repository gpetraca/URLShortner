using System.ComponentModel;
using System.Web;
using UrlShortner.Infrastructure;

namespace UrlShortner.Models
{
    public class UrlStat
    {
        public int UrlStatId { get; set; }
        [DisplayName("User Agent")]
        public string UserAgent { get; set; }
        [DisplayName("Endereço do Host")]
        public string UserHostAddress { get; set; }
        [DisplayName("Linguagem")]
        public string UserLanguage { get; set; }
        [DisplayName("URL de Referência")]
        public string UrlRefferer { get; set; }
        [DisplayName("Mobile")]
        public bool IsMobile { get; set; }
        public string Browser { get; set; }
        [DisplayName("Versão do Navegador")]
        public int MajorVersion { get; set; }
        public int UrlId { get; set; }
        public virtual URL Url { get; set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public UrlStat()
        {

        }

        /// <summary>
        /// Alimentando o elemento com dados da requisição
        /// </summary>
        /// <param name="request">Requisição HTTP</param>
        public UrlStat(HttpRequestBase request)
        {
            if (string.IsNullOrEmpty(request.UrlReferrer.Host))
                UrlRefferer = Constants.UNKNOWN;
            else
                UrlRefferer = request.UrlReferrer.Host;

            if (string.IsNullOrEmpty(request.UserAgent))
                UserAgent = Constants.UNKNOWN;
            else
                UserAgent = request.UserAgent;

            if (string.IsNullOrEmpty(request.UserHostAddress))
                UserHostAddress = Constants.UNKNOWN;
            else
                UserHostAddress = request.UserHostAddress;

            if (string.IsNullOrEmpty(request.UserLanguages[0]))
                UserLanguage = Constants.UNKNOWN;
            else
                UserLanguage = request.UserLanguages[0];

            if (string.IsNullOrEmpty(request.Browser.Browser))
                Browser = Constants.UNKNOWN;
            else
                Browser = request.Browser.Browser;

            MajorVersion = request.Browser.MajorVersion;
            IsMobile = request.Browser.IsMobileDevice;
        }
    }
}