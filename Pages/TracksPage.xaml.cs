using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class TracksPage : ContentPage
{
	public TracksPage()
	{
		InitializeComponent();
        Utils.GpxLoaded += HandleGpxLoaded;
        TracksListView.ItemTapped += TracksListView_ItemTapped;
        TracksListView.ItemSelected += TracksListView_ItemSelected;
        SegmentsListView.ItemSelected += SegmentsListView_ItemSelected;
        PointsListView.ItemTapped += PointsListView_ItemTapped;
		HandleGpxLoaded(null, EventArgs.Empty);
	}

    private void HandleGpxLoaded(object sender, EventArgs e)
	{
		if (Utils.gpx != null)
		{
			TracksListView.ItemsSource = Utils.gpx.Tracks;
			if (Utils.gpx.Tracks.Count > 0)
			{
				TracksListView.SelectedItem = Utils.gpx.Tracks[0];
			}
		}
	}

    private void TracksListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var track = (GpxTrack)e.Item;
        if (track != null)
		{
            Navigation.PushAsync(new RouteTrackPage(track));
        }
    }

    private void TracksListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var track = (GpxTrack)e.SelectedItem;
		if (track != null)
		{
			SegmentsListView.ItemsSource = track.Segments;
			if (track.Segments.Count > 0)
			{
				SegmentsListView.SelectedItem = track.Segments[0];
			}
        }
	}

    private void SegmentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var segment = (GpxTrackSegment)SegmentsListView.SelectedItem;
		if (segment != null)
		{
			PointsListView.ItemsSource = segment.Points;
		}
	}

    private void PointsListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var point = (GpxPoint)e.Item;
        if (point != null)
        {
            Navigation.PushAsync(new PointPage(point));
        }
    }

    private void MapButton_Clicked(object sender, EventArgs e)
	{
	}

	private void GraphButton_Clicked(object sender, EventArgs e)
	{
	}
}