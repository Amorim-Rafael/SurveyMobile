using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace SurveyMobile.Droid.UserInterfaceLayer.Fragments
{
    public class ResumoFragment : Fragment
    {
        string[] titulos = new string[] { "Caixa", "Est.", "Real." };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.table, container, false);
            TableLayout tableLayout = view.FindViewById<TableLayout>(Resource.Id.detailsTable);            
            TableRow tableRow = new TableRow(this.Activity);
            tableRow.Id = 100;

            for (int i = 0; i < titulos.Length; i++)
            {
                TextView tituloTV = new TextView(this.Activity);
                tituloTV.Id = 200 + i;
                tituloTV.TextSize = 15;
                tituloTV.Text = titulos[i];

                tableRow.AddView(tituloTV);
            }

            tableLayout.AddView(tableRow);
            return view;
        }
    }
}