using Android.Util;
using SurveyMobile.Droid.Domain.Send;
using SurveyMobile.Droid.UserInterfaceLayer.Activities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SurveyMobile.Droid.Domain.Survey
{
    public class QuestionarioManager
    {
        private static string TAG;
        private static QuestionarioManager instance = null;
        private SendQuestionario _questionarioAtual;
        private Dictionary<int, int> _dynamicOptions;
        private Dictionary<int, Dictionary<int, string>> _gridOptions;
        private Dictionary<int, int> _lastFormPositionGrid;
        private Dictionary<int, int> _lastIds;
        private Dictionary<int, List<string>> _openOptions;
        private Dictionary<int, List<string>> _optionsSelected;
        private List<Questao> _questoes;
        private long _startQuestionario;
        private QuestionarioActivity _questionarioActivity;


        public QuestionarioManager()
        {
            TAG = "QuestionarioManager";
            _questionarioAtual = new SendQuestionario();
            _dynamicOptions = new Dictionary<int, int>();
            _gridOptions = new Dictionary<int, Dictionary<int, string>>();
            _lastFormPositionGrid = new Dictionary<int, int>();
            _lastIds = new Dictionary<int, int>();
            _openOptions = new Dictionary<int, List<string>>();
            _optionsSelected = new Dictionary<int, List<string>>();
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
                return _optionsSelected[page].Select(s => int.Parse(s)).ToList() ;

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
            List<string> options = _optionsSelected[page];
            if (options == null)
                options = new List<string>();

            options.Add(option.ToString());

            _optionsSelected.Add(page, options);
        }

        public void updateFirstOptionSelected(int page, int option)
        {
            List<string> options;
            if (_optionsSelected.Count > 0)
            {
                options = _optionsSelected[page];
                if (options == null)
                {
                    options = new List<string>();
                    options.Add(option.ToString());
                }
                else
                    options.Insert(0, option.ToString());
            }
            else
            {
                options = new List<string>();
                options.Add(option.ToString());
            }
            _optionsSelected.Add(page, options);
        }

        public void removeOptionSelected(int page, int option)
        {
            List<string> options = _optionsSelected[page];
            if (options != null)
            {
                options.Remove(option.ToString());
                _optionsSelected.Add(page, options);
            }
        }

        public int lastOptionSelected(int page)
        {
            if (!_optionsSelected.ContainsKey(page))
                return -1;

            List<string> options = _optionsSelected[page];
            if (options != null)
                return -1;

            return Convert.ToInt16(options[options.Count - 1]);
        }

        private List<string> initOpenOptionList(int page, int size)
        {
            List<string> options = new List<string>();
            for (int i = 0; i < size; i++)
            {
                options.Add(i.ToString());
            }
            _openOptions.Add(page, options);
            return options;
        }

        public void updateOpenOption(int page, int option, string text)
        {
            List<string> options = _openOptions[page];
            if (options == null)
                options = initOpenOptionList(page, ((Questao)_questoes[page]).getResposta().Count);// ((Question)this.surveyList.get(page)).getOptions().getValues().size());

            options.Insert(option, text);
            _openOptions.Add(page, options);
        }

        public string getOpenOption(int page, int option)
        {
            string ret = "";
            try
            {
                List<string> options = _openOptions[page];
                if (options == null)
                    return ret;

                string value = options[option];
                if (value == null)
                    return ret;

                return value;
            }
            catch (Exception e)
            {
                Log.Warn(TAG, "Erro ao recuperar op\u00e7\u00e3o de uma quest\u00e3o aberta.", e);
                return ret;
            }
        }

        public void updateGridOption(int page, int id, string text)
        {
            Dictionary<int, string> options = _gridOptions[page];
            if (options == null)
                options = new Dictionary<int, string>();

            options.Add(id, text);
            _gridOptions.Add(page, options);
        }

        public string getGridOption(int page, int option)
        {
            String ret = "";//BuildConfig.VERSION_NAME;
            Dictionary<int, string> options = _gridOptions[page];
            if (options == null)
                return ret;

            string value = options[option];
            if (value == null)
                return ret;

            return value;
        }

        public int getLastFormPositionGrid(int page)
        {
            int lastPosition = _lastFormPositionGrid[page];
            if (lastPosition == null)
                return 0;

            return lastPosition;
        }

        public void updateFormPosition(int page, int formPosition)
        {
            _lastFormPositionGrid.Add(page, formPosition);
        }

        public void removeGrid(int page, int formPosition, int formSize)
        {
            Dictionary<int, string> options = _gridOptions[page];
            if (options != null)
            {
                for (int i = formPosition; i < formPosition + formSize; i++)
                {
                    options.Remove(i);
                }
            }
            _gridOptions.Add(page, options);
        }

        public int optionDynamicGenerateId(int id, int page)
        {
            if (_lastIds.ContainsKey(page))
                id = _lastIds[page] + 1;

            _lastIds.Add(page, id);
            return id;
        }

        public void Clear()
        {
            _optionsSelected = new Dictionary<int, List<string>>();
            _dynamicOptions = new Dictionary<int, int>();
            _openOptions = new Dictionary<int, List<string>>();
            _gridOptions = new Dictionary<int, Dictionary<int, string>>();
            _lastFormPositionGrid = new Dictionary<int, int>();
            _lastIds = new Dictionary<int, int>();
            _startQuestionario = 0;
            _questionarioAtual = new SendQuestionario();
        }

        public bool ProceedToNext(int i)
        {
            try
            {
                if (_questoes[i].getTipoQuestao() != 1) { return true; }
                if (_optionsSelected[i].Count > 0) { return true; }
                return false;
            }
            catch (System.Exception e)
            {
                Log.Error(TAG, e.Message, e);
                return false;
            }
        }

        public int NextPage(int current, List<Logica> logica)
        {
            int jumpToPage = current + 1;
            if (logica == null || logica.Count <= 0)
                return jumpToPage;

            IEnumerable<Logica> IELogica = logica;
            var ITLogica = IELogica.GetEnumerator();

            while (ITLogica.MoveNext())
            {
                Logica log = ITLogica.Current;
                bool temp = true;
                bool containsCurrentPage = false;

                IEnumerable<Regra> IERegras = log.Regras;
                var ITRegra = IERegras.GetEnumerator();
                int page = 0;
                while (ITRegra.MoveNext())
                {
                    Regra regra = ITRegra.Current;
                    page = pageFrom(regra.QuestaoId);
                    containsCurrentPage = page == current;
                    if (page > -1)
                    {
                        Questao questao = _questoes[page];
                        if (questao.TipoQuestao == 0)
                        {
                            temp &= true;
                            continue;
                        }
                        else if (questao.TipoQuestao == 1)
                        {
                            temp &= true;
                            continue;
                        }
                        else if (questao.TipoQuestao == 2)
                        {
                            temp &= true;
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (!temp)
                        break;
                }
                if (temp && containsCurrentPage)
                {
                    string action = log.Acao;
                    if (action == "finish")
                        return int.MaxValue;
                    if (!action.StartsWith("jump_"))
                        return jumpToPage;
                    page = pageFrom(Convert.ToInt16(action.Replace("jump_", "")));
                    if (page <= -1 || page <= current)
                    {
                        return jumpToPage;
                    }
                    return page;
                }
            }            
            return jumpToPage;
        }

        private bool isSatisfiesAllTheRulesSingleChoice(Regra regra, int page)
        {
            string operador = regra.Operador;
            int[] ruleOptions = regra.Opcoes;
            List<int> optionsSelected = getOptionsSelected(page);
            if (ruleOptions.Count() <= 0)
            {
                return false;
            }
            int value = (int)ruleOptions.GetValue(0);
            if (operador == "+")
                return optionsSelected.Contains(value);

            if (operador == "-")
                return !optionsSelected.Contains(value);
            else if (string.IsNullOrEmpty(operador)) {
                return optionsSelected.Count == 0;
            } else {
                return false;
            }
        }

        //private boolean isSatisfiesAllTheRulesMultipleChoice(Rule rule, int page)
        //{
        //    String operator = rule.getOperator();
        //    List<Integer> ruleOptions = rule.getOptions();
        //    List<Integer> optionsSelected = getOptionsSelected(page);
        //    if (operator.equals(Marker.ANY_MARKER)) {
        //        return optionsSelected.size() == ((Question)this.surveyList.get(page)).getOptions().getValues().size();
        //    } else {
        //        if (operator.equals(Marker.ANY_NON_NULL_MARKER)) {
        //            return optionsSelected.containsAll(ruleOptions);
        //        }
        //        if (operator.equals("-")) {
        //            return !optionsSelected.containsAll(ruleOptions);
        //        } else if (operator.isEmpty()) {
        //            return optionsSelected.isEmpty();
        //        } else {
        //            return false;
        //        }
        //    }
        //}

        //private boolean isSatisfiesAllTheRulesOpenChoice(Rule rule, int page)
        //{
        //    boolean satisfiesAllTheRules = false;
        //    try
        //    {
        //        String operator = rule.getOperator();
        //        List<String> openOptionsValues = (List)this.openOptions.get(Integer.valueOf(page));
        //        for (Integer intValue : rule.getOptions())
        //        {
        //            int pos = intValue.intValue();
        //            int type = ((Option)((Question)this.surveyList.get(page)).getOptions().getValues().get(pos)).getType();
        //            if (type == 3)
        //            {
        //                satisfiesAllTheRules = compareValuesWithOperator(operator, (long)Integer.parseInt((String)openOptionsValues.get(pos)), (long)Integer.parseInt(rule.getValue()));
        //                continue;
        //            }
        //            else if (type == 1)
        //            {
        //                try
        //                {
        //                    Date optionDate = convertToDate((String)openOptionsValues.get(pos));
        //                    Date ruleDate = convertToDate(rule.getValue());
        //                    if (!(optionDate == null || ruleDate == null))
        //                    {
        //                        satisfiesAllTheRules = compareValuesWithOperator(operator, optionDate.getTime(), ruleDate.getTime());
        //                        continue;
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    continue;
        //                }
        //            }
        //            else if (type == 2)
        //            {
        //                try
        //                {
        //                    Date optionTime = convertToTime((String)openOptionsValues.get(pos));
        //                    Date ruleTime = convertToTime(rule.getValue());
        //                    if (!(optionTime == null || ruleTime == null))
        //                    {
        //                        satisfiesAllTheRules = compareValuesWithOperator(operator, optionTime.getTime(), ruleTime.getTime());
        //                        continue;
        //                    }
        //                }
        //                catch (Exception e2)
        //                {
        //                    continue;
        //                }
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //            if (satisfiesAllTheRules)
        //            {
        //                return satisfiesAllTheRules;
        //            }
        //        }
        //        return satisfiesAllTheRules;
        //    }
        //    catch (Exception e3)
        //    {
        //        Log.e(TAG, e3.getMessage(), e3);
        //        return false;
        //    }
        //}

        //private boolean compareValuesWithOperator(String operator, long optionValue, long ruleValue)
        //{
        //    if (operator.equals(">")) {
        //        if (optionValue > ruleValue)
        //        {
        //            return true;
        //        }
        //        return false;
        //    } else if (operator.equals("<")) {
        //        return optionValue < ruleValue;
        //    } else if (operator.equals("=")) {
        //        return optionValue == ruleValue;
        //    } else if (operator.equals(">=")) {
        //        return optionValue >= ruleValue;
        //    } else if (operator.equals("<=")) {
        //        return optionValue <= ruleValue;
        //    } else if (!operator.equals("!=")) {
        //        return false;
        //    } else {
        //        return optionValue != ruleValue;
        //    }
        //}

        private int pageFrom(int questaoId)
        {
            for (int i = 0; i < _questoes.Count; i++)
            {
                if (_questoes[i].getQuestaoId() == questaoId)
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