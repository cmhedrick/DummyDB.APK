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
using SQLite;

namespace DummyDB
{
    [Activity(Label = "AddDummy")]
    public class AddDummy : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddDummyView);

            // set UI
            EditText nameField = FindViewById<EditText>(Resource.Id.NameField);
            EditText sonaField = FindViewById<EditText>(Resource.Id.SonaField);
            Button createButton = FindViewById<Button>(Resource.Id.CreateButton);

            // set paths
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "dummy.db");

            // set event handlers
            createButton.Click += (sender, e) =>
            {
                Dummy dummy = new Dummy { Name = nameField.Text, Persona = sonaField.Text };
                insertData(dummy, pathToDatabase);
            };

        }

        private void insertData(Dummy data, string path)
        {
            try
            {
                var db = new SQLiteConnection(path);
                if (db.Insert(data) != 0)
                    db.Update(data);
                var reason = "Added a Dummy!";
                Toast.MakeText(Application.Context, reason, ToastLength.Long).Show();
            }
            catch (SQLiteException ex)
            {
                var reason = "Something fucked up happend. Try to init db";
                Toast.MakeText(Application.Context, reason, ToastLength.Long).Show();
            }
        }

    }
}