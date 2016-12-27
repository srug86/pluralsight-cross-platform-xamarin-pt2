using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using CoursesLibrary;

namespace CoursesiOS
{
    public partial class CourseViewController : UIViewController
    {
        public Course Course { get; set; }

        public int CoursePosition { get; set; }

        public CourseViewController()
            : base("CourseViewController", null)
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

            // Perform any additional setup after loading the view, typically from a nib.
            UpdateUI();
        }

        private void UpdateUI()
        {
            labelTitle.Text = Course.Title;
            textDescription.Text = Course.Description;
            imageCourse.Image = UIImage.FromBundle(Course.Image);
        }
    }
}

