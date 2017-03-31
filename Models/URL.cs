using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using UrlShortner.Infrastructure;

namespace UrlShortner.Models
{
    public class URL
    {
        [Key]
        public int UrlId { get; set; }
        [Required]
        [DisplayName("URL Original")]
        public string LongUrl { get; set; }
        [Required]
        [DisplayName("URL Encurtada")]
        public string ShortUrl { get; set; }
        [Required]
        [DisplayName("Cliques")]
        public int Hits { get; set; }

        [Required]
        [DisplayName("Criação")]
        public DateTime GeneratedDate { get; set; }
        public string UserId { get; set; }

        public virtual List<UrlStat> UrlStats { get; set; }

        /// <summary>
        /// Gera ID da URL que é utilizada para criação da URL única
        /// </summary>
        public void geraUrlRandomica()
        {
            string numero = "";
            int j;
            Random randomico = new Random();

            for (int i = 0; i < 6; i++)
            {
                j = randomico.Next(0, 35);
                if (j < 10)
                    j += 48;
                else
                    j += 87;
                numero = numero + char.ConvertFromUtf32(j);
            }
            ShortUrl = numero;
        }

        /// <summary>
        /// Verifica se a URL informada é uma URL HTTP válida
        /// </summary>
        /// <param name="url">URL a ser verificada</param>
        /// <returns>TRUE ou FALSE, caso a URL contenha HTTP</returns>
        public bool checaProtocoloHttp(string url)
        {
            url = url.ToLower();
            if (url.Length > 5)
            {
                if (url.StartsWith(Constants.Protocolo.HTTP) || url.StartsWith(Constants.Protocolo.HTTPS))
                    return true;
                else
                    return false;
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>TRUE ou FALSE dependendo da disponibilidade da URL informada</returns>
        public bool checaExisteLong()
        {
            int linkLenght = LongUrl.Length;
            if (!checaProtocoloHttp(LongUrl))
                LongUrl = Constants.Protocolo.HTTP + LongUrl;

            try
            {
                // Criando requisição HTTP
                HttpWebRequest request = WebRequest.Create(LongUrl) as HttpWebRequest;
                // Configurando o método HEAD da requisição, você também pode usar GET.
                request.Method = "HEAD";
                // Recebendo a resposta.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                // Retorna TRUE de o código da resposta for 200.
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                // Toda exceção retorna FALSE
                return false;
            }
        }
    }
}