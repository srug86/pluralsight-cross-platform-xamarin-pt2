using CoursesLibrary;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesiOS
{
    [Register("CoursePageViewController")]
    public class CoursePagerViewController : UIViewController
    {
        private UIPageViewController _pageViewController;
        private CourseManager _courseManager;

        public CoursePagerViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            // * Scroll mode (similar to Android behavior)
            //_pageViewController = new UIPageViewController(
            //    UIPageViewControllerTransitionStyle.Scroll,
            //    UIPageViewControllerNavigationOrientation.Horizontal);

            // * PageCurl mode (looks like user is reading a book)
            _pageViewController = new UIPageViewController(
                UIPageViewControllerTransitionStyle.PageCurl,
                UIPageViewControllerNavigationOrientation.Horizontal,
                UIPageViewControllerSpineLocation.Min);
            _pageViewController.View.Frame = View.Bounds;
            View.AddSubview(_pageViewController.View);

            _courseManager = new CourseManager();
            _courseManager.MoveFirst();

            var firstCourseViewController = CreateCoursesViewController();

            _pageViewController.SetViewControllers(
                new UIViewController[] { firstCourseViewController },
                UIPageViewControllerNavigationDirection.Forward, false, null);

            _pageViewController.GetNextViewController = GetNextViewController;
            _pageViewController.GetPreviousViewController = GetPreviousViewController;
        }

        private CourseViewController CreateCoursesViewController()
        {
            var coursesViewController = new CourseViewController();
            coursesViewController.Course = _courseManager.Current;
            coursesViewController.CoursePosition = _courseManager.CurrentPosition;

            return coursesViewController;
        }

        public UIViewController GetNextViewController(
            UIPageViewController pageViewController,
            UIViewController referenceViewController)
        {
            CourseViewController referenceCourseViewController =
                referenceViewController as CourseViewController;
            if (referenceCourseViewController == null) { return null; }

            _courseManager.MoveTo(referenceCourseViewController.CoursePosition);
            if (!_courseManager.CanMoveNext) { return null; }

            _courseManager.MoveNext();
            return CreateCoursesViewController();
        }

        public UIViewController GetPreviousViewController(
            UIPageViewController pageViewController,
            UIViewController referenceViewController)
        {
            CourseViewController referenceCourseViewController =
                referenceViewController as CourseViewController;
            if (referenceCourseViewController == null) { return null; }

            _courseManager.MoveTo(referenceCourseViewController.CoursePosition);
            if (!_courseManager.CanMovePrev) { return null; }

            _courseManager.MovePrev();
            return CreateCoursesViewController();
        }
    }
}
