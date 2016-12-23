using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CoursesiOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        private UIWindow _window;
		private CoursePagerViewController _pagerViewController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

			_pagerViewController = new CoursePagerViewController();
            _window.RootViewController = _pagerViewController;

            _window.MakeKeyAndVisible();

            return true;
        }
    }
}

