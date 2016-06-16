using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using SurveyMobile.Droid.Domain.Survey;
using FragmentActivity = Android.Support.V4.App.FragmentActivity;

namespace SurveyMobile.Droid.UserInterfaceLayer.Fragments
{
    public class OneChoiceQuestionFragment : Fragment
    {        
        private int _page;
        private Questao _questao;

        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater layoutinflater, ViewGroup viewGroup, Bundle bundle)
        {
            View view = layoutinflater.Inflate(Resource.Layout.fragment_linear_questionario, viewGroup, false);
            TextView textView = view.FindViewById<TextView>(Resource.Id.title_text_view);
            //textView.Text = 
            LinearLayout linearLayout = view.FindViewById<LinearLayout>(Resource.Id.options_layout);
            

            return view;
            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}