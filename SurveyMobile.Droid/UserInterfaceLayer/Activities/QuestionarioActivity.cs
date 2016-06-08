using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using SurveyMobile.PCL.BusinessLayer.Model;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.Widget;
using SurveyMobile.Droid.Domain;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = " Questionario", Icon = "@drawable/ic_short_logo")]
    public class QuestionarioActivity : AppCompatActivity
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
                                    new ListItem {Title = "Nova entrada", PageType = typeof(QuestionarioActivity)},
                                    new ListItem {Title = "Menu pesquisa", PageType = typeof(POPActivity)}
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