using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using SurveyMobile.PCL.BusinessLayer.Model;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = " Questionario", Icon = "@drawable/ic_short_logo")]
    public class QuestionarioActivity : AppCompatActivity
    {
        private Toolbar toolbar;
        private ListView lv;
        private List<ListItem> listItems;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_list);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //lv = FindViewById<ListView>(Resource.Id.lv);

            //listItems = new List<ListItem> {
            //                    new ListItem {Title = "Nova entrada", PageType = typeof(QuestionarioActivity)},
            //                    new ListItem {Title = "Menu pesquisa", PageType = typeof(POPActivity)}
            //};

            //lv.Adapter = new ListItemAdapter(this, listItems);
            //lv.ItemClick += Lv_ItemClick;

            SetSupportActionBar(toolbar);
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            StartActivity(listItems[e.Position].PageType);
        }
    }
}