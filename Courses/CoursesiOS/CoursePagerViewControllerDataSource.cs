using CoursesLibrary;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesiOS
{
    public class CoursePagerViewControllerDataSource : UIPageViewControllerDataSource
    {
        private CourseManager _courseManager;

        public CoursePagerViewControllerDataSource(CourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        public CourseViewController GetFirstViewController()
        {
            _courseManager.MoveFirst();

            return CreateCoursesViewController();
        }

        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            CourseViewController referenceCourseViewController =
                referenceViewController as CourseViewController;
            if (referenceCourseViewController == null) { return null; }

            _courseManager.MoveTo(referenceCourseViewController.CoursePosition);
            if (!_courseManager.CanMoveNext) { return null; }

            _courseManager.MoveNext();
            return CreateCoursesViewController();
        }

        public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            CourseViewController referenceCourseViewController =
                referenceViewController as CourseViewController;
            if (referenceCourseViewController == null) { return null; }

            _courseManager.MoveTo(referenceCourseViewController.CoursePosition);
            if (!_courseManager.CanMovePrev) { return null; }

            _courseManager.MovePrev();
            return CreateCoursesViewController();
        }

        private CourseViewController CreateCoursesViewController()
        {
            var coursesViewController = new CourseViewController();
            coursesViewController.Course = _courseManager.Current;
            coursesViewController.CoursePosition = _courseManager.CurrentPosition;

            return coursesViewController;
        }
    }
}
