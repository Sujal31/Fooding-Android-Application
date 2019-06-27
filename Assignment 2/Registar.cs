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


namespace Assignment_2
{
    [Activity(Label = "Registar")]
    public class Registar : Activity
    {

        DBHelper DBLite;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Create your application here
            SetContentView(Resource.Layout.Registar);
            EditText username = FindViewById<EditText>(Resource.Id.usernamereg);
            EditText useremail = FindViewById<EditText>(Resource.Id.useremail);
            EditText userpass = FindViewById<EditText>(Resource.Id.password);
            EditText userage = FindViewById<EditText>(Resource.Id.userage);
            DBLite = new DBHelper(this);


            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);

            alert.SetTitle("Error");
            alert.SetMessage(" Please Enter A Value....");

            alert.SetPositiveButton("OK", (senderAlert, args) => {

                Toast.MakeText(this, "Please Enter a Valid! Value", ToastLength.Short).Show();
            });



            Dialog dialog = alert.Create();

            Android.App.AlertDialog.Builder alert2 = new Android.App.AlertDialog.Builder(this);

            alert2.SetTitle("Successfull");
            alert2.SetMessage(" Thank you");

            alert2.SetPositiveButton("OK", (senderAlert, args) => {

                StartActivity(typeof(MainActivity));
            });



            Dialog dialog2 = alert2.Create();

            Button register = FindViewById<Button>(Resource.Id.registar);
            register.Click += delegate {

                if (username.Text == "" || useremail.Text == "" || userpass.Text == "" || userage.Text == "")
                {
                    dialog.Show();
                }
                else {
                    DBLite.insertValue(username.Text, useremail.Text, userpass.Text, userage.Text);
                    dialog2.Show();
                }

            };

        }
    }
}