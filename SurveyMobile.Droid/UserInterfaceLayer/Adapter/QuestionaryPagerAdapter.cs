using System;
using Android.Support.V4.App;
using System.Collections.Generic;
using SurveyMobile.Droid.Domain.Survey;

namespace SurveyMobile.Droid.UserInterfaceLayer.Adapter
{
    public class QuestionaryPagerAdapter : FragmentPagerAdapter
    {
        private List<Questao> _questionary;

        public QuestionaryPagerAdapter(FragmentManager fragmentmanager, List<Questao> questionary) : base(fragmentmanager)
        {
            _questionary = questionary;
        }

        public override int Count
        {
            get
            {
                return _questionary.Count;
            }
        }

        public override Fragment GetItem(int position)
        {
            //if (_questionary != null)
            //{
            //    Questao questao = _questionary[position];
            //}
            ////OneChoiceQuestionFragment
            throw new NotImplementedException();
        }
    }
}