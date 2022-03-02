using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Projet_Trading
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

        public class coinInfo
        {
            public string Name;
            public string FullName;
        }


        public partial class Portfolio
        {
            private List<Portfolio> _portfolios = new List<Portfolio>();
        }



        public class testbis2
        {
            public string Name;
            public coinInfo CoinInfo = new coinInfo();
        }
        public class Testbis
        {
            public string Message;

            public readonly List<testbis2> Data = new List<testbis2>();
        }

        public class TestList
        {
            public float USD;
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

        public class Portfolios
        {
            public double weight1 { get; set; }
            public double weight2 { get; set; }
            public double weight3 { get; set; }
            public double sd { get; set; }
            public double ex { get; set; }

        }




    public class Marko_class
    {

        public List<Portfolios> Marko(string crypt1, string crypt2, string crypt3)
        {
            API api = new API();
            double a = 0, b = 0, c = 0;
            Random rand = new Random();
            double v = 0;
            var infcoin1 = api.Call_api("https://min-api.cryptocompare.com/data/v2/histoday?fsym=" + crypt1 + "&tsym=USD&limit=300");

            var infcoin2 = api.Call_api("https://min-api.cryptocompare.com/data/v2/histoday?fsym=" + crypt2 + "&tsym=USD&limit=300");

            var infcoin3 = api.Call_api("https://min-api.cryptocompare.com/data/v2/histoday?fsym=" + crypt3 + "&tsym=USD&limit=300");


            var infcoin1Root = JsonConvert.DeserializeObject<test2>(infcoin1);
            var infcoin2Root = JsonConvert.DeserializeObject<test2>(infcoin2);
            var infcoin3Root = JsonConvert.DeserializeObject<test2>(infcoin3);

            List<float> List1 = new List<float>();
            List<float> List2 = new List<float>();
            List<float> List3 = new List<float>();

            List<float> BrutData1 = new List<float>();
            List<float> BrutData2 = new List<float>();
            List<float> BrutData3 = new List<float>();

            List<Portfolios> pf = new List<Portfolios>();

            float x1, y1 = 0, x2, y2 = 0, x3, y3 = 0;
            double E;
            for (int j = 0; j < 100; j++)
            {
                if (infcoin1Root != null)
                {
                    x1 = (infcoin1Root.Data.Data[j].close / infcoin1Root.Data.Data[j + 1].close) - 1; // daily return
                    List1.Add(x1);
                    BrutData1.Add(infcoin1Root.Data.Data[j].close); // add raw data to list
                    y1 = x1 + y1;

                }

                if (infcoin2Root != null)
                {
                    x2 = (infcoin2Root.Data.Data[j].close / infcoin2Root.Data.Data[j + 1].close) - 1;
                    List2.Add(x2);
                    BrutData2.Add(infcoin2Root.Data.Data[j].close);
                    y2 = x2 + y2;

                }

                if (infcoin2Root != null)
                {
                    x3 = (infcoin3Root.Data.Data[j].close / infcoin3Root.Data.Data[j + 1].close) - 1;
                    List3.Add(x3);
                    BrutData3.Add(infcoin3Root.Data.Data[j].close);
                    y3 = x3 + y3;

                }

            }
            y1 = y1 / 100;
            y2 = y2 / 100;
            y3 = y3 / 100;
            float sum1 = 0, sum2 = 0, sum3 = 0;
            meanReturn(List1, List2, List3, y1, sum1, sum2, sum3);
            /*
            for (int k = 0; k < 100; k++)
            {
                List1[k] = (float)Math.Pow((List1[k] - y1), 2);
                sum1 = List1[k] + sum1;
                List2[k] = (float)Math.Pow((List2[k] - y1), 2);
                sum2 = List2[k] + sum2;
                List3[k] = (float)Math.Pow((List3[k] - y1), 2);
                sum3 = List3[k] + sum3;

            }
            */

            double standardD1 = Math.Sqrt(sum1 / 99);
            double standardD2 = Math.Sqrt(sum2 / 99);
            double standardD3 = Math.Sqrt(sum3 / 99);


            float corrData12 = correlationCoefficient(BrutData1, BrutData2, 100);
            float corrData23 = correlationCoefficient(BrutData2, BrutData3, 100);
            float corrData13 = correlationCoefficient(BrutData1, BrutData3, 100);

            for (int i = 0; i < 5; i++)
            {
                a = rand.Next(1, 100);
                b = rand.Next(1, 100);
                c = rand.Next(1, 100);
                v = a + b + c;
                a = Math.Round((a / v), 2, MidpointRounding.AwayFromZero);
                b = Math.Round((b / v), 2, MidpointRounding.AwayFromZero);
                c = Math.Round((c / v), 2, MidpointRounding.AwayFromZero);
                E = ((y1 * a) + (y2 * b) + (y3 * c)) * 100;

                standardDeviationPortfolio(a, b, c, standardD1, standardD2, standardD3, corrData12, corrData23, corrData13);
                pf.Add(new Portfolios
                {
                    weight1 = a,
                    weight2 = b,
                    weight3 = c,
                    sd = standardDeviationPortfolio(a, b, c, standardD1, standardD2, standardD3, corrData12, corrData23, corrData13),
                    ex = E
                });

            }

            return pf;

            // Console.WriteLine(" The correlation between 1 2 : " + corrData12 + '\n' + " The correlation between 2 3 : " + corrData23 + '\n' + " The correlation between 1 3 : " + corrData13 + '\n' );
            static void meanReturn(List<float> List1, List<float> List2, List<float> List3, float y1, float sum1, float sum2, float sum3)
            {
                for (int k = 0; k < 100; k++)
                {
                    List1[k] = (float)Math.Pow(List1[k] - y1, 2);
                    sum1 = List1[k] + sum1;
                    List2[k] = (float)Math.Pow(List2[k] - y1, 2);
                    sum2 = List2[k] + sum2;
                    List3[k] = (float)Math.Pow(List3[k] - y1, 2);
                    sum3 = List3[k] + sum3;

                }
            }
            static double standardDeviationPortfolio(double w1, double w2, double w3, double sd1, double sd2, double sd3, double corr12, double corr23, double corr13)
            {
                double variance = Math.Pow(w1, 2) * Math.Pow(sd1, 2) + Math.Pow(w2, 2) * Math.Pow(sd2, 2) + Math.Pow(w3, 2) * Math.Pow(sd3, 2) +
                    2 * w1 * w2 * covFunction(sd1, sd2, corr12) + 2 * w2 * w3 * covFunction(sd2, sd3, corr23) + 2 * w1 * w3 * covFunction(sd1, sd3, corr13);

                double sdPortfolio = Math.Sqrt(variance);

                return sdPortfolio;

            }

            //double sdTest = standardDeviationPortfolio(a, b, c, standardD1, standardD2, standardD3, corrData12, corrData23, corrData13);

            static double covFunction(double sd1, double sd2, double corr)
            {
                double covariance = sd1 * sd2 * corr;

                return covariance;
            }
            static float correlationCoefficient(List<float> X, List<float> Y,
                                                  int n)
            {
                float sum_X = 0, sum_Y = 0, sum_XY = 0;
                float squareSum_X = 0, squareSum_Y = 0;

                for (int i = 0; i < n; i++)
                {
                    // sum of elements of array X.
                    sum_X = sum_X + X[i];

                    // sum of elements of array Y.
                    sum_Y = sum_Y + Y[i];

                    // sum of X[i] * Y[i].
                    sum_XY = sum_XY + X[i] * Y[i];

                    // sum of square of array elements.
                    squareSum_X = squareSum_X + X[i] * X[i];
                    squareSum_Y = squareSum_Y + Y[i] * Y[i];
                }

                // use formula for calculating correlation 
                // coefficient.
                float corr = (float)(n * sum_XY - sum_X * sum_Y) /
                             (float)(Math.Sqrt((n * squareSum_X -
                             sum_X * sum_X) * (n * squareSum_Y -
                             sum_Y * sum_Y)));

                return corr;
            }
        }


    }
    
}
