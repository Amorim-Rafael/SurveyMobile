using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using SurveyMobile.PCL.BusinessLayer.Model;
using System.Collections.Generic;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SurveyMobile.Droid.UserInterfaceLayer
{
    [Activity(Label = " Menu Principal", Icon = "@drawable/ic_short_logo")]
    public class MenuPrincipalActivity : AppCompatActivity
    {
        private Toolbar toolbar;
        //private ListView lv;        
        private List<ListItem> listItems;

        private RecyclerView rv;
        private RecyclerView.Adapter rvAdapter;
        private RecyclerView.LayoutManager rvLayoutManager;
        private string[] itens;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_list);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            rv = FindViewById<RecyclerView>(Resource.Id.rv);
            rv.HasFixedSize = true;

            rvLayoutManager = new LinearLayoutManager(this);
            rv.SetLayoutManager(rvLayoutManager);
            //lv = FindViewById<ListView>(Resource.Id.lv);

            listItems = new List<ListItem> {
                                new ListItem {Title = "Ver Pesquisas", PageType = typeof(PesquisaActivity)},
                                new ListItem {Title = "Configurações", PageType = typeof(MenuPrincipalActivity)}
            };
            //itens = new string[2];
            //itens[0] = "Ver Pesquisas";
            //itens[1] = "Configurações";

            rvAdapter = new MenuPrincipalAdapter(listItems);
            rv.SetAdapter(rvAdapter);

            //lv.Adapter  = new ListItemAdapter(this, listItems);
            //lv.ItemClick += Lv_ItemClick;

            
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //StartActivity(listItems[e.Position].PageType);
        }
    }
}