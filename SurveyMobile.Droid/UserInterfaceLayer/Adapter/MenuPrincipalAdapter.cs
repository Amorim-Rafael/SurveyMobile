using System;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using SurveyMobile.PCL.BusinessLayer.Model;

namespace SurveyMobile.Droid.UserInterfaceLayer.Adapter
{
    public class MenuPrincipalAdapter : RecyclerView.Adapter
    {
        private List<ListItem> _listItems;
        private MenuPrincipalViewHolder vh;
        public Type pageType;

        public MenuPrincipalAdapter(List<ListItem> listItem)
        {
            _listItems = listItem;
        }

        public override int ItemCount
        {
            get { return _listItems.ToArray().Length; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            vh.textView.Text = _listItems[position].Title;
            vh.textView.Click += textView_Click;
        }
                
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.activity_list_row, parent, false);
            vh = new MenuPrincipalViewHolder(v);

            return vh;
        }

        private void textView_Click(object sender, EventArgs e)
        {
            var textView = (Android.Widget.TextView)sender;
            pageType = _listItems.Find(t => t.Title == textView.Text).PageType;
        }
    }
}