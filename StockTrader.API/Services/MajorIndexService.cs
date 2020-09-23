using StockTrader.Domain.Models;
using StockTrader.Domain.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StockTrader.API.Services
{
    //https://financialmodelingprep.com/api/v3/majors-indexes/.DJI?apikey=3b8cf2611a3a74d31a8178b509d24edf
    public class MajorIndexService : IMajorIndexService
    {
        public string APIKey = "3b8cf2611a3a74d31a8178b509d24edf";
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType IndexType)
        {
            using (ApiHttpClient client = new ApiHttpClient())
            {
                string uri = "majors-indexes/" + GetUriSfx(IndexType) + "?apikey=" + APIKey;
                MajorIndex majorIndex = await client.GetAsync<MajorIndex>(uri);
                majorIndex.Type = IndexType;
                Debug.Write("\r\n************************************");
                Debug.Write("\r\nURI: " + uri);
                Debug.Write("\r\nIndexName: " + majorIndex.IndexName);
                Debug.Write("\r\nIndexPrice: " + majorIndex.Price);
                Debug.Write("\r\nIndexChange: " + majorIndex.Changes);
                Debug.Write("\r\nIndexType: " + majorIndex.Type.ToString());
                Debug.Write("\r\n************************************");
                return majorIndex;
            }
        }

        private string GetUriSfx(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    throw new Exception("MajorIndexType Suffix Not Defined!");
            }
        }
    }
}
