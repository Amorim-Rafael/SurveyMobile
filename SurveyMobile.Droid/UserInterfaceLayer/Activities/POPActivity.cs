using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using SurveyMobile.PCL.BusinessLayer.Model;
using System.Collections.Generic;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = " POP", Icon = "@drawable/ic_short_logo")]
    public class POPActivity : AppCompatActivity
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
            //                    new ListItem {Title = "Nova entrevista", PageType = typeof(QuestionarioActivity)},
            //                    new ListItem {Title = "Mapa", PageType = typeof(MapaActivity)},
            //                    new ListItem {Title = "Despesas", PageType = typeof(DespesaActivity)}
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