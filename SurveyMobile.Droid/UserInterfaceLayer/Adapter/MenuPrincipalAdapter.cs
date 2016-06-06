using System;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using SurveyMobile.PCL.BusinessLayer.Model;

namespace SurveyMobile.Droid.UserInterfaceLayer.Adapter
{
    public class MenuPrincipalAdapter : RecyclerView.Adapter
    {
        private string[] _itens;
        private List<ListItem> _listItems;
        MenuPrincipalViewHolder vh;

        //public MenuPrincipalAdapter(string[] itens)
        //{
        //    _itens = itens;
        //}

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
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.activity_list_row, parent, false);
            //v.SetOnClickListener(OnClickListener());
            vh = new MenuPrincipalViewHolder(v);

            return vh;
        }

        //private View.IOnClickListener OnClickListener()
        //{
        //    throw new NotImplementedException();
        //}
    }
}