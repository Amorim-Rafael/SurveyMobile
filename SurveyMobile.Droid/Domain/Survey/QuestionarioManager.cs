using Android.Util;
using Newtonsoft.Json;
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
        private Dictionary<int, List<RespostaDynamic>> _respostaDynamic;
        private Dictionary<int, Dictionary<int, string>> _gridOptions;
        private Dictionary<int, int> _lastFormPositionGrid;
        private Dictionary<int, int> _lastIds;
        private Dictionary<int, List<string>> _openOptions;
        private Dictionary<int, List<string>> _respostaSelected = new Dictionary<int, List<string>>();
        private static List<Questao> _questoes;
        private long _startQuestionario;
        private QuestionarioActivity _questionarioActivity;


        //public QuestionarioManager()
        //{
        //    TAG = "QuestionarioManager";
        //    _questionarioAtual = new SendQuestionario();
        //    _respostaDynamic = new Dictionary<int, List<RespostaDynamic>>();
        //    _gridOptions = new Dictionary<int, Dictionary<int, string>>();
        //    _lastFormPositionGrid = new Dictionary<int, int>();
        //    _lastIds = new Dictionary<int, int>();
        //    _openOptions = new Dictionary<int, List<string>>();
        //    _respostaSelected = new Dictionary<int, List<string>>();
        //    questoes = new List<Questao>();
        //}

        public static QuestionarioManager GetInstance()
        {
            if (instance == null)
            {
                instance = new QuestionarioManager();
            }

            return instance;
        }

        #region Getters
        public QuestionarioActivity GetQuestionarioActivity()
        {
            return _questionarioActivity;
        }

        public List<Questao> getQuestoesList(List<Questao> questoes)
        {
            return questoes;
        }

        public List<int> GetRespostaSelected(int page)
        {
            List<int> option = new List<int>();
            if (_respostaSelected.ContainsKey(page))
                return _respostaSelected[page].Select(s => int.Parse(s)).ToList();

            return option;
        }
        #endregion

        #region Setters
        public void SetQuestionarioActivity(QuestionarioActivity questionarioActivity)
        {
            _questionarioActivity = questionarioActivity;
        }

        public void SetQuestoesList(List<Questao> questoes)
        {
            _questoes = questoes;
        }
        #endregion



        public void AddRespostaSelected(int page, int option)
        {
            List<string> options = _respostaSelected[page];
            if (options == null)
                options = new List<string>();

            options.Add(option.ToString());

            _respostaSelected.Add(page, options);
        }

        public void UpdateFirstRespostaSelected(int page, int option)
        {
            List<string> respostas = _respostaSelected.Count > 0 ? _respostaSelected[page] : _respostaSelected.SelectMany(r => r.Value).ToList();
            if (respostas == null)
            {
                respostas = new List<string>();
                respostas.Add(option.ToString());
            }
            else
                respostas.Insert(0, option.ToString());

            _respostaSelected.Add(page, respostas);

            //List<string> options;
            //if (_respostaSelected.Count > 0)
            //{
            //    options = _respostaSelected[page];
            //    if (options == null)
            //    {
            //        options = new List<string>();
            //        options.Add(option.ToString());
            //    }
            //    else
            //        options.Insert(0, option.ToString());
            //}
            //else
            //{
            //    options = new List<string>();
            //    options.Add(option.ToString());
            //}
            //_respostaSelected.Add(page, options);
        }

        public void RemoveRespostaSelected(int page, int option)
        {
            List<string> options = _respostaSelected[page];
            if (options != null)
            {
                options.Remove(option.ToString());
                _respostaSelected.Add(page, options);
            }
        }

        public int LastRespostaSelected(int page)
        {
            if (!_respostaSelected.ContainsKey(page))
                return -1;

            List<string> options = _respostaSelected[page];
            if (options != null)
                return -1;

            return Convert.ToInt16(options[options.Count - 1]);
        }

        public void InitDynamicList(int page)
        {
            _respostaDynamic.Add(page, new List<RespostaDynamic>());
        }

        public void AddDynamicOption(int page, RespostaDynamic resposta)
        {
            List<RespostaDynamic> respostaDynamic = _respostaDynamic[page];
            respostaDynamic.Add(resposta);
            _respostaDynamic.Add(page, respostaDynamic);
        }

        public void RemoveDynamicResposta(int page, int id)
        {
            List<RespostaDynamic> respostaDynamic = _respostaDynamic[page];
            if (respostaDynamic != null)
            {
                foreach (RespostaDynamic resposta in respostaDynamic)
                {
                    if (resposta.Id == id)
                        respostaDynamic.Remove(resposta);
                }
                _respostaDynamic.Add(page, respostaDynamic);
            }
        }

        public List<RespostaDynamic> GetDynamicList(int page)
        {
            List<RespostaDynamic> respostaDynamic = new List<RespostaDynamic>();
            if (_respostaDynamic.ContainsKey(page))
                return _respostaDynamic[page];
            return respostaDynamic;
        }

        private List<string> InitOpenRespostaList(int page, int size)
        {
            List<string> options = new List<string>();
            for (int i = 0; i < size; i++)
            {
                options.Add(i.ToString());
            }
            _openOptions.Add(page, options);
            return options;
        }

        public void UpdateOpenResposta(int page, int option, string text)
        {
            List<string> options = _openOptions[page];
            if (options == null)
                options = InitOpenRespostaList(page, ((Questao)_questoes[page]).getResposta().Count);// ((Question)this.surveyList.get(page)).getOptions().getValues().size());

            options.Insert(option, text);
            _openOptions.Add(page, options);
        }

        public string GetOpenResposta(int page, int option)
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

        public void UpdateGridResposta(int page, int id, string text)
        {
            Dictionary<int, string> options = _gridOptions[page];
            if (options == null)
                options = new Dictionary<int, string>();

            options.Add(id, text);
            _gridOptions.Add(page, options);
        }

        public string GetGridOption(int page, int option)
        {
            string ret = "";//BuildConfig.VERSION_NAME;
            Dictionary<int, string> options = _gridOptions[page];
            if (options == null)
                return ret;

            string value = options[option];
            if (value == null)
                return ret;

            return value;
        }

        public int GetLastFormPositionGrid(int page)
        {
            int lastPosition = _lastFormPositionGrid[page];
            if (lastPosition == null)
                return 0;

            return lastPosition;
        }

        public void UpdateFormPosition(int page, int formPosition)
        {
            _lastFormPositionGrid.Add(page, formPosition);
        }

        public void RemoveGrid(int page, int formPosition, int formSize)
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

        public int RespostaDynamicGenerateId(int id, int page)
        {
            if (_lastIds.ContainsKey(page))
                id = _lastIds[page] + 1;

            _lastIds.Add(page, id);
            return id;
        }

        public void Clear()
        {
            _respostaSelected = new Dictionary<int, List<string>>();
            _respostaDynamic = new Dictionary<int, List<RespostaDynamic>>();
            _openOptions = new Dictionary<int, List<string>>();
            _gridOptions = new Dictionary<int, Dictionary<int, string>>();
            _lastFormPositionGrid = new Dictionary<int, int>();
            _lastIds = new Dictionary<int, int>();
            _startQuestionario = 0;
            _questionarioAtual = new SendQuestionario();
        }

        public bool ProceedToNext(int current)
        {

            if (_questoes[current].Obrigatoria)
            {
                try
                {
                    if (_respostaSelected[current].Count > 0)
                        return true;
                    return false;
                }
                catch (Exception e)
                {
                    Log.Error(TAG, e.Message, e);
                    return false;
                }
            }
            return false;
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
            List<int> optionsSelected = GetRespostaSelected(page);
            if (ruleOptions.Count() <= 0)
                return false;

            int value = (int)ruleOptions.GetValue(0);
            if (operador == "+")
                return optionsSelected.Contains(value);

            if (operador == "-")
                return !optionsSelected.Contains(value);
            else if (string.IsNullOrEmpty(operador))
                return optionsSelected.Count == 0;
            else
                return false;
        }

        private bool isSatisfiesAllTheRulesMultipleChoice(Regra regra, int page)
        {
            string operador = regra.Operador;
            int[] ruleOptions = regra.Opcoes;
            List<int> optionsSelected = GetRespostaSelected(page);
            if (operador == "*")
                return optionsSelected.Count == _questoes[page].getResposta().Count;//((Question)this.surveyList.get(page)).getOptions().getValues().size();
            else
            {
                if (operador == "+")
                    return optionsSelected.Except(ruleOptions).Any();
                if (operador == "-")
                    return !optionsSelected.Except(ruleOptions).Any();
                else if (string.IsNullOrEmpty(operador))
                    return optionsSelected.Count == 0;
                else
                    return false;
            }
        }

        private bool isSatisfiesAllTheRulesOpenChoice(Regra regra, int page)
        {
            bool satisfiesAllTheRules = false;
            try
            {
                string operador = regra.Operador;
                List<string> openOptionsValues = _openOptions[page];
                foreach (int opcao in regra.Opcoes)
                {
                    int pos = opcao;
                    int type = _questoes[page].TipoQuestao;
                    if (type == 3)
                    {
                        satisfiesAllTheRules = compareValuesWithOperator(operador, Convert.ToInt64(openOptionsValues[pos]), regra.Compativel);
                        continue;
                    }
                    else if (type == 1)
                    {
                        try
                        {
                            DateTime optionDate = convertToDate(openOptionsValues[pos]);
                            DateTime ruleDate = convertToDate(regra.Compativel.ToString());
                            if (!(optionDate == null || ruleDate == null))
                            {
                                satisfiesAllTheRules = compareValuesWithOperator(operador, Convert.ToInt64(optionDate.GetDateTimeFormats()), Convert.ToInt64(ruleDate.GetDateTimeFormats()));
                                continue;
                            }
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                    else if (type == 2)
                    {
                        try
                        {
                            DateTime optionTime = convertToTime(openOptionsValues[pos]);
                            DateTime ruleTime = convertToTime(regra.Compativel.ToString());
                            if (!(optionTime == null || ruleTime == null))
                            {
                                satisfiesAllTheRules = compareValuesWithOperator(operador, Convert.ToInt64(optionTime.GetDateTimeFormats()), Convert.ToInt64(ruleTime.GetDateTimeFormats()));
                                continue;
                            }
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                    if (satisfiesAllTheRules)
                    {
                        return satisfiesAllTheRules;
                    }
                }
                //for (int i = 0; i < regra.Opcoes.Count(); i++)
                //{
                //    int pos = i;
                //    int type = _questoes[page].TipoQuestao;
                //    if (type == 3)
                //    {
                //        satisfiesAllTheRules = compareValuesWithOperator(operador, Convert.ToInt64(openOptionsValues[pos]), regra.Compativel);
                //        continue;
                //    }
                //    else if (type == 1)
                //    {
                //        try
                //        {
                //            DateTime optionDate = convertToDate(openOptionsValues[pos]);
                //            DateTime ruleDate = convertToDate(regra.Compativel.ToString());
                //            if (!(optionDate == null || ruleDate == null))
                //            {
                //                satisfiesAllTheRules = compareValuesWithOperator(operador, Convert.ToInt64(optionDate.GetDateTimeFormats()), Convert.ToInt64(ruleDate.GetDateTimeFormats()));
                //                continue;
                //            }
                //        }
                //        catch (Exception e)
                //        {
                //            continue;
                //        }
                //    }
                //    else if (type == 2)
                //    {
                //        try
                //        {
                //            DateTime optionTime = convertToTime(openOptionsValues[pos]);
                //            DateTime ruleTime = convertToTime(regra.Compativel.ToString());
                //            if (!(optionTime == null || ruleTime == null))
                //            {
                //                satisfiesAllTheRules = compareValuesWithOperator(operador, Convert.ToInt64(optionTime.GetDateTimeFormats()), Convert.ToInt64(ruleTime.GetDateTimeFormats()));
                //                continue;
                //            }
                //        }
                //        catch (Exception e)
                //        {
                //            continue;
                //        }
                //    }
                //    else
                //    {
                //        continue;
                //    }
                //    if (satisfiesAllTheRules)
                //    {
                //        return satisfiesAllTheRules;
                //    }
                //}
                return satisfiesAllTheRules;
            }
            catch (Exception e)
            {
                Log.Error(TAG, e.Message, e);
                return false;
            }
        }

        private bool compareValuesWithOperator(string operador, long optionValue, long ruleValue)
        {
            if (operador == ">")
            {
                if (optionValue > ruleValue)
                    return true;
                return false;
            }
            else if (operador == "<")
                return optionValue < ruleValue;
            else if (operador == "=")
                return optionValue == ruleValue;
            else if (operador == ">=")
                return optionValue >= ruleValue;
            else if (operador == "<=")
                return optionValue <= ruleValue;
            else if (!(operador == "!="))
                return false;
            else
                return optionValue != ruleValue;
        }

        private int pageFrom(int questaoId)
        {
            for (int i = 0; i < _questoes.Count; i++)
            {
                if (_questoes[i].getQuestaoId() == questaoId)
                    return i;
            }
            return -1;
        }

        public void SetStartQuestionario(long startQuestionario)
        {
            _startQuestionario = startQuestionario;
        }

        public void FinishQuestionario(long finishQuestionario)
        {
            _questionarioAtual.Finalizado = finishQuestionario;
            _questionarioAtual.Duracao = finishQuestionario - _startQuestionario;
        }

        public void UpdateGpsPosition(string latitude, string longitude)
        {
            _questionarioAtual.Lat = latitude;
            _questionarioAtual.Lng = longitude;
        }

        public void UpdateBatteryPct(string batteryPct)
        {
            _questionarioAtual.BatteryPct = batteryPct;
        }

        public Questionario GenerateQuestionario(int id)
        {
            _questionarioAtual.Questoes = GenerateQuestaoToSend();
            _questionarioAtual.Id = id;
            Questionario entity = new Questionario();
            entity.QuestionarioId = id;
            entity.Json = JsonConvert.SerializeObject(_questionarioAtual);
            return entity;
        }

        private List<SendQuestao> GenerateQuestaoToSend()
        {
            List<SendQuestao> sendQuestoes = new List<SendQuestao>();
            for (int i = 0; i < _questoes.Count; i++)
            {
                Questao q = _questoes[i];
                List<SendResposta> respostas = GenerateRespostaToSend(q.TipoQuestao, i);
                if (respostas.Count > 0)
                {
                    SendQuestao sendQuestao = new SendQuestao();
                    sendQuestao.Id = q.QuestaoId;
                    sendQuestao.Respostas = respostas;
                    sendQuestoes.Add(sendQuestao);
                }
            }
            return sendQuestoes;
        }

        private List<SendResposta> GenerateRespostaToSend(int type, int page)
        {
            List<SendResposta> options = new List<SendResposta>();
            if (type == 0)
            {
                return GenerateOptionsToSendSingleChoice(page);
            }
            if (type == 1)
            {
                return GenerateOptionsToSendMultipleChoice(page);
            }
            if (type == 2)
            {
                return GenerateOptionsToSendOpenChoice(page);
            }
            if (type == 3)
            {
                return GenerateOptionsToSendGridChoice(page);
            }
            return options;
        }

        private List<SendResposta> GenerateOptionsToSendSingleChoice(int page)
        {
            List<SendResposta> sendRespostas = new List<SendResposta>();
            List<Resposta> respostas = _questoes[page].Respostas;
            if (GetRespostaSelected(page).Count > 0)
            {
                SendResposta sendResposta;
                int pos = GetRespostaSelected(page)[0];
                if (pos < respostas.Count)
                {
                    sendResposta = new SendResposta();
                    sendResposta.Descricao = respostas[pos].Descricao;
                    sendRespostas.Add(sendResposta);
                }

                foreach (var resposta in GetDynamicList(page))
                {
                    if (GetRespostaSelected(page).Contains(resposta.Id))
                    {
                        sendResposta = new SendResposta();
                        sendResposta.Descricao = resposta.Descicao;
                        sendRespostas.Add(sendResposta);
                    }
                }
            }
            return sendRespostas;
        }

        private List<SendResposta> GenerateOptionsToSendMultipleChoice(int page)
        {
            List<SendResposta> sendRespostas = new List<SendResposta>();
            List<Resposta> respostas = _questoes[page].Respostas;
            SendResposta sendResposta;
            foreach (int pos in GetRespostaSelected(page))
            {
                if (pos < respostas.Count)
                {
                    sendResposta = new SendResposta();
                    sendResposta.Descricao = respostas[pos].Descricao;
                    sendRespostas.Add(sendResposta);
                }
            }

            foreach (var rd in GetDynamicList(page))
            {
                if (GetRespostaSelected(page).Contains(rd.Id))
                {
                    sendResposta = new SendResposta();
                    sendResposta.Descricao = rd.Descicao;
                    sendRespostas.Add(sendResposta);
                }
            }
            return sendRespostas;
        }

        private List<SendResposta> GenerateOptionsToSendOpenChoice(int page)
        {
            List<SendResposta> sendRespostas = new List<SendResposta>();
            List<Resposta> respostas = _questoes[page].Respostas;
            SendResposta sendResposta;
            for (int i = 0; i < respostas.Count; i++)
            {
                sendResposta = new SendResposta();
                sendResposta.RespostaId = respostas[i].RespostaId;
                sendResposta.Descricao = GetOpenResposta(page, i);
                sendRespostas.Add(sendResposta);
            }
            return sendRespostas;
        }

        private List<SendResposta> GenerateOptionsToSendGridChoice(int page)
        {
            List<SendResposta> sendRespostas = new List<SendResposta>();
            List<Resposta> respostas = _questoes[page].Respostas;
            for (int i = 0; i <= GetLastFormPositionGrid(page); i++)
            {
                int formPosition = respostas.Count * i;
                int relativePos = 0;
                for (int j = formPosition; j < respostas.Count + formPosition; j++)
                {
                    if (!string.IsNullOrEmpty(GetGridOption(page, j)))
                    {
                        int relativePos2 = relativePos + 1;
                        SendResposta sendResposta = new SendResposta();
                        sendResposta.RespostaId = respostas[relativePos].RespostaId;
                        sendResposta.Descricao = GetGridOption(page, j);
                        sendResposta.GridPosition = i + 1;
                        sendRespostas.Add(sendResposta);
                        relativePos = relativePos2;
                    }
                }
            }
            return sendRespostas;
        }

        private DateTime convertToDate(string dateString)
        {
            DateTime convertedDate = new DateTime();
            try
            {
                convertedDate = Convert.ToDateTime(dateString);
            }
            catch (Exception e)
            {
                Log.Error(TAG, e.Message, e);
                //e.PrintStackTrace();
            }
            return Convert.ToDateTime(convertedDate.ToString("dd/MM/yyyy"));
        }

        private DateTime convertToTime(string dateString)
        {
            DateTime convertedDate = new DateTime();
            try
            {
                convertedDate = Convert.ToDateTime(dateString);
            }
            catch (Exception e)
            {
                Log.Error(TAG, e.Message, e);
                //e.printStackTrace();
            }
            return Convert.ToDateTime(convertedDate.ToString("HH:mm"));
        }
    }
}