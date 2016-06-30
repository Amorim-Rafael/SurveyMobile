using Android.Support.V4.App;
using System.Collections.Generic;
using SurveyMobile.Droid.Domain.Survey;
using SurveyMobile.Droid.UserInterfaceLayer.Fragments;

namespace SurveyMobile.Droid.UserInterfaceLayer.Adapter
{
    public class QuestionarioPagerAdapter : FragmentStatePagerAdapter//FragmentPagerAdapter
    {
        private List<Questao> _questoes;
        private OneChoiceQuestionFragment _oneChoiceQuestionFragment;

        public QuestionarioPagerAdapter(FragmentManager fragmentmanager, List<Questao> questoes) : base(fragmentmanager)
        {
            _questoes = questoes;
        }

        public override int Count
        {
            get
            {
                return _questoes.Count;
            }
        }

        public override Fragment GetItem(int position)
        {            
            if (_questoes == null)
                return null;

            Questao questao = _questoes[position];
            if (questao.TipoQuestao == 4)
                _oneChoiceQuestionFragment = OneChoiceQuestionFragment.newInstance(position, questao);
            else
            {
                if (questao.TipoQuestao == 1)
                {

                }
                else if (questao.TipoQuestao == 2)
                {

                }
                else if (questao.TipoQuestao == 3)
                {

                }
            }
            return _oneChoiceQuestionFragment;
        }
    }
}