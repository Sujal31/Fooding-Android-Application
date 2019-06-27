using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System;

namespace Assignment_2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //Step 3 - 1
        EditText myUserName;
        EditText mypassword;
        Button myBtn;
        DBHelper DBlite;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Step 1
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            //Step 2
            SetContentView(Resource.Layout.activity_main);

            //Step 3 - 2
            DBlite = new DBHelper(this);
            myUserName = FindViewById<EditText>(Resource.Id.usernamemain);
            myBtn = FindViewById<Button>(Resource.Id.submit);
            mypassword= FindViewById<EditText>(Resource.Id.passwordmain);



            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);

            alert.SetTitle("Error");
            alert.SetMessage(" Please Enter A Value....");

            alert.SetPositiveButton("OK", (senderAlert, args) => {

                Toast.MakeText(this, "Please Enter a Valid! Value", ToastLength.Short).Show();
            });

            

            Dialog dialog = alert.Create();


            

            myBtn.Click += delegate {

                var value = myUserName.Text;
                var password = mypassword.Text;
                
                if (value == " " || password=="")
                {
                    //set alert for executing the task
                    dialog.Show();
                }
                
                else
                {
                    Boolean result = DBlite.selectMyValues(myUserName.Text, mypassword.Text);
                    
                    
                    

                    if (result)
                    {
                        Intent myNewScreen = new Intent(this, typeof(WelcomeScreen));
                        myNewScreen.PutExtra("username", myUserName.Text);
                        StartActivity(myNewScreen);
                        

                       


                    }

                    else
                    {
                        Android.App.AlertDialog.Builder alert2 = new Android.App.AlertDialog.Builder(this);
                        alert2.SetTitle("Wrong");
                        alert2.SetMessage("Please enter right information");

                        alert2.SetPositiveButton("ok", (senderalert, args) =>
                         {
                             Toast.MakeText(this, "Please Enter Validvalue", ToastLength.Short).Show();
                         });
                        alert2.Create();
                        alert2.Show();
                    }

                   


                        

                }




            };
            TextView newuser = FindViewById<TextView>(Resource.Id.newuser);
            newuser.Click += delegate
            {
                Intent myNewScreen = new Intent(this, typeof(Registar));
                StartActivity(myNewScreen);
            };
           
        }

    }
}