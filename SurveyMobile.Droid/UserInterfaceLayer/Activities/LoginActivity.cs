using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;
using SurveyMobile.Droid.Domain;
using SurveyMobile.PCL.BusinessLayer.Model;
using SurveyMobile.PCL.ServiceAccessLayer;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Theme = "@style/DataInfoTheme", Label = " Login")]
    public class LoginActivity : AppCompatActivity
    {

        TokenModel tokenModel;
        private EditText emailEditText;
        private EditText passwordEditText;
        private TextView signTextView;
        private TextView configurationTextView;
        private ProgressDialog progressDialog;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_login);

            emailEditText = FindViewById<EditText>(Resource.Id.usuario);
            emailEditText.InputType = InputTypes.TextVariationEmailAddress;

            passwordEditText = FindViewById<EditText>(Resource.Id.senha);
            passwordEditText.InputType = InputTypes.TextVariationPassword | InputTypes.ClassText;

            signTextView = FindViewById<TextView>(Resource.Id.entrar);
            configurationTextView = FindViewById<TextView>(Resource.Id.configuracao);

            signTextView.Click += (sender, e) =>
            {
                tokenModel = Logar();

                StartActivity(typeof(MenuPrincipalActivity));
            };
        }

        #region Logar
        public TokenModel Logar()
        {
            ServiceWrapper serviceWrapper = new ServiceWrapper();
            UserLoginModel loginModel = new UserLoginModel(emailEditText.Text, passwordEditText.Text);

            progressDialog = ProgressDialog.Show(this, "Autenticando...", "Checando informações...", true);
            new Thread(new ThreadStart(async delegate
            {
                //LOAD METHOD TO GET ACCOUNT INFO
                RunOnUiThread(() => progressDialog.Show());

                tokenModel = await Task.Run(() => serviceWrapper.GetAuthorizationTokenData(loginModel));

                //HIDE PROGRESS DIALOG
                RunOnUiThread(() => progressDialog.Hide());
            })).Start();

            return tokenModel;
        }
        #endregion

        #region AutenticationOk
        private void AutenticationOk(string email, string token)
        {
            UpdateCredentialsInCache(email, token);
            Finish();
        }
        #endregion

        #region AutenticationOk
        private void UpdateCredentialsInCache(string email, string token)
        {
            AppPreferences ap = new AppPreferences(this);
            ap.PutString("email", email);
            ap.PutString("token", token);
            ap.Commit();

            GlobalParams.getInstance().setEmail(email);
            GlobalParams.getInstance().setToken(token);
        }
        #endregion
    }
}

