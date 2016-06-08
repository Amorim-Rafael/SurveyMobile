using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using SurveyMobile.PCL.BusinessLayer.Model;
using System.Collections.Generic;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = " Despesa", Icon = "@drawable/icon")]
    public class DespesaActivity : AppCompatActivity
    {
        private Toolbar _toolbar;
        private List<ListItem> _listItems;

        private RecyclerView _rv;
        private CustomAdapter _adapter;
        private RecyclerView.LayoutManager _rvLayoutManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_list);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(_toolbar);

            _rv = FindViewById<RecyclerView>(Resource.Id.rv);
            _rv.HasFixedSize = true;

            _rvLayoutManager = new LinearLayoutManager(this);
            _rv.SetLayoutManager(_rvLayoutManager);

            _listItems = new List<ListItem> {
                                        new ListItem {Title = "Coordenador", PageType = null},
                                        new ListItem {Title = "Pesquisador 1", PageType = null},
                                        new ListItem {Title = "Pesquisador 2", PageType = null},
                                        new ListItem {Title = "Pesquisador 3", PageType = null}
            };

            _adapter = new CustomAdapter(_listItems, this.Resources);
            _adapter.ItemClick += OnItemClick;
            _rv.SetAdapter(_adapter);
        }

        private void OnItemClick(object sender, int position)
        {
            StartActivity(_listItems[position].PageType);
        }
        //List<ListItem> listItems;
        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);

        //    listItems = new List<ListItem> {
        //                        new ListItem {Title = "Coordenador", PageType = null},
        //                        new ListItem {Title = "Pesquisador 1", PageType = null},
        //                        new ListItem {Title = "Pesquisador 2", PageType = null},
        //                        new ListItem {Title = "Pesquisador 3", PageType = null}
        //    };
        //    ListAdapter = new ListItemAdapter(this, listItems);

        //    FrameLayout footerLayout = (FrameLayout)LayoutInflater.Inflate(Resource.Layout.ListItemFooter, null);
        //    Button button = (Button)footerLayout.FindViewById(Resource.Id.btnConsolidado);
        //    button.Click += delegate {
        //        StartActivity(typeof(ConsolidadoActivity));
        //    };

        //    ListView list = this.ListView as ListView;
        //    list.AddFooterView(footerLayout);

        //}        

        //protected override void OnListItemClick(ListView l, View v, int position, long id)
        //{
        //    StartActivity(listItems[position].PageType);
        //}
    }
}