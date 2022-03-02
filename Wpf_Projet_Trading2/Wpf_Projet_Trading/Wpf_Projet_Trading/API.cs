using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wpf_Projet_Trading
{
    public class API
    {
        public class test2
        {
            public string Response;
            public test Data = new test();

        }

        public class test
        {
            public bool Aggregated;

            public List<Price> Data = new List<Price>();
        }

        public class Price
        {
            public float high;
            public float low;
            public float open;
            public float volumefrom;
            public float volumeto;
            public float close;

        }

      



        private static readonly HttpClient _client = new HttpClient();
            

            static HttpClient client =
                new HttpClient();

            public string Call_api(string built_url)
            {
                Uri built_uri = new Uri(built_url);


                try
                {
                    
                    string myJsonResponse = new WebClient().DownloadString(built_uri);
                    //string response_body = await client.GetStringAsync(built_uri);
                    return myJsonResponse;
                }
                catch (HttpRequestException e)
                {

                    Console.WriteLine(e);
                    return "ERROR";
                }
            }

            public static List<double> closes = new List<double>();


          public void ini_Api()
            {
            
            
            
                string objects =    Call_api("https://min-api.cryptocompare.com/data/v2/histoday?fsym=BTC&tsym=USD&limit=4");
               

                var root =  JsonConvert.DeserializeObject<test2>(objects);
                int i = 0;
                foreach (var v in root.Data.Data)
                {
                    closes.Add(root.Data.Data[i].close);
                    i++;
                }

            

            }

    }
    }
