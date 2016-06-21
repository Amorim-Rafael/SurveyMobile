using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SurveyMobile.Droid.Domain.Survey;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = "QuestionarioActivity")]
    public class QuestionarioActivity : AppCompatActivity
    {
        private static string TAG;
        private Toolbar _toolbar;
        private Questionario _questionario;
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
                QuestionarioManager questionarioManager = QuestionarioManager.getInstance();
                questionarioManager.setQuestionarioActivity(this);

                if (bundle != null)
                {
                    _questionario = (Questionario)bundle.GetSerializable("questionario");
                    _numberPages = bundle.GetInt("numberPages");
                    _currentPage = bundle.GetInt("currentPage");
                    _backwardStack = (Stack<int>)bundle.GetSerializable("backwardStack");
                }
                else
                {
                    _questionario = (Questionario)Intent.GetSerializableExtra("questionario");
                    _numberPages = _questionario.Questoes.Count;
                    _currentPage = _numberPages > 0 ? 0 : -1;
                    _backwardStack = new Stack<int>();
                    questionarioManager.setStartQuestionario(DateTime.Now.Ticks);
                }
                ToolBar(_questionario.Descricao);
                PreencherInforQuestionario();
                FooterBar();
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
            //bundle.PutSerializable("questionario", (Java.IO.ISerializable)_questionario);
            //bundle.PutInt("numberPages", _numberPages);
            //bundle.PutInt("currentPage", _currentPage);
            //bundle.PutSerializable("backwardStack", (Java.IO.ISerializable)_backwardStack);
        }

        private void FooterBar()
        {
            _footerBar = FindViewById<LinearLayout>(Resource.Id.footer_bar);
            _prevButton = _footerBar.FindViewById<TextView>(Resource.Id.prev_button);
            _nextButton = _footerBar.FindViewById<TextView>(Resource.Id.next_button);
        }

        private void ToolBar(string title)
        {
            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _toolbar.Title = title;
            SetSupportActionBar(_toolbar);
            _toolbar.SetNavigationIcon(Resource.Drawable.ic_logo_back);
            //_toolbar.SetNavigationOnClickListener();
        }

        private void PreencherInforQuestionario()
        {
            QuestionarioManager questionarioManager = new QuestionarioManager();
            questionarioManager.setQuestionarioActivity(this);

            string json = "";

            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("Questionario.json")))
            {
                json = sr.ReadToEnd();
            }

            var questionario = JsonConvert.DeserializeObject<List<Questionario>>(json);

            questionarioManager.setQuestoesList(questionario[0].Questoes);

            _adapter = new QuestionarioPagerAdapter(SupportFragmentManager, questionario[0].Questoes);
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

            if (!QuestionarioManager.getInstance().ToNext(item))
            {

            }

            if (item > _viewPager.Adapter.Count)
                return;
            else
            {
                //view = 
            }
        }
    }
}