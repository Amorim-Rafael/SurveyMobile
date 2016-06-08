using Android.App;
using SurveyMobile.PCL.BusinessLayer.Model;
using System.Collections.Generic;

namespace SurveyMobile.Droid.Domain
{
    public class GlobalParams : Application
    {
        private static GlobalParams _instance = null;
        private string _email;
        private string _token;
        private string _title;
        private List<Pesquisa> _listaPesquisa;

        public GlobalParams()
        {

        }

        public static GlobalParams getInstance()
        {
            if (_instance == null)
            {
                _instance = new GlobalParams();
            }
            return _instance;
        }

        public string getEmail()
        {
            return _email;
        }

        public string getToken()
        {
            return _token;
        }

        public string getTitle()
        {
            return _title;
        }

        public List<Pesquisa> getListaPesquisas()
        {
            return _listaPesquisa;
        }

        public void setEmail(string email)
        {
            _email = email;
        }

        public void setToken(string token)
        {
            _token = token;
        }

        public void setTitle(string title)
        {
            _title = title;
        }

        public void setListaPesquisas(List<Pesquisa> listaPesquisa)
        {
            _listaPesquisa = listaPesquisa;
        }
    }
}