using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using SurveyMobile.PCL.BusinessLayer.Model;
using System.Collections.Generic;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = " Despesa", Icon = "@drawable/icon")]
    public class DespesaActivity : ListActivity
    {
        List<ListItem> listItems;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
                        
            listItems = new List<ListItem> {
                                new ListItem {Title = "Coordenador", PageType = null},
                                new ListItem {Title = "Pesquisador 1", PageType = null},
                                new ListItem {Title = "Pesquisador 2", PageType = null},
                                new ListItem {Title = "Pesquisador 3", PageType = null}
            };
            ListAdapter = new ListItemAdapter(this, listItems);

            FrameLayout footerLayout = (FrameLayout)LayoutInflater.Inflate(Resource.Layout.ListItemFooter, null);
            Button button = (Button)footerLayout.FindViewById(Resource.Id.btnConsolidado);
            button.Click += delegate {
                StartActivity(typeof(ConsolidadoActivity));
            };

            ListView list = this.ListView as ListView;
            list.AddFooterView(footerLayout);

        }        

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            StartActivity(listItems[position].PageType);
        }
    }
}