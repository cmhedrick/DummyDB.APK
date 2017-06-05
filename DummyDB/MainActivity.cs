using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

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

            // create DB path
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "dummy.db");

            // create db if needed
            if (!File.Exists(pathToDatabase))
            {
                createDB(pathToDatabase);
                var reason = "Dummy Database Created~";
                Toast.MakeText(Application.Context, reason, ToastLength.Long).Show();
            }

            //Main Layout Button events
            addButton.Click += (sender, e) =>
            {
                StartActivity(typeof(AddDummy));
            };

            lookUpButton.Click += (sender, e) =>
            {
                StartActivity(typeof(LookUpDummy));
            };

        }

        private string createDB(string path)
        {
            try
            {
                var connection = new SQLiteConnection(path);
                connection.CreateTable<Dummy>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

    }
}

