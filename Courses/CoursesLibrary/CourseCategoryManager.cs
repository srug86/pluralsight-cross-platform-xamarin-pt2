using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesLibrary
{
    public class CourseCategoryManager
    {
        private readonly CourseCategory[] _categories;
        private int _currentIndex = 0;
        private readonly int _lastIndex;

        public CourseCategoryManager()
        {
            _categories = InitCategories();
            _lastIndex = _categories.Length - 1;
        }

        public CourseCategory Current
        {
            get { return _categories[_currentIndex]; }
        }

        public Boolean CanMoveNext
        {
            get { return _currentIndex < _lastIndex; }
        }

        public int Length
        {
            get { return _categories.Length; }
        }

        private CourseCategory[] InitCategories()
        {
            var initCategories = new CourseCategory[] {
                new CourseCategory()
                {
                    Title = "Android",
                    Description = "Android programming courses"
                },
                new CourseCategory()
                {
                    Title = "iOS",
                    Description = "iOS programming courses"
                },
                new CourseCategory()
                {
                    Title = "Windows Phone",
                    Description = "Windows Phone programming courses"
                }
            };

            return initCategories;
        }

        public void MoveFirst()
        {
            _currentIndex = 0;
        }

        public void MoveNext()
        {
            if (_currentIndex < _lastIndex)
                ++_currentIndex;
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
                    string.Format("{0} is an invalid position. Position must be between 0 and {1}",
                    position, _lastIndex));
            }
        }
    }
}
