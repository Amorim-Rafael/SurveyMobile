using System;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Views;

namespace SurveyMobile.Droid.UserInterfaceLayer
{
    public class MenuPrincipalViewHolder : RecyclerView.ViewHolder
    {
        public TextView textView;

        public MenuPrincipalViewHolder(View v) : base(v)
        {
            textView = v.FindViewById<TextView>(Resource.Id.rowText);
        }
    }
}