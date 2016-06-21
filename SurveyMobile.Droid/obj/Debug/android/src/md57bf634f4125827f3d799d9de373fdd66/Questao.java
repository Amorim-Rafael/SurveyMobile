package md57bf634f4125827f3d799d9de373fdd66;


public class Questao
	extends md5a67a196e1a51c773d4be14af3f37f462.BaseObject
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SurveyMobile.Droid.Domain.Survey.Questao, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Questao.class, __md_methods);
	}


	public Questao () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Questao.class)
			mono.android.TypeManager.Activate ("SurveyMobile.Droid.Domain.Survey.Questao, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
