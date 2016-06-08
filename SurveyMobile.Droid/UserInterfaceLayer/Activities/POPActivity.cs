using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using SurveyMobile.Droid.Domain;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using SurveyMobile.PCL.BusinessLayer.Model;
using System.Collections.Generic;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Icon = "@drawable/ic_short_logo")]
    public class POPActivity : AppCompatActivity
    {
        private Toolbar _toolbar;
        private List<ListItem> _listItems;

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

            SupportActionBar.Title = GlobalParams.getInstance().getTitle();

            _rv = FindViewById<RecyclerView>(Resource.Id.rv);
            _rv.HasFixedSize = true;

            _rvLayoutManager = new LinearLayoutManager(this);
            _rv.SetLayoutManager(_rvLayoutManager);

            _listItems = new List<ListItem> {
                                    new ListItem {Title = "Nova entrevista", PageType = typeof(QuestionarioActivity)},
                                    new ListItem {Title = "Mapa", PageType = typeof(MapaActivity)},
                                    new ListItem {Title = "Despesas", PageType = typeof(DespesaActivity)}
            };

            _adapter = new CustomAdapter(_listItems, this.Resources);
            _adapter.ItemClick += OnItemClick;
            _rv.SetAdapter(_adapter);
        }

        private void OnItemClick(object sender, int position)
        {
            StartActivity(_listItems[position].PageType);
        }
    }
}