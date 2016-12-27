using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CoursesLibrary;
using Android.Support.V4.App;

namespace CoursesAndroid
{
    class CoursePagerAdapter : FragmentStatePagerAdapter
    {
        private CourseManager _courseManager;

        public CoursePagerAdapter(FragmentManager fm, CourseManager courseManager)
            : base(fm)
        {
            _courseManager = courseManager;
        }

        public override int Count
        {
            get { return _courseManager.Length; }
        }

        public CourseManager CourseManager
        {
            set
            {
                _courseManager = value;
                NotifyDataSetChanged();
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            _courseManager.MoveTo(position);
            CourseFragment courseFragment = new CourseFragment();
            courseFragment.Course = _courseManager.Current;

            return courseFragment;
        }

        public override int GetItemPosition(Java.Lang.Object @object)
        {
            return PositionNone;
        }
    }
}