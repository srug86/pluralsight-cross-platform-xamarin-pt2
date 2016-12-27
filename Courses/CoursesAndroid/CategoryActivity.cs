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
using CoursesLibrary;

namespace CoursesAndroid
{
    public class CategoryActivity : ListActivity
    {
        private CourseCategoryManager _courseCategoryManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            _courseCategoryManager = new CourseCategoryManager();
            ListAdapter = new CourseCategoryManagerAdapter(
                this, Android.Resource.Layout.SimpleListItem1, _courseCategoryManager);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            _courseCategoryManager.MoveTo(position);
            var categoryTitle = _courseCategoryManager.Current.Title;

            var intent = new Intent(this, typeof(CourseActivity));
            intent.PutExtra(CourseActivity.DisplayCategoryTitleExtra, categoryTitle);
            
            StartActivity(intent);
        }
    }
}