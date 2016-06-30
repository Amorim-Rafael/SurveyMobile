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
using Android.Runtime;
using static Android.App.AlertDialog;
using static Android.Views.View;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = "QuestionarioActivity")]
    public class QuestionarioActivity : AppCompatActivity
    {
        public static int SURVEY_ACTIVITY_REQUEST = 1;
        private static string TAG;
        //private Toolbar _toolbar;
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
                Init();
                SetupFooterBar();
                UpdateFooterBar();
            }
            catch (Exception e)
            {
                Log.Error(TAG, e.Message, e);
                Toast.MakeText(Application.Context, Resource.String.cannot_load_survey_msg, 0).Show();
                Finish();
            }
        }

        /// <summary>
        /// Substituindo o metodo OnSaveInstanceState()
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            Intent intent = new Intent();
            intent.PutExtra("questionario", JsonConvert.SerializeObject(_questionario));
            intent.PutExtra("numberPages", _numberPages);
            intent.PutExtra("currentPage", _currentPage);
            intent.PutExtra("backwardStack", JsonConvert.SerializeObject(_backwardStack));
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            //base.OnActivityResult(requestCode, resultCode, data);   

            if (requestCode == SURVEY_ACTIVITY_REQUEST && resultCode.HasFlag(Result.FirstUser) && data.HasExtra("reloadQuestionario"))
            {
                QuestionarioManager.GetInstance().Clear();
                if (data.GetBooleanExtra("reloadQuestionario", false))
                {
                    Finish();
                    return;
                }
                SetResult(Result.Ok);
                Finish();
            }
        }

        public override void OnBackPressed()
        {
            //base.OnBackPressed();
            Builder builder = new Builder(this, Resource.Style.AlertDialogStyle);
            builder.SetMessage(Resource.String.survey_are_you_shure_question_msg).SetPositiveButton(Resource.String.yes_text, Finaliza).SetNegativeButton(Resource.String.no_text, Finaliza);
            builder.Show();
        }

        private void Finaliza(object sender, DialogClickEventArgs e)
        {
            if (e.Which == -1)
                Finish();            
        }

        private void Init()
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

        private void SetupToolBar(string title)
        {
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = title;
            SetSupportActionBar(toolbar);
            //toolbar.SetNavigationIcon(Resource.Drawable.ic_logo_back);
            toolbar.Click += (sender, e) => {
                OnBackPressed();
            };
        }        

        private void SetupFooterBar()
        {
            _footerBar = FindViewById<LinearLayout>(Resource.Id.footer_bar);
            _prevButton = _footerBar.FindViewById<TextView>(Resource.Id.prev_button);
            _prevButton.Click += (sender, e) =>
            {
                PrevPage(_viewPager);
            };
            _nextButton = _footerBar.FindViewById<TextView>(Resource.Id.next_button);
            _nextButton.Click += (sender, e) =>
            {
                NextPage(_viewPager);
            };
        }

        public void PrevPage(View view)
        {
            if (_backwardStack.Count > 0)
            {
                int prevPage = _backwardStack.Pop();
                _viewPager.SetCurrentItem(prevPage, _questionario[0].Fluxo.PassarAutomatico);
                _currentPage = prevPage;
                _progressBar.Progress = prevPage + SURVEY_ACTIVITY_REQUEST;
                _progressText.Text = ("Perg. " + (prevPage + SURVEY_ACTIVITY_REQUEST) + " de " + _numberPages);
                UpdateFooterBar();
            }
        }

        public void NextPage(View view)
        {
            int current = _viewPager.CurrentItem;

            if (!QuestionarioManager.GetInstance().ProceedToNext(current))
                Toast.MakeText(this, "Escolha pelo menos uma op\u00e7\u00e3o.", 0).Show();
            else if (current >= _numberPages - 1)
                OpenFinishSurveyActivity();
            else if (current < _viewPager.Adapter.Count)
            {
                int nextPage = current + SURVEY_ACTIVITY_REQUEST;
                List<Logica> logica = _questionario[0].Logica;
                if (logica != null && logica.Count > 0)
                    nextPage = QuestionarioManager.GetInstance().NextPage(current, logica);
                if(nextPage == int.MaxValue)
                    OpenFinishSurveyActivity();
                else if (nextPage != -1)
                {
                    _backwardStack.Push(current);
                    _viewPager.SetCurrentItem(nextPage, _questionario[0].Fluxo.PassarAutomatico);
                    _currentPage = nextPage;
                    _progressBar.Progress = nextPage + SURVEY_ACTIVITY_REQUEST;
                    _progressText.Text = ("Perg. " + (nextPage + SURVEY_ACTIVITY_REQUEST) + " de " + _numberPages);
                    UpdateFooterBar();
                }
            }
        }

        private void OpenFinishSurveyActivity()
        {
            QuestionarioManager questionaryManager = QuestionarioManager.GetInstance();
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
    }
}