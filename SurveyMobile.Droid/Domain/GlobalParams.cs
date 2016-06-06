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

namespace SurveyMobile.Droid.Domain
{
    public class GlobalParams
    {
        private static GlobalParams instance = null;
        private string email;
        private string token;

        public GlobalParams()
        {

        }

        public static GlobalParams getInstance()
        {
            if (instance == null)
            {
                instance = new GlobalParams();
            }
            return instance;
        }

        public string getEmail()
        {
            return email;
        }

        public string getToken()
        {
            return token;
        }

        public void setEmail(string s)
        {
            email = s;
        }

        public void setToken(string s)
        {
            token = s;
        }
    }
}