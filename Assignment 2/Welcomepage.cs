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
    [Activity(Label = "Welcomepage")]
    public class WelcomeScreen : Activity
    {
        Button ebutton;
        DBHelper DBLite;


        
        
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        

         
            SetContentView(Resource.Layout.Welcomepage);
            EditText username = FindViewById<EditText>(Resource.Id.eusername);
            EditText useremail = FindViewById<EditText>(Resource.Id.euseremail);
            EditText userpass = FindViewById<EditText>(Resource.Id.epassword);
            EditText userage = FindViewById<EditText>(Resource.Id.euserage);
            DBLite = new DBHelper(this);

            string eusername = Intent.GetStringExtra("username");
            ICursor result = DBLite.selectMyValuesforedit(eusername);
            while (result.MoveToNext())
            {


                var NamefromDB = result.GetString(result.GetColumnIndexOrThrow(DBLite.getname()));
                username.Text = NamefromDB;


                var EmailfromDB = result.GetString(result.GetColumnIndexOrThrow(DBLite.getemail()));
                useremail.Text = EmailfromDB;

                var PasswordfromDB = result.GetString(result.GetColumnIndexOrThrow(DBLite.getpassword()));
                userpass.Text = PasswordfromDB;

                var AgefromDB = result.GetString(result.GetColumnIndexOrThrow(DBLite.getage()));
                userage.Text = AgefromDB;


            }

            username.AfterTextChanged += buttonenable;
            useremail.AfterTextChanged += buttonenable;
            userpass.AfterTextChanged += buttonenable;
            userage.AfterTextChanged += buttonenable;


            ebutton = FindViewById<Button>(Resource.Id.editbtn);
            ebutton.Enabled = false;

            
           

            ebutton = FindViewById<Button>(Resource.Id.editbtn);
            ebutton.Click += delegate
            {
                DBLite.updateValue(username.Text, useremail.Text, userpass.Text, userage.Text);
            };

            Button Userlist = FindViewById<Button>(Resource.Id.userlist);
            Userlist.Click += delegate
            {
                Intent myNewScreen = new Intent(this, typeof(Userlist));
                StartActivity(myNewScreen);
            };

        }
        public void buttonenable(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            ebutton.Enabled = true;
        }

        
    }
    
    
}