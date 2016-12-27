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

        public UINavigationController RootNavigationController { get; private set; }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            RootNavigationController = new UINavigationController();

			var categoryViewController = new CoursePagerViewController();
            RootNavigationController.PushViewController(categoryViewController, false);

            _window.RootViewController = RootNavigationController;

            _window.MakeKeyAndVisible();

            return true;
        }
    }
}

