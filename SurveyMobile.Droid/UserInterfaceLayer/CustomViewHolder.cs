using System;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace SurveyMobile.Droid.UserInterfaceLayer
{
    public class CustomViewHolder : RecyclerView.ViewHolder
    {
        public TextView textView;

        public CustomViewHolder(View v, Action<int> listener) : base(v)
        {
            textView = v.FindViewById<TextView>(Resource.Id.rowText);

            v.Click += (sender, e) => listener(Position);
        }
    }
}