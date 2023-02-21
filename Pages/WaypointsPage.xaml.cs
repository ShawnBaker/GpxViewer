using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class WaypointsPage : ContentPage
{
	public WaypointsPage()
	{
		InitializeComponent();
		Utils.GpxLoaded += HandleGpxLoaded;
        WaypointsListView.ItemTapped += WaypointsListView_ItemTapped;
		HandleGpxLoaded(null, EventArgs.Empty);
	}

    private void HandleGpxLoaded(object sender, EventArgs e)
	{
		if (Utils.gpx != null)
		{
			WaypointsListView.ItemsSource = Utils.gpx.Waypoints;
		}
	}

    private void WaypointsListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var waypoint = (GpxPoint)e.Item;
		if (waypoint != null)
		{
			Navigation.PushAsync(new PointPage(waypoint));
		}
	}

	private void MapButton_Clicked(object sender, EventArgs e)
	{
        if (Utils.gpx.Waypoints != null)
        {
            Navigation.PushAsync(new MapPage(Utils.gpx.Waypoints));
        }
    }
}