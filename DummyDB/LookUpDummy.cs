﻿using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;
using System.Collections.Generic;

namespace DummyDB
{
    [Activity(Label = "LookUpDummy")]
    public class LookUpDummy : ListActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LookUpDummyView);
            EditText searchField = FindViewById<EditText>(Resource.Id.SearchField);
            Button lookUpNameButton = FindViewById<Button>(Resource.Id.LookUpNameButton);
            // ui interface
            //ListView dummyList = FindViewById<ListView>(Resource.Id.DummyListLayout);

            // db vars
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docsFolder, "dummy.db");

            var dummies = LookUpAll(path);
            this.ListAdapter = new ArrayAdapter<Dummy>(this, Android.Resource.Layout.SimpleListItem1, dummies);

            lookUpNameButton.Click += (sender, e) =>
            {
                dummies = LookUpName(searchField.Text, path);
                this.ListAdapter = new ArrayAdapter<Dummy>(this, Android.Resource.Layout.SimpleListItem1, dummies);
            };

        }


        //protected override void OnListItemClick(ListView l, View v, int position, long id)

        private List<Dummy> LookUpAll(string path)
        {
            var conn = new SQLiteConnection(path);
            var dummy_list = conn.Query<Dummy>("SELECT * FROM Dummy");
            return dummy_list;
        }

        private List<Dummy> LookUpName(string name, string path)
        {
            var conn = new SQLiteConnection(path);
            List<Dummy> dummy_list;

            if (name != null && name != "")
            {
                var query = "SELECT * FROM Dummy WHERE Name = '" + name + "'";
                dummy_list = conn.Query<Dummy>(query);
            }
            else
            {
                var query = "SELECT * FROM Dummy";
                dummy_list = conn.Query<Dummy>(query);
            }
            return dummy_list;
        }
    }
}