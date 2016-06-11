using Android.Support.V4.App;
using Java.Lang;

namespace SurveyMobile.Droid.UserInterfaceLayer.Adapter
{
    public class TabsFragmentPagerAdapter : FragmentPagerAdapter
    {
        private readonly Fragment[] _fragments;
        private readonly ICharSequence[] _titles;

        public TabsFragmentPagerAdapter(FragmentManager fm, Fragment[] fragments, ICharSequence[] titles) : base(fm)
        {
            _fragments = fragments;
            _titles = titles;
        }
        public override int Count
        {
            get
            {
                return _fragments.Length;
            }
        }

        public override Fragment GetItem(int position)
        {
            return _fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return _titles[position];
        }
    }
}