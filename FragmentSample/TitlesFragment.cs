
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FragmentSample {
	public class TitlesFragment : Android.App.ListFragment {
		private int _currentPlayId;

		private bool _isDualPane = false;



		public override void OnActivityCreated(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			var adapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemChecked, Shakespeare.Titles);
			ListAdapter = adapter;
			if (savedInstanceState != null) {
				_currentPlayId = savedInstanceState.GetInt("current_play_id", 0);
			}

			var detailsFrame = Activity.FindViewById<View>(Resource.Id.details);
			_isDualPane = detailsFrame != null && detailsFrame.Visibility == ViewStates.Visible;

			if (_isDualPane) {
				ListView.ChoiceMode = (int) ChoiceMode.Single;
				ShowDetails(_currentPlayId);
			}
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			return base.OnCreateView(inflater, container, savedInstanceState);
		}

		public override void OnListItemClick(ListView view1, View v, int position, long id) {
			ShowDetails(position);
		}

		private void ShowDetails(int playId) {
			//how can i reference something that is not declared yet?
			_currentPlayId = playId;
			if (_isDualPane) {
				ListView.SetItemChecked(playId, true);

				var details = FragmentManager.FindFragmentById(Resource.Id.details) as DetailsFragment;
				if (details == null || details.ShownPlayId != playId) {
					details = new DetailsFragment.NewInstance(playId);

					var ft = FragmentManager.BeginTransaction();
					ft.Replace(Resource.Id.details, details);
           			ft.SetTransition(FragmentTransaction.TransitFragmentFade);
           			ft.Commit();
				}
			} else {
		       // Otherwise we need to launch a new Activity to display
		       // the dialog fragment with selected text.
		       var intent = new Intent();
		       intent.SetClass(Activity, typeof (DetailsActivity));
		       intent.PutExtra("current_play_id", playId);
		       StartActivity(intent);
		   }
		}
	}
}
