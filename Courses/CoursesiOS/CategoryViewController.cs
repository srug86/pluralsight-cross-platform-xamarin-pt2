using CoursesLibrary;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesiOS
{
    [Register("CategoryViewController")]
    public class CategoryViewController : UITableViewController
    {
        private CourseCategoryManager _courseCategoryManager;

        public CategoryViewController()
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

            Title = "Categories";

            // Perform any additional setup after loading the view
            _courseCategoryManager = new CourseCategoryManager();
            var tableView = View as UITableView;
            tableView.Source = new CategoryViewSource(_courseCategoryManager);
        }
    }
}
