﻿
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

namespace FragmentSample {
	[Activity(Label = "DetailsActivity")]
	public class DetailsActivity : Activity {
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			var index = Intent.Extras.GetInt("current_play_id", 0);

			var details
		}
	}
}
