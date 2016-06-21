using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SurveyMobile.Droid.Domain.Survey;
using SurveyMobile.Droid.UserInterfaceLayer.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace SurveyMobile.Droid.UserInterfaceLayer.Fragments
{
    public class OneChoiceQuestionFragment : Fragment
    {
        private int _page;
        private Questao _questao;

        public OneChoiceQuestionFragment() { }

        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            _page = Arguments.GetInt("page");
            var json = Arguments.GetSerializable("questao");
            _questao = JsonConvert.DeserializeObject<Questao>(json.ToString());
        }

        public override View OnCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle bundle)
        {
            View view = layoutInflater.Inflate(Resource.Layout.fragment_onechoice_questionario, viewGroup, false);
            TextView textView = view.FindViewById<TextView>(Resource.Id.title_text_view);
            RadioGroup radioGroup = view.FindViewById<RadioGroup>(Resource.Id.options_group);
            LinearLayout linearLayout = view.FindViewById<LinearLayout>(Resource.Id.options_layout);
            textView.Text = _questao.getTitulo();
            textView.Selected = true;
            int page = QuestionarioManager.getInstance().lastOptionSelected(_page);
            
            for (int i = 0; i < _questao.Respostas.Count; i++)
            {
                int id = i;
                QuestionarioWidgetGenerator.createRadioButton(radioGroup, page, id, _questao.Respostas[i].Descricao, page == id);
            }
            //int i = 0;
            //while (i < bundle.Size())
            //{
            //    string s = bundle.Get(i.ToString()).ToString();
            //    bool flag;
            //    if (page == i)
            //        flag = true;
            //    else
            //        flag = false;
            //}
            return view;
        }

        public static OneChoiceQuestionFragment newInstance(int i, Questao questao)
        {
            OneChoiceQuestionFragment fragment = new OneChoiceQuestionFragment();
            Intent intent = new Intent();
            intent.PutExtra("page", i);
            intent.PutExtra("questao", JsonConvert.SerializeObject(questao));
            fragment.Arguments = intent.Extras;
            
            return fragment;
        }
    }
}