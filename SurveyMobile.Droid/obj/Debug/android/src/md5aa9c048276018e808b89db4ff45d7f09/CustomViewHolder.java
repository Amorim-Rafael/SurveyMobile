package md5aa9c048276018e808b89db4ff45d7f09;


public class CustomViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SurveyMobile.Droid.UserInterfaceLayer.CustomViewHolder, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CustomViewHolder.class, __md_methods);
	}


	public CustomViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CustomViewHolder.class)
			mono.android.TypeManager.Activate ("SurveyMobile.Droid.UserInterfaceLayer.CustomViewHolder, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
