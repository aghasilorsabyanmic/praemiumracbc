using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Data
{
    public sealed class ExchangeManager : IDisposable
    {
        public ExchangeManager(Uri url)
        {
            client.BaseAddress = url;
        }

        private HttpClient client = new HttpClient();

        public async Task<Dictionary<string, decimal>> Get(string currency = "")
        {
            var url = string.IsNullOrWhiteSpace(currency) ? string.Empty : $"?currency={currency.Trim().ToUpper()}";

            var jsonString = await client.GetStringAsync(url);

            var dictionary = await Task.Run(() => JsonConvert.DeserializeObject<Dictionary<string, decimal>>(jsonString));

            return dictionary;
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
