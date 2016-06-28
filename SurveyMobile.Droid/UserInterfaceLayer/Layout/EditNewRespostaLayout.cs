using Android.Content;
using Android.Views;
using Android.Widget;
using static Android.Widget.TextView;
using Android.Views.InputMethods;

namespace SurveyMobile.Droid.UserInterfaceLayer.Layout
{
    public class EditNewRespostaLayout : RelativeLayout
    {
        private LayoutInflater _inflater;

        public EditNewRespostaLayout(Context context) : base(context)
        {
            _inflater = LayoutInflater.From(context);
            Init();
        }

        private void Init()
        {
            _inflater.Inflate(Resource.Layout.layout_edit_new_resposta, this, true);
            EditText editText = FindViewById<EditText>(Resource.Id.new_resposta_label);
            editText.EditorAction += EditText_EditorAction;
        }

        private void EditText_EditorAction(object sender, EditorActionEventArgs e)
        {
            e.Handled = false;
            if (e.ActionId == ImeAction.Send)
                //SendMessage();
                e.Handled = true;
        }
    }
}