using Android.App;
using Android.Widget;
using Android.OS;

namespace FragmentSample {
	[Activity(Label = "Fragment Walkthrough", MainLauncher = true, Icon = "@drawable/launcher")]
	public class MainActivity : Activity {
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);
		}
	}
}

