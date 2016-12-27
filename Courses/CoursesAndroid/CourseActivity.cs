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
using Android.Support.V4.Widget;

namespace CoursesAndroid
{
    [Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]
    public class CourseActivity : FragmentActivity
    {
        public const string DisplayCategoryTitleExtra = "DisplayCategoryTitleExtra";

        private const string DefaultCategoryTitle = "Android";

        private CourseCategoryManager _courseCategoryManager;
        private CourseManager _courseManager;
        private CoursePagerAdapter _coursePagerAdapter;
        private ViewPager _viewPager;
        private DrawerLayout _drawerLayout;
        private ListView _categoryDrawerListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CourseActivity);

            _courseCategoryManager = new CourseCategoryManager();
            _courseCategoryManager.MoveFirst();

            var displayCategoryTitle = _courseCategoryManager.Current.Title;

            _courseManager = new CourseManager(displayCategoryTitle);
            _courseManager.MoveFirst();

            _coursePagerAdapter = new CoursePagerAdapter(SupportFragmentManager, _courseManager);

            _viewPager = FindViewById<ViewPager>(Resource.Id.coursePager);
            _viewPager.Adapter = _coursePagerAdapter;

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            _categoryDrawerListView = FindViewById<ListView>(Resource.Id.categoryDrawerListView);

            _categoryDrawerListView.Adapter = new CourseCategoryManagerAdapter(
                this, Resource.Layout.CourseCategoryItem, _courseCategoryManager);

            _categoryDrawerListView.SetItemChecked(0, true);
            _categoryDrawerListView.ItemClick += CategoryDrawerListView_ItemClick;
        }

        private void CategoryDrawerListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            _drawerLayout.CloseDrawer(_categoryDrawerListView);

            _courseCategoryManager.MoveTo(e.Position);
            _courseManager = new CourseManager(_courseCategoryManager.Current.Title);
            _coursePagerAdapter.CourseManager = _courseManager;

            _viewPager.CurrentItem = 0;
        }
    }
}