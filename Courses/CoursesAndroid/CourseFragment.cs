using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CoursesLibrary;
using Android.Support.V4.App;

namespace CoursesAndroid
{
    public class CourseFragment : Fragment
    {
        private ImageView _imageCourse;
        private TextView _textTitle;
        private TextView _textDescription;

        public Course Course { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.CourseFragment, container, false);

            _imageCourse = rootView.FindViewById<ImageView>(Resource.Id.imageCourse);
            _textTitle = rootView.FindViewById<TextView>(Resource.Id.textTitle);
            _textDescription = rootView.FindViewById<TextView>(Resource.Id.textDescription);

            _textTitle.Text = Course.Title;
            _textDescription.Text = Course.Description;
            _imageCourse.SetImageResource(ResourceHelper.TranslationDrawableWithReflection(Course.Image));

            return rootView;
        }
    }
}