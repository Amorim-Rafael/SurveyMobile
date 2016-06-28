using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Newtonsoft.Json;
using SurveyMobile.Droid.Domain.Survey;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = "QuestionarioActivity")]
    public class QuestionarioActivity : AppCompatActivity
    {
        public static int SURVEY_ACTIVITY_REQUEST = 1;
        private static string TAG;
        private Toolbar _toolbar;
        //private Questionario _questionario;
        private List<Questionario> _questionario;
        private QuestionarioPagerAdapter _adapter;
        private ProgressBar _progressBar;
        private ViewPager _viewPager;
        private int _numberPages;
        private int _currentPage;
        private Stack<int> _backwardStack;
        private LinearLayout _footerBar;
        private TextView _nextButton;
        private TextView _prevButton;
        private TextView _progressText;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_questionario);
            TAG = Application.PackageName.ToString();
            try
            {
                QuestionarioManager questionarioManager = QuestionarioManager.GetInstance();
                questionarioManager.SetQuestionarioActivity(this);
                string json = "";

                AssetManager assets = this.Assets;
                using (StreamReader sr = new StreamReader(assets.Open("Questionario.json")))
                {
                    json = sr.ReadToEnd();
                }

                var questionario = JsonConvert.DeserializeObject<List<Questionario>>(json);

                if (bundle != null)
                {
                    //_questionario = (Questionario)bundle.GetSerializable("questionario");
                    _questionario = questionario;//JsonConvert.DeserializeObject<List<Questionario>>(bundle.GetSerializable("questionario").ToString());
                    _numberPages = bundle.GetInt("numberPages");
                    _currentPage = bundle.GetInt("currentPage");
                    _backwardStack = (Stack<int>)bundle.GetSerializable("backwardStack");
                }
                else
                {
                    //_questionario = (Questionario)_intent.GetSerializableExtra("questionario");
                    _questionario = questionario;//JsonConvert.DeserializeObject<List<Questionario>>(_intent.GetSerializableExtra("questionario").ToString());
                    _numberPages = _questionario[0].Questoes.Count;
                    _currentPage = _numberPages > 0 ? 0 : -1;
                    _backwardStack = new Stack<int>();
                    questionarioManager.SetStartQuestionario(DateTime.Now.Ticks);
                }

                SetupToolBar(_questionario[0].Descricao);
                PreencherInforQuestionario();
                SetupFooterBar();
            }
            catch (System.Exception e)
            {
                Log.Error(TAG, e.Message, e);
                Toast.MakeText(Application.Context, Resource.String.cannot_load_survey_msg, 0).Show();
                Finish();
            }

            //_toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(_toolbar);
            //SupportActionBar.Title = "Teste";
            //_toolbar.SetNavigationIcon(2130837624);
            ////_questionario = (Questionario)bundle.GetSerializable("questionario");
            //PreencherInforQuestionario();//Init()
            //FooterBar();
        }

        protected override void OnSaveInstanceState(Bundle bundle)
        {
            base.OnSaveInstanceState(bundle);

            Intent intent = new Intent();
            intent.PutExtra("questionario", JsonConvert.SerializeObject(_questionario));
            intent.PutExtra("numberPages", _numberPages);
            intent.PutExtra("currentPage", _currentPage);
            intent.PutExtra("backwardStack", JsonConvert.SerializeObject(_backwardStack));
        }

        private void SetupToolBar(string title)
        {
            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _toolbar.Title = title;
            SetSupportActionBar(_toolbar);
            _toolbar.SetNavigationIcon(Resource.Drawable.ic_logo_back);
            //_toolbar.SetNavigationOnClickListener();
        }

        private void SetupFooterBar()
        {
            _footerBar = FindViewById<LinearLayout>(Resource.Id.footer_bar);
            _prevButton = _footerBar.FindViewById<TextView>(Resource.Id.prev_button);
            _nextButton = _footerBar.FindViewById<TextView>(Resource.Id.next_button);

            _nextButton.Click += (sender, e) => {
                NextPage(_viewPager);
            };
        }

        private void UpdateFooterBar()
        {
            if (_numberPages == 0)
            {
                _prevButton.Visibility = ViewStates.Gone;
                _nextButton.Visibility = ViewStates.Gone;
            }
            else if (_numberPages == SURVEY_ACTIVITY_REQUEST)
            {
                _prevButton.Visibility = ViewStates.Gone;
                _nextButton.Visibility = ViewStates.Visible;
                _nextButton.Text = Resources.GetString(Resource.String.finish_text);
            }
            else if (_currentPage == 0)
            {
                _prevButton.Visibility = ViewStates.Gone;
                _nextButton.Visibility = ViewStates.Visible;
                _nextButton.Text = Resources.GetString(Resource.String.next_text);
            }
            else if (_currentPage == _numberPages - 1)
            {
                _prevButton.Visibility = ViewStates.Visible;
                _nextButton.Visibility = ViewStates.Visible;
                _nextButton.Text = Resources.GetString(Resource.String.finish_text);
            }
            else
            {
                _prevButton.Visibility = ViewStates.Visible;
                _nextButton.Visibility = ViewStates.Visible;
                _nextButton.Text = Resources.GetString(Resource.String.next_text);
            }

            ((InputMethodManager)_nextButton.Context.GetSystemService("input_method")).HideSoftInputFromWindow(_nextButton.WindowToken, 0);
        }

        private void PreencherInforQuestionario()
        {
            QuestionarioManager questionarioManager = new QuestionarioManager();
            questionarioManager.SetQuestionarioActivity(this);

            questionarioManager.SetQuestoesList(_questionario[0].Questoes);

            _adapter = new QuestionarioPagerAdapter(SupportFragmentManager, _questionario[0].Questoes);
            _viewPager = FindViewById<ViewPager>(Resource.Id.questions);
            _viewPager.Adapter = _adapter;
            _progressBar = FindViewById<ProgressBar>(Resource.Id.survey_progress_bar);
            _progressBar.Max = _numberPages;
            _progressBar.Progress = _currentPage + 1;
            _progressText = FindViewById<TextView>(Resource.Id.survey_progress_text);
            _progressText.Text = (new StringBuilder()).Append("Perg. ").Append(_currentPage + 1).Append(" de ").Append(_numberPages).ToString();
        }

        public void NextPage(View view)
        {
            int item = _viewPager.CurrentItem;

            if (!QuestionarioManager.GetInstance().ProceedToNext(item))
                Toast.MakeText(this, "Escolha pelo menos uma op\u00e7\u00e3o.", 0).Show();
            else if (item >= _numberPages - 1)
                OpenFinishSurveyActivity();
            else if (item < _viewPager.Adapter.Count)
            {
                int nextPage = item + SURVEY_ACTIVITY_REQUEST;
                List<Logica> logica = _questionario[0].Logica;
                if (logica != null && logica.Count > 0)
                {
                    //nextPage = QuestionarioManager.getInstance().new
                }
            }

            if (item > _viewPager.Adapter.Count)
                return;
            else
            {
                //view = 
            }
        }

        private void OpenFinishSurveyActivity()
        {
            QuestionarioManager questionaryManager = new QuestionarioManager();
            questionaryManager.FinishQuestionario(DateTime.Now.Ticks);
            //Location location = getLastBestLocation();
            //if (location != null)
            //{
            //    questionaryManager.updateGpsPosition(location.getLatitude(), location.getLongitude());
            //}
            //questionaryManager.updateBatteryPct(getBatteryPct());
            try
            {
                //SurveyDataSource surveyDataSource = new SurveyDataSource(this);
                //surveyDataSource.open();
                //surveyDataSource.add(questionaryManager.generateEntity(this.survey.getId()));
                //surveyDataSource.close();
                //startActivityForResult(new Intent(this, FinishSurveyActivity.class), SURVEY_ACTIVITY_REQUEST);
            }
            catch (Exception e)
            {
                Log.Error(TAG, "N\u00e3o foi poss\u00edvel salvar a pesquisa.", e);
                Toast.MakeText(this, "Erro ao salvar a pesquisa. Contacte o suporte.", 0).Show();
            }
        }
    }
}