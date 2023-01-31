using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class PointPage : ContentPage
{
	public PointPage(GpxPoint point)
	{
		InitializeComponent();

		LatitudeLabel.Text = Utils.GetDouble(point.Latitude);
		LongitudeLabel.Text = Utils.GetDouble(point.Longitude);
		ElevationLabel.Text = Utils.GetDouble(point.Elevation);
		ElevationLabel.Text = Utils.GetDouble(point.Elevation);
		FixLabel.Text = Utils.GetFix(point.Fix);
		TimeLabel.Text = Utils.GetTime(point.Time);
		PrecisionLabel.Text = Utils.GetPrecision(point);
		NameLabel.Text = point.Name ?? "";
		CommentLabel.Text = point.Comment ?? "";
		DescriptionLabel.Text = point.Description ?? "";
		SourceLabel.Text = point.Source ?? "";
		MagVarLabel.Text = Utils.GetDouble(point.MagneticVariation);
		GeoidHeightLabel.Text = Utils.GetDouble(point.GeoidHeight);
		SymbolLabel.Text = point.SymbolName ?? "";
		TypeLabel.Text = point.Type ?? "";
		NumSatLabel.Text = Utils.GetUInt(point.NumSatellites);
		DgpsAgeLabel.Text = Utils.GetDouble(point.AgeOfDgpsData);
		DgpsIdLabel.Text = Utils.GetUInt(point.DgpsId);
		LinksListView.ItemsSource = point.Links;
	}
}