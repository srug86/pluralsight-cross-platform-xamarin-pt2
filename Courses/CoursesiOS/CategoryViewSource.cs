using CoursesLibrary;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesiOS
{
    public class CategoryViewSource : UITableViewSource
    {
        private const string CellId = "CategoryCell";

        private CourseCategoryManager _courseCategoryManager;

        public CategoryViewSource(CourseCategoryManager courseCategoryManager)
        {
            _courseCategoryManager = courseCategoryManager;
        }

        public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellId) ??
                new UITableViewCell(UITableViewCellStyle.Default, CellId);

            _courseCategoryManager.MoveTo(indexPath.Row);
            cell.TextLabel.Text = _courseCategoryManager.Current.Title;

            return cell;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return _courseCategoryManager.Length;
        }

        public override void RowSelected(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            _courseCategoryManager.MoveTo(indexPath.Row);
            var coursePagerViewController = new CoursePagerViewController(_courseCategoryManager.Current.Title);

            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
            appDelegate.RootNavigationController.PushViewController(coursePagerViewController, true);
        }
    }
}
