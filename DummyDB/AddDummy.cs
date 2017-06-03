using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DummyDB
{
    [Activity(Label = "AddDummy")]
    public class AddDummy : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddDummyView);

            EditText nameField = FindViewById<EditText>(Resource.Id.NameField);
            EditText sonaField = FindViewById<EditText>(Resource.Id.SonaField);

            // Create your application here
        }
    }
}