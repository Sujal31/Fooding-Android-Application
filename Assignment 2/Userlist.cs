using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Assignment_2
{
    [Activity(Label = "Userlist")]
    public class Userlist : Activity
    {
        ListView myList;
        DBHelper DBLite;

        List<String> userList;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Userlist);
            myList = FindViewById<ListView>(Resource.Id.lv1);

            DBLite = new DBHelper(this);
            ICursor result = DBLite.selectUserlist();
            

            ArrayAdapter myAdapter;
            userList = new List<String>();

            while (result.MoveToNext())
            {


                var NamefromDB = result.GetString(result.GetColumnIndexOrThrow(DBLite.getname()));
                userList.Add(NamefromDB);
            }
           

            myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, userList);
            myList.Adapter = myAdapter;

           


            
        }
    }
}