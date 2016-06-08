using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Newtonsoft.Json;
using SurveyMobile.Droid.Domain;
using SurveyMobile.Droid.UserInterfaceLayer.Activities;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using SurveyMobile.PCL.BusinessLayer.Model;
using System.Collections.Generic;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer
{
    [Activity(Label = " Pesquisa", Icon = "@drawable/ic_short_logo")]
    public class PesquisaActivity: AppCompatActivity
    {
        private Toolbar _toolbar;
        private List<ListItem> _listItems;
        private ListItem _listItem;

        private RecyclerView _rv;
        private CustomAdapter _adapter;
        private RecyclerView.LayoutManager _rvLayoutManager;
        AppPreferences ap;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ap = new AppPreferences(this);

            SetContentView(Resource.Layout.activity_list);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(_toolbar);

            _rv = FindViewById<RecyclerView>(Resource.Id.rv);
            _rv.HasFixedSize = true;

            _rvLayoutManager = new LinearLayoutManager(this);
            _rv.SetLayoutManager(_rvLayoutManager);
            _listItems = new List<ListItem>();
            
            var listaJson = ap.GetString("listaPesquisa", "");
            var listaPesquisas = JsonConvert.DeserializeObject<List<Pesquisa>>(listaJson);

            foreach (var item in listaPesquisas)
            {
                _listItem = new ListItem();
                _listItem.Title = item.Descricao;
                _listItem.PageType= typeof(POPActivity);
                _listItems.Add(_listItem);
            }            

            _adapter = new CustomAdapter(_listItems, this.Resources);
            _adapter.ItemClick += OnItemClick;
            _rv.SetAdapter(_adapter);
        }

        private void OnItemClick(object sender, int position)
        {
            string title = _listItems[position].Title;
            ap.PutString("title", title);
            ap.Commit();

            GlobalParams.getInstance().setTitle(title);

            StartActivity(_listItems[position].PageType);
        }
    }
}