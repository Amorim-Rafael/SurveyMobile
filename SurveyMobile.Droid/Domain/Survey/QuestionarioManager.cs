using SurveyMobile.Droid.Domain.Send;
using SurveyMobile.Droid.UserInterfaceLayer.Activities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SurveyMobile.Droid.Domain.Survey
{
    public class QuestionarioManager
    {
        private static QuestionarioManager instance = null;
        private SendQuestionario _questionarioAtual;
        private Dictionary<int, int> _dynamicOptions;
        private Dictionary<int, int> _gridOptions;
        private Dictionary<int, int> _lastFormPositionGrid;
        private Dictionary<int, int> _lastIds;
        private Dictionary<int, int> _openOptions;
        private Dictionary<int, List<int>> _optionsSelected;
        private List<Questao> _questoes;
        private long _startQuestionario;

        private QuestionarioActivity _questionarioActivity;

        public QuestionarioManager()
        {
            _questionarioAtual = new SendQuestionario();
            _dynamicOptions = new Dictionary<int, int>();
            _gridOptions = new Dictionary<int, int>();
            _lastFormPositionGrid = new Dictionary<int, int>();
            _lastIds = new Dictionary<int, int>();
            _openOptions = new Dictionary<int, int>();
            _optionsSelected = new Dictionary<int, List<int>>();
            _questoes = new List<Questao>();
        }

        public static QuestionarioManager getInstance()
        {
            if (instance == null)
            {
                instance = new QuestionarioManager();
            }

            return instance;
        }

        #region Getters
        public QuestionarioActivity getQuestionarioActivity()
        {
            return _questionarioActivity;
        }

        public List<Questao> getQuestoesList(List<Questao> questoes)
        {
            return _questoes;
        }

        public List<int> getOptionsSelected(int page)
        {
            List<int> option = new List<int>();
            if (_optionsSelected.ContainsKey(page))
                return _optionsSelected[page];

            return option;
        }
        #endregion

        #region Setters
        public void setQuestionarioActivity(QuestionarioActivity questionarioActivity)
        {
            _questionarioActivity = questionarioActivity;
        }

        public void setQuestoesList(List<Questao> questoes)
        {
            _questoes = questoes;
        }
        #endregion

        

        public void addOptionSelected(int page, int option)
        {
            List<int> options = _optionsSelected[page];
            if (options == null)
                options = new List<int>();

            options.Add(option);

            _optionsSelected.Add(page, options);
        }

        public void updateFirstOptionSelected(int page, int option)
        {
            List<int> options = _optionsSelected[page];
            if (options == null)
            {
                options = new List<int>();
                options.Add(option);
            }
            else
                options.Insert(0, option);

            _optionsSelected.Add(page, options);
        }

        public void removeOptionSelected(int page, int option)
        {
            List<int> options = _optionsSelected[page];
            if (options != null)
            {
                options.Remove(option);
                _optionsSelected.Add(page, options);
            }
        }

        public int lastOptionSelected(int page)
        {
            if (!_optionsSelected.ContainsKey(page))
                return -1;

            List<int> options = _optionsSelected[page];
            if (options != null)
                return -1;
                        
            return options[options.Count - 1];
        }

        public bool ToNext(int i)
        {
            //if (Convert.ToInt16(_questionario[i].GetType()) != 1){}
            int value = _optionsSelected[i].ToString().Count();

            return value > 0;
        }

        public int NextPage(int current, List<Logica> logica)
        {
            int jumpToPage = current + 1;
            if (logica == null || logica.Count <= 0)
            {
                return jumpToPage;
            }
            //Iterator it = logica.iterator();
            //while (it.hasNext())
            //{
            //    Criterion c = (Criterion)it.next();
            //    boolean temp = true;
            //    boolean containsCurrentPage = false;
            //    Iterator it2 = c.getRules().iterator();
            //    while (it2.hasNext())
            //    {
            //        Regra r = (Regra)it2.next();
            //        int page = pageFrom(r.getQuestion().intValue());
            //        containsCurrentPage = page == current;
            //        if (page > -1)
            //        {
            //            Question question = (Question)this.surveyList.get(page);
            //            if (question.getType() == 1)
            //            {
            //                temp &= isSatisfiesAllTheRulesMultipleChoice(r, page);
            //                continue;
            //            }
            //            else if (question.getType() == 0)
            //            {
            //                temp &= isSatisfiesAllTheRulesSingleChoice(r, page);
            //                continue;
            //            }
            //            else if (question.getType() == 2)
            //            {
            //                temp &= isSatisfiesAllTheRulesOpenChoice(r, page);
            //                continue;
            //            }
            //            else
            //            {
            //                continue;
            //            }
            //        }
            //        if (!temp)
            //        {
            //            break;
            //        }
            //    }
            //    if (temp && containsCurrentPage)
            //    {
            //        String action = c.getAction();
            //        if (action.equals("finish"))
            //        {
            //            return Strategy.TTL_SECONDS_INFINITE;
            //        }
            //        if (!action.startsWith("jump_"))
            //        {
            //            return jumpToPage;
            //        }
            //        page = pageFrom(Integer.parseInt(action.replace("jump_", BuildConfig.VERSION_NAME)));
            //        if (page <= -1 || page <= current)
            //        {
            //            return jumpToPage;
            //        }
            //        return page;
            //    }
            //}
            return jumpToPage;
        }

        private int pageFrom(int surveyId)
        {
            for (int i = 0; i < _questoes.Count; i++)
            {
                if (_questoes[i].getQuestaoId() == surveyId)
                    return i;
            }
            return -1;
        }

        public void setStartQuestionario(long startQuestionario)
        {
            _startQuestionario = startQuestionario;
        }

        public void FinishQuestionario(long finishQuestionario)
        {
            _questionarioAtual.setFinish(finishQuestionario);
            _questionarioAtual.setDuration(finishQuestionario - _startQuestionario);
        }
    }
}