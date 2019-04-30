using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoStats
{
    class DownloadStats
    {
        private long last_update = 0;
        private DB access_db;

        public DownloadStats(DB access_db)
        {
            this.access_db = access_db;
        }

        public void Download()
        {
            Task t = new Task(DownloadPageAsync);
            t.Start();
        }

        private async void DownloadPageAsync()
        {
            try
            {
                // ... Target page.
                string page = "https://api.coinmarketcap.com/v1/ticker/";

                // ... Use HttpClient.
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(page))
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    string result = await content.ReadAsStringAsync();


                    // ... Display the result.
                    if (result != null && result.Length >= 50 && result.StartsWith("[") && result.EndsWith("]"))
                    {
                        List<Waluta> listaWalut = JsonConvert.DeserializeObject<List<Waluta>>(result);
                        if (listaWalut != null)
                        {
                            long new_time = listaWalut[0].last_updated;
                            if(new_time > last_update)
                            {
                                access_db.UpdateDB(listaWalut);
                                last_update = new_time;
                            }
                            
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
