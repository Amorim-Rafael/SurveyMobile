using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
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
        private Button _btn;
        private List<ListItem> _listItems;

        private RecyclerView _rv;
        private CustomAdapter _adapter;
        private RecyclerView.LayoutManager _rvLayoutManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_list);            
            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _btn = FindViewById<Button>(Resource.Id.btnConsolidado);
            _btn.Visibility = Android.Views.ViewStates.Visible;
            _btn.Click += btnClickConsolidado;
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

        private void btnClickConsolidado(object sender, System.EventArgs e)
        {
            StartActivity(typeof(ConsolidadoActivity));
        }

        private void OnItemClick(object sender, int position)
        {
            StartActivity(_listItems[position].PageType);
        }
    }
}