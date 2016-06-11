using Android.Gms.Maps;
using System;

namespace SurveyMobile.Droid
{
    public class OnMapReadyClass : Java.Lang.Object, IOnMapReadyCallback
    {
        public GoogleMap map { get; private set; }
        public event Action<GoogleMap> mapReadyAction;

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;

            if (mapReadyAction != null)
                mapReadyAction(map);
        }            
    }
}