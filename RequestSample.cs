
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace request
{
    public class RequestSample
    {
        private string APIKey = "4534";
        private string URLBase = "https://api.nvoip.com.br/v2/sms";

        public void SendSMS(string message, string number)
        {
            string URL = $"{URLBase}?apikey={APIKey}";

            WebClient webClient = new WebClient();

            Dictionary<string, object> dictData = new Dictionary<string, object>();
            dictData.Add("numberPhone", number);
            dictData.Add("message", message);
            dictData.Add("flashSms", false);

            try
            {
                webClient.Headers["content-type"] = "application/json";
                byte[] parameters = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented));
                byte[] resByte = webClient.UploadData(URL, "post", parameters);
                string reqString = Encoding.Default.GetString(resByte);
                System.Console.WriteLine(reqString);
                webClient.Dispose();

            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e.Message);
            }
        }

    }
}