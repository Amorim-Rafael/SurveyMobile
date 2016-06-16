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
using SurveyMobile.Droid.UserInterfaceLayer.Activities;

namespace SurveyMobile.Droid.Domain.Survey
{
    public class QuestionarioManager
    {
        //private static QuestionaryManager instance = null;
        private Dictionary<string, object> _dynamicOptions;
        private Dictionary<string, object> _gridOptions;
        private Dictionary<string, object> _lastFormPositionGrid;
        private Dictionary<string, object> _lastIds;
        private Dictionary<string, object> _openOptions;
        private Dictionary<string, object> _optionsSelected;        
        private List<Questionario> _questionario;

        private QuestionarioActivity _questionarioActivity;

        public QuestionarioManager()
        {
            _dynamicOptions = new Dictionary<string, object>();
            _gridOptions = new Dictionary<string, object>();
            _lastFormPositionGrid = new Dictionary<string, object>();
            _lastIds = new Dictionary<string, object>();
            _openOptions = new Dictionary<string, object>();
            _optionsSelected = new Dictionary<string, object>();
            _questionario = new List<Questionario>();
        }

        #region Getters
        public QuestionarioActivity getQuestionarioActivity()
        {
            return _questionarioActivity;
        }

        public List<Questionario> getQuestionarioList(List<Questionario> questionario)
        {
            return _questionario;
        }
        #endregion

        #region Setters
        public void setQuestionarioActivity(QuestionarioActivity questionarioActivity)
        {
            _questionarioActivity = questionarioActivity;
        }

        public void setQuestionarioList(List<Questionario> questionario)
        {
            _questionario = questionario;
        }
        #endregion



        //public static QuestionarioManager getInstance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new QuestionaryManager();
        //    }
        //}
    }
}