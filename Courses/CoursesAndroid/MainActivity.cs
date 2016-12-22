using Android.App;
using Android.Widget;
using Android.OS;
using CoursesLibrary;

namespace CoursesAndroid
{
    [Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button _buttonPrev;
        private Button _buttonNext;
        private ImageView _imageCourse;
        private TextView _textTitle;
        private TextView _textDescription;
        private CourseManager _courseManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
            _buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
            _imageCourse = FindViewById<ImageView>(Resource.Id.imageCourse);
            _textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            _textDescription = FindViewById<TextView>(Resource.Id.textDescription);

            _buttonPrev.Click += ButtonPrev_Click;
            _buttonNext.Click += ButtonNext_Click;
            _courseManager = new CourseManager();
            _courseManager.MoveFirst();
            UpdateUI();
        }

        private void ButtonPrev_Click(object sender, System.EventArgs e)
        {
            _courseManager.MovePrev();
            UpdateUI();
        }

        private void ButtonNext_Click(object sender, System.EventArgs e)
        {
            _courseManager.MoveNext();
            UpdateUI();
        }

        private void UpdateUI()
        {
            _textTitle.Text = _courseManager.Current.Title;
            _textDescription.Text = _courseManager.Current.Description;
            _imageCourse.SetImageResource(
                ResourceHelper.TranslationDrawableWithReflection(_courseManager.Current.Image));
            _buttonPrev.Enabled = _courseManager.CanMovePrev;
            _buttonNext.Enabled = _courseManager.CanMoveNext;
        }
    }
}

