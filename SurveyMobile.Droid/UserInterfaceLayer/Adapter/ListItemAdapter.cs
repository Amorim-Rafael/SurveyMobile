using Android.App;
using Android.Widget;
using SurveyMobile.PCL.BusinessLayer.Model;
using System;
using System.Collections.Generic;
using Android.Views;
using Android.Support.V7.Widget;
using static Android.Support.V7.Widget.RecyclerView;

namespace SurveyMobile.Droid.UserInterfaceLayer.Adapter
{
    public class ListItemAdapter : BaseAdapter
    {
        private List<ListItem> _itemList;
        private Activity _context;

        public ListItemAdapter(Activity context, List<ListItem> items) : base()
        {
            this._context = context;
            this._itemList = items;
        }

        public override int Count
        {
            get { return _itemList.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (_context != null)
            {
                if (view == null)
                    view = _context.LayoutInflater.Inflate(Resource.Layout.ListItemMenu, null);
                view.FindViewById<TextView>(Resource.Id.Text1).Text = _itemList[position].Title;
            }


            return view;
        }
    }
}