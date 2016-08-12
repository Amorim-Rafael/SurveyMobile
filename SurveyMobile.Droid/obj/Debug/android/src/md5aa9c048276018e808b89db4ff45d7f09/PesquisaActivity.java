package md5aa9c048276018e808b89db4ff45d7f09;


public class PesquisaActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("SurveyMobile.Droid.UserInterfaceLayer.PesquisaActivity, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PesquisaActivity.class, __md_methods);
	}


	public PesquisaActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PesquisaActivity.class)
			mono.android.TypeManager.Activate ("SurveyMobile.Droid.UserInterfaceLayer.PesquisaActivity, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
