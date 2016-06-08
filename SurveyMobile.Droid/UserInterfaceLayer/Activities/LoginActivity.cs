using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Text;
using Android.Widget;
using Newtonsoft.Json;
using SurveyMobile.Droid.Domain;
using SurveyMobile.PCL.BusinessLayer.Model;
using SurveyMobile.PCL.ServiceAccessLayer;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(Theme = "@style/DataInfoTheme", Label = " Login")]
    public class LoginActivity : AppCompatActivity
    {

        private TokenModel _tokenModel;
        private EditText _emailEditText;
        private EditText _passwordEditText;
        private TextView _signTextView;
        private TextView _configurationTextView;
        private ProgressDialog _progressDialog;
        ServiceWrapper serviceWrapper = new ServiceWrapper();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_login);

            _emailEditText = FindViewById<EditText>(Resource.Id.usuario);
            _emailEditText.InputType = InputTypes.TextVariationEmailAddress;

            _passwordEditText = FindViewById<EditText>(Resource.Id.senha);
            _passwordEditText.InputType = InputTypes.TextVariationPassword | InputTypes.ClassText;

            _signTextView = FindViewById<TextView>(Resource.Id.entrar);
            _configurationTextView = FindViewById<TextView>(Resource.Id.configuracao);

            _signTextView.Click += (sender, e) =>
            {
                _tokenModel = Logar();

                StartActivity(typeof(MenuPrincipalActivity));
            };
        }

        #region Logar
        public TokenModel Logar()
        {
            ServiceWrapper serviceWrapper = new ServiceWrapper();
            UserLoginModel loginModel = new UserLoginModel(_emailEditText.Text, _passwordEditText.Text);

            _progressDialog = ProgressDialog.Show(this, "Autenticando...", "Checando informações...", true);
                        
            new Thread(new ThreadStart(delegate
            {
                //LOAD METHOD TO GET ACCOUNT INFO
                RunOnUiThread(() => _progressDialog.Show());

                _tokenModel = serviceWrapper.GetAuthorizationToken(loginModel);
                AutenticationOk(_emailEditText.Text, _tokenModel.access_token);

                //HIDE PROGRESS DIALOG
                RunOnUiThread(() => _progressDialog.Hide());
            })).Start();

            return _tokenModel;
        }
        #endregion

        #region AutenticationOk
        private void AutenticationOk(string email, string token)
        {
            UpdateCredentialsInCache(email, token);
            UpdatePesquisasInCache();
            Finish();
        }

        private void UpdateCredentialsInCache(string email, string token)
        {
            AppPreferences ap = new AppPreferences(this);
            ap.PutString("email", email);
            ap.PutString("token", token);
            ap.Commit();

            GlobalParams.getInstance().setEmail(email);
            GlobalParams.getInstance().setToken(token);
        }

        private void UpdatePesquisasInCache()
        {
            List<Pesquisa> listaPesquisa = serviceWrapper.DespesasPorPesquisa();

            //ADD LISTA DE PESQUISA EM CACHE
            AppPreferences ap = new AppPreferences(this);
            ap.PutListStringSet("listaPesquisa", listaPesquisa);
            ap.Commit();
            //var lst = ap.GetString("listaPesquisa", "");
            //var lsts = JsonConvert.DeserializeObject<List<Pesquisa>>(lst);

            GlobalParams.getInstance().setListaPesquisas(listaPesquisa);
        }
        #endregion
    }
}

