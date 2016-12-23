using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using CoursesLibrary;
using Android.Support.V4.View;

namespace CoursesAndroid
{
    [Activity(Label = "Course Activity")]
    public class CourseActivity : FragmentActivity
    {
        public const string DisplayCategoryTitleExtra = "DisplayCategoryTitleExtra";

        private const string DefaultCategoryTitle = "Android";

        private CourseManager _courseManager;
        private CoursePagerAdapter _coursePagerAdapter;
        private ViewPager _viewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CourseActivity);

            var displayCategoryTitle = DefaultCategoryTitle;

            var startupIntent = this.Intent;
            if (startupIntent != null)
            {
                var displayCategoryTitleExtra =
                    startupIntent.GetStringExtra(DisplayCategoryTitleExtra);
                if (displayCategoryTitle != null)
                {
                    displayCategoryTitle = displayCategoryTitleExtra;
                }
            }

            _courseManager = new CourseManager(displayCategoryTitle);
            _courseManager.MoveFirst();

            _coursePagerAdapter = new CoursePagerAdapter(SupportFragmentManager, _courseManager);

            _viewPager = FindViewById<ViewPager>(Resource.Id.coursePager);
            _viewPager.Adapter = _coursePagerAdapter;
        }
    }
}