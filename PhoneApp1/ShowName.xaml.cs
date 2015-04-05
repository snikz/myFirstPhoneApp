using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Runtime.Serialization.Json;
using Microsoft.Phone.Shell;
using Windows.Web.Http;
using System.IO;
using System.Text;

namespace PhoneApp1
{
    public class Number1
    {
        public String number { get; set; }
    }
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private async void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {

            HttpClient client = new HttpClient(); 
            client.DefaultRequestHeaders.IfModifiedSince = DateTime.UtcNow;
            string result = await client.GetStringAsync(new Uri("http://localhost:56122/Service1.svc/" + 1));
            DataContractJsonSerializer JSONSerializer = new DataContractJsonSerializer(typeof(Number1));
            
            Number1 test = (Number1)JSONSerializer.ReadObject(new MemoryStream(Encoding.Unicode.GetBytes(result)));
            //nameText.Text = App.name;
            nameText.Text = test.number;
        }
    }
}