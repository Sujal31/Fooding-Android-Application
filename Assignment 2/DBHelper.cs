using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Assignment_2
{
    class DBHelper : SQLiteOpenHelper
    {


        private static string _DatabaseName = "mydatabase.db";
        private const string TableName = "Person";

        private const string ColumnPassword = "Password";
        private const string ColumnName = "name";
        private const string ColumnAge = "Age";
        private const string ColumnEmail = "eMails";

        internal void selectMyValues(object text)
        {
            throw new NotImplementedException();
        }

        public const string CreateUserTableQuery = "CREATE TABLE " +
        TableName + " ( " + ColumnName + " TEXT,"
            + ColumnEmail + " TEXT," + ColumnPassword + " TEXT," + ColumnAge + " TEXT)";



        SQLiteDatabase myDBObj;
        Context myContext;


        public DBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1) //Step 2;
        {
            myContext = context;
            myDBObj = WritableDatabase;
        }


        public override void OnCreate(SQLiteDatabase db)
        {

            db.ExecSQL(CreateUserTableQuery);

        }


        public void insertValue(string nameValue, string emailValue, string passwordvalue, string ageValue)
        {


            String insertSQL = "insert into " + TableName + " values ('" + nameValue + "'" + "," + "'" + emailValue + "'" + "," + "'" + passwordvalue + "'" + "," + "'" + ageValue + "')";

            System.Console.WriteLine("Insert SQL " + insertSQL);
            myDBObj.ExecSQL(insertSQL);

        }

        public Boolean selectMyValues(string Uname, string upassword)
        {

            String sqlQuery = "Select * from " + TableName + " where " + ColumnName + "='" + Uname + "' AND " + ColumnPassword + "='" + upassword + "';";

            ICursor result = myDBObj.RawQuery(sqlQuery, null);
            if (result.Count > 0)
            {

                while (result.MoveToNext())
                {


                    var NamefromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnName));
                    System.Console.WriteLine(" Value  Of Name  FROM DB  --> " + NamefromDB);

                    var EmailfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnEmail));
                    System.Console.WriteLine(" Value  Of Email  FROM DB --> " + EmailfromDB);

                    var PasswordfromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnPassword));
                    System.Console.WriteLine(" Value  Of Password  FROM DB  --> " + PasswordfromDB);

                    var AgefromDB = result.GetString(result.GetColumnIndexOrThrow(ColumnAge));
                    System.Console.WriteLine(" Value  Of Age  FROM DB  --> " + AgefromDB);


                }
                return true;


            }
            else
            {
                System.Console.WriteLine("User Does Not Exist");
                return false;

            }





        }
        public ICursor selectMyValuesforedit(string Uname)
        {

            String sqlQuery = "Select * from " + TableName + " where " + ColumnName + "='" + Uname + "';";

            ICursor result = myDBObj.RawQuery(sqlQuery, null);



            return result;




        }




        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) // Step: 1 - 2:2
        {
            throw new NotImplementedException();
        }

public String getname()
        {
            return ColumnName;
        }
        public String getpassword()
        {
            return ColumnPassword;
        }
        public String getemail()
        {
            return ColumnEmail;
        }
        public String getage()
        {
            return ColumnAge;
        }

        public void updateValue(string nameValue, string emailValue, string passwordvalue, string ageValue)
        {

            // update set coloumname = 'namevalue', coloumemail='emailvalue';
            String UpdateSQL = "update " + TableName + " set " + ColumnName + " ='" + nameValue + "'" + "," + ColumnEmail + " ='" + emailValue + "'" + "," + ColumnPassword + " ='" + passwordvalue + "'" + "," + ColumnAge + " ='" + ageValue + "' " + " where " + ColumnName + "= '" + nameValue +"'; ";

            System.Console.WriteLine("Insert SQL " + UpdateSQL);
            myDBObj.ExecSQL(UpdateSQL);

        }

        public ICursor selectUserlist()
        {

            String sqlQuery = "Select * from " + TableName  + ";";

            ICursor result = myDBObj.RawQuery(sqlQuery, null);



            return result;




        }

    }
}
    
    