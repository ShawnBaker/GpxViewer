using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class RoutesPage : ContentPage
{
	public RoutesPage()
	{
		InitializeComponent();
		Utils.GpxLoaded += HandleGpxLoaded;
		RoutesListView.ItemSelected += RoutesListView_ItemSelected;
		PointsListView.ItemSelected += PointsListView_ItemSelected;
		HandleGpxLoaded(null, EventArgs.Empty);
	}

	private void HandleGpxLoaded(object sender, EventArgs e)
	{
		if (Utils.gpx != null)
		{
			RoutesListView.ItemsSource = Utils.gpx.Routes;
			if (Utils.gpx.Routes.Count > 0)
			{
				RoutesListView.SelectedItem = Utils.gpx.Routes[0];
			}
		}
	}

	private void RoutesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var route = (GpxRoute)RoutesListView.SelectedItem;
		if (route != null)
		{
			RouteCommentLabel.Text = route.Comment ?? "";
			RouteDescriptionLabel.Text = route.Description ?? "";
			RouteSourceLabel.Text = route.Source ?? "";
			RouteNumberLabel.Text = Utils.GetUInt(route.Number);
			RouteTypeLabel.Text = route.Type ?? "";
			RouteLinksListView.ItemsSource = route.Links;
			PointsListView.ItemsSource = route.Points;
			if (route.Points.Count > 0)
			{
				PointsListView.SelectedItem = route.Points[0];
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