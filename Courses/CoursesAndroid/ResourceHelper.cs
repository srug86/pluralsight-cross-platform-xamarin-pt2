using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Reflection;

namespace CoursesAndroid
{
    public static class ResourceHelper
    {
        private static Dictionary<string, int> _resourceDictionary = new Dictionary<string, int>(); // Cache of resources

        public static int TranslationDrawableWithReflection(string drawableName)
        {
            if (_resourceDictionary.ContainsKey(drawableName))
            {
                return _resourceDictionary[drawableName];
            }

            // Trick to get the Resource Identifier using reflection
            Type drawableType = typeof(Resource.Drawable);
            FieldInfo resourceFieldInfo = drawableType.GetField(drawableName);
            var resourceValue = (int)resourceFieldInfo.GetValue(null);
            _resourceDictionary.Add(drawableName, resourceValue);
            return resourceValue;
        }
    }
}