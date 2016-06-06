using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace SurveyMobile.Droid.UserInterfaceLayer.Fragments
{
    public class ResumoFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle bundle)
        {
            base.OnCreateView(inflater, container, bundle);

            View view = inflater.Inflate(Resource.Layout.Table, container, false);
            TableLayout tableLayout = view.FindViewById<TableLayout>(Resource.Id.detailsTable);
            string[] titulos = new string[] { "Caixa", "Est.", "Real." };
            TableRow tableRow = new TableRow(this.Activity);
            tableRow.Id = 100;

            for (int i = 0; i < 3; i++)
            {
                TextView tituloTV = new TextView(this.Activity);
                tituloTV.Id = 200 + i;
                tituloTV.TextSize = 30;
                tituloTV.Text = titulos[i];

                tableRow.AddView(tituloTV);

            }

            tableLayout.AddView(tableRow);            
            return view;

            #region antigo
            //listItems = new List<ListItem> {
            //                    new ListItem {Title = "Coordenador", PageType = null},
            //                    new ListItem {Title = "Pesquisador 1", PageType = null},
            //                    new ListItem {Title = "Pesquisador 2", PageType = null},
            //                    new ListItem {Title = "Pesquisador 3", PageType = null}
            //};

            //var view = inflater.Inflate(Resource.Layout.ListFragment, container, false);
            //ListView list = (ListView)view.FindViewById(Resource.Id.listView1);
            //ListItemAdapter adapter = new ListItemAdapter(this.Activity, listItems);
            //list.SetAdapter(adapter);
            #endregion
        }
    }
}