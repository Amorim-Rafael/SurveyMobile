package md58d8804e8e3d5651321926e5d6b0c6678;


public class OnMapReadyClass
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.maps.OnMapReadyCallback
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onMapReady:(Lcom/google/android/gms/maps/GoogleMap;)V:GetOnMapReady_Lcom_google_android_gms_maps_GoogleMap_Handler:Android.Gms.Maps.IOnMapReadyCallbackInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"";
		mono.android.Runtime.register ("SurveyMobile.Droid.OnMapReadyClass, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OnMapReadyClass.class, __md_methods);
	}


	public OnMapReadyClass () throws java.lang.Throwable
	{
		super ();
		if (getClass () == OnMapReadyClass.class)
			mono.android.TypeManager.Activate ("SurveyMobile.Droid.OnMapReadyClass, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onMapReady (com.google.android.gms.maps.GoogleMap p0)
	{
		n_onMapReady (p0);
	}

	private native void n_onMapReady (com.google.android.gms.maps.GoogleMap p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
