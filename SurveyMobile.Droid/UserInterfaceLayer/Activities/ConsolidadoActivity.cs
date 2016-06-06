using Android.App;
using Android.OS;
using SurveyMobile.Droid.UserInterfaceLayer.Fragments;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Label = " Consolidado", Icon = "@drawable/icon")]
    public class ConsolidadoActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Consolidado);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            var tab = ActionBar.NewTab();
            tab.SetText("RESUMO");
            var tabMapa = new ResumoFragment();
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, tabMapa);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(tabMapa);
            };

            ActionBar.AddTab(tab);

            var tab2 = ActionBar.NewTab();
            tab2 = ActionBar.NewTab();
            tab2.SetText("DETALHE");
            var tabLista = new DetalheFragment();
            tab2.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, tabLista);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(tabLista);
            };

            ActionBar.AddTab(tab2);
        }
    }
}