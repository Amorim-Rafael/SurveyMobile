using System;
using Android.Views;
using Android.Widget;

namespace SurveyMobile.Droid.UserInterfaceLayer
{
    public class CustomViewHolder : Android.Support.V7.Widget.RecyclerView.ViewHolder
    {
        public TextView textView;
        public Type PageType;

        public CustomViewHolder(View view) : base(view)
        {
            textView = view.FindViewById<TextView>(Resource.Id.rowText);
        }
    }
}