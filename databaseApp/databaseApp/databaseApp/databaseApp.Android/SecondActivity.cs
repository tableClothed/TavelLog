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

namespace databaseApp.Droid
{
    [Activity(Label ="Second Activity")]
    public class SecondActivity : Activity
    {
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    var count = Intent.Extras.GetInt(NoteEntryPage.COUNT_KEY, -1);

        //    if (count <= 0) return;

        //    SetContentView(Resource.Layout.note);
        //    var txtView = FindViewById<TextView>(Resource.Id.texView1);
        //    txtView.Text = "You clicked the button " + count + " times";
        //}
    }
}