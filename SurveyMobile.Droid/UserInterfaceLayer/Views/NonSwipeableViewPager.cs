using Android.Content;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;

namespace SurveyMobile.Droid.UserInterfaceLayer.Views
{
    public class NonSwipeableViewPager: ViewPager
    {
        //private Context _context;

        public NonSwipeableViewPager(Context context) : base(context)
        {
            //_context = context;
        }

        public NonSwipeableViewPager(Context context, IAttributeSet attrs):base(context, attrs)
        {
        }

        public override bool OnInterceptTouchEvent(MotionEvent ev)
        {
            return false; //base.OnInterceptTouchEvent(ev); 
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return false; //base.OnTouchEvent(e);    
        }

        //public NonSwipeableViewPager(Context context, AttributeSet attrs);
        //{

        //}
    }
}