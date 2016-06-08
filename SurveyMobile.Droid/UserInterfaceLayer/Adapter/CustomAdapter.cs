using Android.Content.Res;
using Android.Support.V7.Widget;
using Android.Views;
using SurveyMobile.PCL.BusinessLayer.Model;
using System;
using System.Collections.Generic;

namespace SurveyMobile.Droid.UserInterfaceLayer.Adapter
{
    public class CustomAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        private List<ListItem> _listItems;
        private CustomViewHolder _vh;

        public CustomAdapter(List<ListItem> listItem, Resources resources)
        {
            _listItems = listItem;
        }

        public override int ItemCount
        {
            get { return _listItems.ToArray().Length; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            _vh.textView.Text = _listItems[position].Title;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.activity_list_row, parent, false);
            _vh = new CustomViewHolder(v, OnClick);

            return _vh;
        }

        private void OnClick(int position)
        {
            if (ItemClick != null)
            {
                ItemClick(this, position);
            }
        }
    }
}