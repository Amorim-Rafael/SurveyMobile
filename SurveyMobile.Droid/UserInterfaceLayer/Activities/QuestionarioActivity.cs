using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Newtonsoft.Json;
using SurveyMobile.Droid.Domain.Survey;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using System.Collections.Generic;
using System.IO;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = "QuestionarioActivity")]
    public class QuestionarioActivity : AppCompatActivity
    {
        private Toolbar _toolbar;
        //private Questionario _questionario;
        private QuestionaryPagerAdapter _adapter;
        private ViewPager _viewPager;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_questionario);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);
            SupportActionBar.Title = "Teste";
            _toolbar.SetNavigationIcon(2130837624);
            PreencherInforQuestioario();
        }

        private void PreencherInforQuestioario()
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

            questionarioManager.setQuestionarioList(questionario);

            //_adapter = new QuestionaryPagerAdapter()
            _viewPager = FindViewById<ViewPager>(Resource.Id.questions);

        }
    }
}