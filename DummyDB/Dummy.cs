﻿using System;
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
    class Dummy
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Persona { get; set; }

        public override string ToString()
        {
            return string.Format("ID={0}, Name={1}, Persona={2}", ID, Name, Persona);
        }
    }
}