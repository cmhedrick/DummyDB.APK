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
    [Activity(Label = "LookUpDummy")]
    public class LookUpDummy : ListActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LookUpDummyView);

            // ui interface
            //ListView dummyList = FindViewById<ListView>(Resource.Id.DummyListLayout);

            // db vars
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docsFolder, "dummy.db");

            var dummies = LookUpAll(path);
            this.ListAdapter = new ArrayAdapter<Dummy>(this, Android.Resource.Layout.SimpleListItem1, dummies);
        }

        //protected override void OnListItemClick(ListView l, View v, int position, long id)

        private List<Dummy> LookUpAll(string path)
        {
            var conn = new SQLiteConnection(path);
            var dummy_list = conn.Query<Dummy>("SELECT * FROM Dummy");
            return dummy_list;
        }
    }
}