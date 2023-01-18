using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class TracksPage : ContentPage
{
	public TracksPage()
	{
		InitializeComponent();
		Utils.GpxLoaded += HandleGpxLoaded;
		TracksListView.ItemSelected += TracksListView_ItemSelected;
		SegmentsListView.ItemSelected += SegmentsListView_ItemSelected;
		PointsListView.ItemSelected += PointsListView_ItemSelected;
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

	private void TracksListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var track = (GpxTrack)TracksListView.SelectedItem;
		if (track != null)
		{
			TrackCommentLabel.Text = track.Comment ?? "";
			TrackDescriptionLabel.Text = track.Description ?? "";
			TrackSourceLabel.Text = track.Source ?? "";
			TrackNumberLabel.Text = Utils.GetUInt(track.Number);
			TrackTypeLabel.Text = track.Type ?? "";
			TrackLinksListView.ItemsSource = track.Links;
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
			if (segment.Points.Count > 0)
			{
				PointsListView.SelectedItem = segment.Points[0];
			}
		}
	}

	private void PointsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var point = (GpxPoint)PointsListView.SelectedItem;
		if (point != null)
		{
			PointElevationLabel.Text = Utils.GetDouble(point.Elevation);
			PointFixLabel.Text = Utils.GetFix(point.Fix);
			PointTimeLabel.Text = Utils.GetTime(point.Time);
			PointPrecisionLabel.Text = Utils.GetPrecision(point);
			PointNameLabel.Text = point.Name ?? "";
			PointCommentLabel.Text = point.Comment ?? "";
			PointDescriptionLabel.Text = point.Description ?? "";
			PointSourceLabel.Text = point.Source ?? "";
			PointMagVarLabel.Text = Utils.GetDouble(point.MagneticVariation);
			PointGeoidHeightLabel.Text = Utils.GetDouble(point.GeoidHeight);
			PointSymbolLabel.Text = point.SymbolName ?? "";
			PointTypeLabel.Text = point.Type ?? "";
			PointNumSatLabel.Text = Utils.GetUInt(point.NumSatellites);
			PointDgpsAgeLabel.Text = Utils.GetDouble(point.AgeOfDgpsData);
			PointDgpsIdLabel.Text = Utils.GetUInt(point.DgpsId);
			PointLinksListView.ItemsSource = point.Links;
		}
	}

	private void MapButton_Clicked(object sender, EventArgs e)
	{
	}

	private void GraphButton_Clicked(object sender, EventArgs e)
	{
	}
}