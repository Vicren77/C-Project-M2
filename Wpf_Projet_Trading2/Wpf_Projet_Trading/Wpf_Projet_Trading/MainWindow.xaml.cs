using System;
using System.Collections.Generic;
using System.Windows;
using LiveCharts.Wpf;
using LiveCharts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Wpf_Projet_Trading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Crypto_prices
        {

           public double weight1 { get; set; }
            public double weight2 { get; set; }
            public double weight3 { get; set; }
            public double Risk { get; set; }
            public double ExpR { get; set; }
        }

        public List<Crypto_prices> crypto_Prices { get; set; }

        public MainWindow()
        {
            
            InitializeComponent();
            
        }
        List<Portfolios> portfolios = new List<Portfolios>();
        public void list_test()
        {
            Marko_class marko_Class = new Marko_class();

            portfolios = marko_Class.Marko(Crypto1.Text, Crypto2.Text, Crypto3.Text);
            crypto_Prices = new List<Crypto_prices>();
            Crypto_prices price1 = new Crypto_prices();
            int i = 0;
            foreach(var v in portfolios)
            {
                price1.weight1 = v.weight1;
                price1.weight2 = v.weight2;
                price1.weight3 = v.weight3;
                price1.Risk = v.sd;
                price1.ExpR = v.ex;
                
                crypto_Prices.Add(price1);
                price1 = new Crypto_prices();


            }


            DataContext = this;
        }

        public  void Cartesian()
        {
            List<double> list = new List<double>();
            API api = new API();
            var obj = api.Call_api("https://min-api.cryptocompare.com/data/v2/histoday?fsym="+Crypto1.Text+"&tsym=USD&limit=1000");
            var root = JsonConvert.DeserializeObject<API.test2>(obj);
            int i = 0;
            foreach (var v in root.Data.Data)
            {
                list.Add(root.Data.Data[i].close);
                i++;
            }
            ChartValues<double>lis = new ChartValues<double>();
             i = 0;
            foreach (double v in list)
            {
                lis.Add(v); 
                i++;
            }
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Prix",
                    Values = lis
                },
            };

            
            yFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart


            SeriesCollection[0].Values.Add(0d);
            list_test();

            

        }

        

        

        //Cartesian 
        public Func<double,string> yFormatter { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Cartesian();
            
        }
    }
}
