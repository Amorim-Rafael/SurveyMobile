using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using SurveyMobile.PCL.BusinessLayer.Model;
using SurveyMobile.PCL.ServiceAccessLayer;
using System.Collections.Generic;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer
{
    [Activity(Label = " Pesquisa", Icon = "@drawable/ic_short_logo")]
    public class PesquisaActivity: AppCompatActivity
    {
        private Toolbar toolbar;
        private ListView lv;
        private List<ListItem> listItems;
        ListItem listItem;
        static List<Pesquisa> listaPesquisa;
        ServiceWrapper serviceWrapper = new ServiceWrapper();

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            listaPesquisa = await serviceWrapper.DespesasPorPesquisa();
            SetContentView(Resource.Layout.activity_list);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //lv = FindViewById<ListView>(Resource.Id.lv);

            //listItems = new List<ListItem>();

            //foreach (var item in listaPesquisa)
            //{
            //    listItem = new ListItem();
            //    listItem.Title = item.Descricao;
            //    listItem.PageType = typeof(POPActivity);
            //    listItems.Add(listItem);
            //}

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