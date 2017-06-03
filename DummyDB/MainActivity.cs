using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;

namespace DummyDB
{
    [Activity(Label = "DummyDB", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //Interface
            Button addButton = FindViewById<Button>(Resource.Id.AddButton);
            Button lookUpButton = FindViewById<Button>(Resource.Id.LookUpButton);

            //Main Layout Button events
            addButton.Click += (sender, e) =>
            {
                StartActivity(typeof(AddDummy));
            };

        }
    }
}

