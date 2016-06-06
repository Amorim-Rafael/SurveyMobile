using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using SurveyMobile.Droid.UserInterfaceLayer.Adapter;
using SurveyMobile.Droid.UserInterfaceLayer.Fragments;
using Fragment = Android.Support.V4.App.Fragment;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{

    [Activity(Label = " Mapa", Icon = "@drawable/ic_short_logo")]
    public class MapaActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_mapa);

            var fragments = new Fragment[]
            {
                new MapaFragment(),
                new ListaFragment()                
            };

            var titles = CharSequence.ArrayFromStringArray(new[]
                {
                    "Mapa",
                    "Lista"
                });

            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            viewPager.Adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, fragments, titles);

            // Give the TabLayout the ViewPager
            var tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            tabLayout.SetupWithViewPager(viewPager);
        }        
    }
}