﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesLibrary
{
    public class CourseManager
    {
        private const String DefaultCategory = "Android";

        private readonly Course[] _courses;
        private readonly int _lastIndex;
        private int _currentIndex = 0;

        public CourseManager()
            : this(DefaultCategory) { }

        public CourseManager(string categoryTitle)
        {
            switch (categoryTitle)
            {
                case "Android":
                    _courses = InitCoursesAndroid();
                    break;
                case "iOS":
                    _courses = InitCoursesIOS();
                    break;
                case "Windows Phone":
                    _courses = InitCoursesWindowsPhone();
                    break;
            }

            if (_courses != null)
            {
                _lastIndex = _courses.Length - 1;
            }
        }

        public int Length
        {
            get { return _courses.Length; }
        }

        public Course Current
        {
            get { return _courses[_currentIndex]; }
        }

        public int CurrentPosition
        {
            get { return _currentIndex; }
        }

        public bool CanMovePrev
        {
            get { return _currentIndex > 0; }
        }

        public bool CanMoveNext
        {
            get { return _currentIndex < _lastIndex; }
        }

        public void MoveFirst()
        {
            _currentIndex = 0;
        }

        public void MovePrev()
        {
            if (CanMovePrev)
            {
                --_currentIndex;
            }
        }

        public void MoveNext()
        {
            if (CanMoveNext)
            {
                ++_currentIndex;
            }
        }

        public void MoveTo(int position)
        {
            if (position >= 0 && position <= _lastIndex)
            {
                _currentIndex = position;
            }
            else
            {
                throw new IndexOutOfRangeException(
                    String.Format("{0} is an invalid position. Must be between 0 and {1}", position, _lastIndex));
            }
        }

        private Course[] InitCoursesAndroid()
        {
            var initCourses = new Course[] {
                new Course()
                { 
                    Title = "Android for .NET Developers",
                    Description = "Provides an overview of the tools used in the Android " + 
                    "development process including the newly released Android Studio.",
                    Image = "ps_top_card_01"
                },

                new Course()
                { 
                    Title = "Android Dreams, Widgets, Notifications",
                    Description = "Provide users with a rich and interactive experience " +
                    "without ever requiring them to open your app.",
                    Image = "ps_top_card_02"
                },
                new Course()
                { 
                    Title = "Android Photo/Video Programming",
                    Description = "Learn how to capitalize on the Android camera " + 
                    "within your apps to capture still photos and video.",
                    Image = "ps_top_card_03"
                },
                new Course()
                { 
                    Title = "Android Location-Based Apps",
                    Description = "Cover the wide range of Android location capabilities " +
                    "including determining user location, power management, and " + 
                    "translating location data to human-readable addresses.",
                    Image = "ps_top_card_04"
                }

            };

            return initCourses;
        }

        private Course[] InitCoursesIOS()
        {
            var initCourses = new Course[] {
                new Course()
                { 
                    Title = "iOS 7 Fundementals",
                    Description = "This course is intended to get you up to speed  " + 
                    "on the basic skills you need to become a successful iOS developer.",
                    Image = "ps_top_card_01"
                },

                new Course()
                { 
                    Title = "Beginning iOS 7 Development",
                    Description = "In this course, you'll learn the basics of " +
                    "how to create iOS applications using Objective-C.",
                    Image = "ps_top_card_02"
                },
                new Course()
                { 
                    Title = "Introduction to XCode",
                    Description = "This course provides the foundational skills " + 
                    "you need to use Xcode effectively.",
                    Image = "ps_top_card_03"
                },
                new Course()
                { 
                    Title = "iOS Graphics and Animation",
                    Description = "Learn how to work with graphics and animation " +
                    "on iOS devices.",
                    Image = "ps_top_card_04"
                }

            };

            return initCourses;
        }

        private Course[] InitCoursesWindowsPhone()
        {
            var initCourses = new Course[] {
                new Course()
                { 
                    Title = "Windows Phone 7 Basics",
                    Description = "The course introduces you to the basics of the " + 
                    "Windows Phone 7 platform using Visual Studio 2010 and Blend.",
                    Image = "ps_top_card_01"
                },

                new Course()
                { 
                    Title = "Beyond the Basics in Windows Phone 8",
                    Description = "This course will walk you through four new features " +
                    "included in the Windows Phone 8 SDK including: Speech, In-App Purchasing, " +
                    "Wallet transactions and the new Map control.",
                    Image = "ps_top_card_02"
                },
                new Course()
                { 
                    Title = "Introduction to Windows Phone 8",
                    Description = "Learn how to build apps that run on Windows Phone.",
                    Image = "ps_top_card_03"
                },
                new Course()
                { 
                    Title = "Building Windows Phone Apps that Stand Out",
                    Description = "Learn to use some of the best features of the Windows Phone " +
                    "platform to make your next app get noticed.",
                    Image = "ps_top_card_04"
                }

            };

            return initCourses;
        }
    }
}
