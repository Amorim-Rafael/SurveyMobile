using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using System.Threading.Tasks;

namespace SurveyMobile.Droid.UserInterfaceLayer.Activities
{
    [Activity(MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_splash);
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() => {
                Task.Delay(5000);  // Simulate a bit of startup work.
            });

            startupWork.ContinueWith(t => {
                StartActivity(new Intent(Application.Context, typeof(LoginActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}