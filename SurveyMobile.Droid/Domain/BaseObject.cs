using System;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace SurveyMobile.Droid.Domain
{
    public class BaseObject : Java.Lang.Object, ISerializable
    {
        public BaseObject()
        {
        }

        public BaseObject(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        [Export("readObject", Throws = new[]
            {
            typeof(Java.IO.IOException),
            typeof(Java.Lang.ClassNotFoundException)
            }
        )]
        private void ReadObjectDummy(Java.IO.ObjectInputStream source)
        {
        }

        [Export("writeObject", Throws = new[]
            {
            typeof(Java.IO.IOException),
            typeof(Java.Lang.ClassNotFoundException)
            }
        )]

        private void WriteObjectDummy(Java.IO.ObjectOutputStream destination)
        {
        }
    }
}