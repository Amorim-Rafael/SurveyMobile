using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace SurveyMobile.Droid.UserInterfaceLayer.Fragments
{
    public class MapaFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_mapa, container, false);
        }
    }
}