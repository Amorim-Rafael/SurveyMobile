using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using SurveyMobile.PCL.BusinessLayer.Model;
using System.Collections.Generic;

namespace SurveyMobile.Droid.UserInterfaceLayer.Adapter
{
    public class RecycleViewAdapter : RecyclerView.Adapter
    {
        private List<ListItem> _items;
        private Activity _context;
        CustomViewHolder viewHolder;

        //public RecycleViewAdapter(Activity context, List<ListItem> items) : base()
        //{
        //    _context = context;
        //    _items = items;
        //}
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            viewHolder.textView.Text = _items[position].Title;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.FromContext(_context).Inflate(Resource.Layout.activity_list, parent, false);
            viewHolder = new CustomViewHolder(view);

            return viewHolder;
        }

        public override int ItemCount
        {
            get { return _items.Count; }
        }
    }
}