using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Models;
using Trader.Domain.Services;

namespace Trader.API.Services
{
    public class MajorIndexService : IMajorIndex
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
          string API_REQUEST_URI = $"https://financialmodelingprep.com/api/v3/majors-indexes/{GetIndexSuffix(indexType)}/?apikey=3f119eff2e824388d72a1eaa20044775";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage message = await client.GetAsync(API_REQUEST_URI);
                    message.EnsureSuccessStatusCode();
                    if (message.IsSuccessStatusCode)
                    {
                        var response = await message.Content.ReadAsStringAsync();
                        MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(response);
                        majorIndex.Type= indexType;
                        return majorIndex;
                    }
                    else
                    {
                        throw new Exception("Cannot retrieve Major Index");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private string GetIndexSuffix(MajorIndexType indexType)
        {
            return indexType switch
            {
                MajorIndexType.DowJones => ".DJI",
                MajorIndexType.Nasdaq => ".IXIC",
                MajorIndexType.SP500 => ".GSPC",
                _ => throw new Exception("Index type not supported"),
            };
        }
    }
}
