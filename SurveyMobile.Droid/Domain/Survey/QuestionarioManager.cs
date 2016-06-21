using SurveyMobile.Droid.UserInterfaceLayer.Activities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SurveyMobile.Droid.Domain.Survey
{
    public class QuestionarioManager
    {
        private static QuestionarioManager instance = null;
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

        public void setStartQuestionario(long startQuestionario)
        {
            _startQuestionario = startQuestionario;
        }
    }
}