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
        private string _categoryTitle;

        public CoursePagerViewController(string categoryTitle)
        {
            _categoryTitle = categoryTitle;
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

            _courseManager = new CourseManager(_categoryTitle);
            _courseManager.MoveFirst();

            var dataSource = new CoursePagerViewControllerDataSource(_courseManager);
            _pageViewController.DataSource = dataSource;

            var firstCourseViewController = dataSource.GetFirstViewController();

            _pageViewController.SetViewControllers(
                new UIViewController[] { firstCourseViewController },
                UIPageViewControllerNavigationDirection.Forward, false, null);
        }
    }
}
