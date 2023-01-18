using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class WaypointsPage : ContentPage
{
	public WaypointsPage()
	{
		InitializeComponent();
		Utils.GpxLoaded += HandleGpxLoaded;
		WaypointsListView.ItemSelected += WaypointsListView_ItemSelected;
		HandleGpxLoaded(null, EventArgs.Empty);
	}

	private void HandleGpxLoaded(object sender, EventArgs e)
	{
		if (Utils.gpx != null)
		{
			WaypointsListView.ItemsSource = Utils.gpx.Waypoints;
			if (Utils.gpx.Waypoints.Count > 0)
			{
				WaypointsListView.SelectedItem = Utils.gpx.Waypoints[0];
			}
		}
	}

	private void WaypointsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var waypoint = (GpxPoint)WaypointsListView.SelectedItem;
		if (waypoint != null)
		{
			WaypointElevationLabel.Text = Utils.GetDouble(waypoint.Elevation);
			WaypointFixLabel.Text = Utils.GetFix(waypoint.Fix);
			WaypointTimeLabel.Text = Utils.GetTime(waypoint.Time);
			WaypointPrecisionLabel.Text = Utils.GetPrecision(waypoint);
			WaypointNameLabel.Text = waypoint.Name ?? "";
			WaypointCommentLabel.Text = waypoint.Comment ?? "";
			WaypointDescriptionLabel.Text = waypoint.Description ?? "";
			WaypointSourceLabel.Text = waypoint.Source ?? "";
			WaypointMagVarLabel.Text = Utils.GetDouble(waypoint.MagneticVariation);
			WaypointGeoidHeightLabel.Text = Utils.GetDouble(waypoint.GeoidHeight);
			WaypointSymbolLabel.Text = waypoint.SymbolName ?? "";
			WaypointTypeLabel.Text = waypoint.Type ?? "";
			WaypointNumSatLabel.Text = Utils.GetUInt(waypoint.NumSatellites);
			WaypointDgpsAgeLabel.Text = Utils.GetDouble(waypoint.AgeOfDgpsData);
			WaypointDgpsIdLabel.Text = Utils.GetUInt(waypoint.DgpsId);
			WaypointLinksListView.ItemsSource = waypoint.Links;
		}
	}

	private void MapButton_Clicked(object sender, EventArgs e)
	{
	}
}