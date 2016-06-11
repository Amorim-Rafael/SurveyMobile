using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace SurveyMobile.Droid.UserInterfaceLayer.Fragments
{
    public class DetalheFragment : Fragment
    {
        string[] titulos = new string[] { "Caixa", "Coord.", "2200", "DT." };

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
            //return inflater.Inflate(Resource.Layout.fragment_detalhe, container, false);
        }

        //string[] titulos = new string[] { "Caixa", "Coord.", "2200", "DT." };
        //string[,] valores = new string[,] {
        //        { "Moto", "P 1", "-20", "--" },
        //        { "Hosp.", "P 3", "-180", "--" },
        //        { "Moto", "P 2", "-35", "--" },
        //        { "Moto", "P 1", "-15", "--" }
        //};

        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle bundle)
        //{
        //    base.OnCreateView(inflater, container, bundle);

        //    View view = inflater.Inflate(Resource.Layout.Table, container, false);
        //    TableLayout tableLayout = view.FindViewById<TableLayout>(Resource.Id.detailsTable);

        //    for (int j = 0; j < 2; j++)
        //    {
        //        TableRow tableRow = new TableRow(this.Activity);
        //        tableRow.Id = 100 + j;
        //        PreenchePorRow(j, tableRow);
        //        tableLayout.AddView(tableRow);
        //    }

        //    return view;
        //}

        //public void PreenchePorRow(int row, TableRow tableRow)
        //{            
        //    if (row == 0)
        //    {
        //        for (int i = 0; i < 4; i++)
        //        {
        //            TextView tituloTV = new TextView(this.Activity);
        //            tituloTV.Id = 200 + i;
        //            tituloTV.TextSize = 30;
        //            tituloTV.Text = titulos[i];

        //            tableRow.AddView(tituloTV);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < 4; i++)
        //        {                    
        //            for (int j = 0; j < 4; j++)
        //            {
        //                TextView tituloTV = new TextView(this.Activity);
        //                tituloTV.Id = 200 + i;
        //                tituloTV.TextSize = 30;
        //                tituloTV.Text = valores[i,j];

        //                tableRow.AddView(tituloTV);
        //            }                    
        //        }
        //    }
        //}
    }
}