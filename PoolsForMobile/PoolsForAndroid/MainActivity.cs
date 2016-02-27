using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PoolsForAndroid
{
    [Activity(Label = nameof(PoolsForAndroid), MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };


            Test();
        }

        private static void Test()
        {
            var URL = "http://poolhalls.azurewebsites.net/Api/UserAPI";


            Uri uri = new Uri(URL);
            var request = new System.Net.HttpWebRequest(uri) { Method = "GET" };

            var responseString = string.Empty;
            var response = request.GetResponse() as System.Net.HttpWebResponse;
            using (var sr = new System.IO.StreamReader(response.GetResponseStream()))
            {
                responseString = sr.ReadToEnd();
            }

            System.Json.JsonValue json = System.Json.JsonValue.Parse(responseString);
        }
    }
}

