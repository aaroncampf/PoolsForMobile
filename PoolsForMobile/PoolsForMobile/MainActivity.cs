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

            button.Click += delegate { button.Text = $"{count++} clicks!"; };



            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Tab 1", Resource.Drawable.ic_tab_white, new SampleTabFragment());
            AddTab("Tab 2", Resource.Drawable.ic_tab_white, new SampleTabFragment2());

            if (bundle != null)
                this.ActionBar.SelectTab(this.ActionBar.GetTabAt(bundle.GetInt("tab")));

            Test();
        }

        private static void Test()
        {
            const string URL = "http://poolhalls.azurewebsites.net/Api/UserAPI";
            var request = new System.Net.HttpWebRequest(new Uri(URL)) { Method = "GET" };

            var responseString = string.Empty;
            var response = request.GetResponse() as System.Net.HttpWebResponse;
            using (var sr = new System.IO.StreamReader(response.GetResponseStream()))
            {
                responseString = sr.ReadToEnd();
            }

            var json = System.Json.JsonArray.Parse(responseString);

            foreach (var Item in json)
            {
                Item.ToString();
            }


            //var test = new ();

            foreach (System.Json.JsonObject item in json)
            {
                var thing = new Models.User(item);
            }

        }






        void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(Resource.Drawable.ic_tab_white);

            // must set event handler before adding tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };
            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

        class SampleTabFragment : Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = inflater.Inflate(Resource.Layout.Tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
                sampleTextView.Text = "sample fragment text";

                return view;
            }
        }

        class SampleTabFragment2 : Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = inflater.Inflate(Resource.Layout.Tab, container, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
                sampleTextView.Text = "sample fragment text 2";

                return view;
            }
        }
    }
}

