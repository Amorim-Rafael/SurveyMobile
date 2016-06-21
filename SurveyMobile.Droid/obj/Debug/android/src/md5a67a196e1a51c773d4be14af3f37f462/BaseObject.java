package md5a67a196e1a51c773d4be14af3f37f462;


public class BaseObject
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.io.Serializable
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_ReadObjectDummy:(Ljava/io/ObjectInputStream;)V:__export__\n" +
			"n_WriteObjectDummy:(Ljava/io/ObjectOutputStream;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("SurveyMobile.Droid.Domain.BaseObject, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BaseObject.class, __md_methods);
	}


	public BaseObject () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BaseObject.class)
			mono.android.TypeManager.Activate ("SurveyMobile.Droid.Domain.BaseObject, SurveyMobile.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	private void readObject (java.io.ObjectInputStream p0) throws java.io.IOException, java.lang.ClassNotFoundException
	{
		n_ReadObjectDummy (p0);
	}

	private native void n_ReadObjectDummy (java.io.ObjectInputStream p0);


	private void writeObject (java.io.ObjectOutputStream p0) throws java.io.IOException, java.lang.ClassNotFoundException
	{
		n_WriteObjectDummy (p0);
	}

	private native void n_WriteObjectDummy (java.io.ObjectOutputStream p0);

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
