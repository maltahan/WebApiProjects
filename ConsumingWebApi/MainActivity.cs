using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Net;
using System;
using System.Json;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsumingWebApi
{
    [Activity(Label = "ConsumingWebApi", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            ListView EmployeesList = FindViewById<ListView>(Resource.Id.listView1);

            Button button = FindViewById<Button>(Resource.Id.button1);

            // When the user clicks the button ...
            button.Click += async (sender, e) => {

                // Get the latitude and longitude entered by the user and create a query.
                string url = "http://192.168.1.116:8050/Employees";
                             

                // Fetch the weather information asynchronously, 
                // parse the results, then update the screen:
                JsonValue json = await FetchWeatherAsync(url);
                 ParseAndDisplay (json);
            };
        }

        private async Task<JsonValue> FetchWeatherAsync(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }

        private void ParseAndDisplay(JsonValue json)
        {

            JsonValue weatherResults = json[""];

            string temp = weatherResults["FirstName"];


            string cloudy = weatherResults["PostalCode"];
            dynamic data = JObject.Parse(json);

            

           //List<Employee> deserializedProduct = JsonConvert.DeserializeObject<List<Employee>>(json);


            foreach (var item in data)
            {
                var s1 = item.Address;
            }


        }
    }
}

