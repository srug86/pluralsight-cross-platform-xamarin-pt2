using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using CoursesLibrary;

namespace CoursesiOS
{
    public partial class CourseViewController : UIViewController
    {
        private CourseManager _courseManager;

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
            buttonPrev.TouchUpInside += ButtonPrev_TouchUpInside;
            buttonNext.TouchUpInside += ButtonNext_TouchUpInside;

            _courseManager = new CourseManager();
            _courseManager.MoveFirst();
            UpdateUI();
        }

        private void ButtonPrev_TouchUpInside(object sender, EventArgs e)
        {
            _courseManager.MovePrev();
            UpdateUI();
        }

        private void ButtonNext_TouchUpInside(object sender, EventArgs e)
        {
            _courseManager.MoveNext();
            UpdateUI();
        }

        private void UpdateUI()
        {
            labelTitle.Text = _courseManager.Current.Title;
            textDescription.Text = _courseManager.Current.Description;
            imageCourse.Image = UIImage.FromBundle(_courseManager.Current.Image);
            buttonPrev.Enabled = _courseManager.CanMovePrev;
            buttonNext.Enabled = _courseManager.CanMoveNext;
        }
    }
}

