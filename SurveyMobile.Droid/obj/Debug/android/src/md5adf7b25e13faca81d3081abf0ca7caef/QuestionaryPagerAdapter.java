package md5adf7b25e13faca81d3081abf0ca7caef;


public class QuestionaryPagerAdapter
	extends android.support.v4.app.FragmentPagerAdapter
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_getItem:(I)Landroid/support/v4/app/Fragment;:GetGetItem_IHandler\n" +
			"";
		mono.android.Runtime.register ("SurveyMobile.Droid.UserInterfaceLayer.Adapter.QuestionaryPagerAdapter, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", QuestionaryPagerAdapter.class, __md_methods);
	}


	public QuestionaryPagerAdapter (android.support.v4.app.FragmentManager p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == QuestionaryPagerAdapter.class)
			mono.android.TypeManager.Activate ("SurveyMobile.Droid.UserInterfaceLayer.Adapter.QuestionaryPagerAdapter, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Support.V4.App.FragmentManager, Xamarin.Android.Support.v4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public android.support.v4.app.Fragment getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native android.support.v4.app.Fragment n_getItem (int p0);

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
