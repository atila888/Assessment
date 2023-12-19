using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Helper
{
    public static class HTTPClientWrapper<T> where T : class
    {
        /// <summary>
        /// Get Metodlu endpoint için
        /// </summary>
        /// <param name="url">API Url</param>
        /// <returns>T Generic Türünde Geri dönüş Yapacak</returns>
        public static async Task<T> GetAsync(string url)
        {
            T result = null;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;

                response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<T>(x.Result);
                });
            }

            return result;
        }

        /// <summary>
        /// Post Metodlu endpoint için
        /// </summary>
        /// <param name="apiUrl">API Url</param>
        /// <param name="postObject">Post Nesnesi</param>
        /// <returns>T Generic Türünde Geri dönüş Yapacak</returns>
        public static async Task<T> PostAsync(string apiUrl, T postObject)
        {
            T result = null;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<T>(x.Result);

                });
            }

            return result;
        }
    }
}
