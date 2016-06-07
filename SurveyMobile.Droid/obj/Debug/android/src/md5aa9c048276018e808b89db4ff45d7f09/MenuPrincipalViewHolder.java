package md5aa9c048276018e808b89db4ff45d7f09;


public class MenuPrincipalViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SurveyMobile.Droid.UserInterfaceLayer.MenuPrincipalViewHolder, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MenuPrincipalViewHolder.class, __md_methods);
	}


	public MenuPrincipalViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == MenuPrincipalViewHolder.class)
			mono.android.TypeManager.Activate ("SurveyMobile.Droid.UserInterfaceLayer.MenuPrincipalViewHolder, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
