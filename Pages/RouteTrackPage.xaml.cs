using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class RouteTrackPage : ContentPage
{
	public RouteTrackPage(GpxRoute route)
	{
		InitializeComponent();

        Title = "Route";
        NameLabel.Text = route.Name ?? "";
        CommentLabel.Text = route.Comment ?? "";
        DescriptionLabel.Text = route.Description ?? "";
        SourceLabel.Text = route.Source ?? "";
        NumberLabel.Text = Utils.GetUInt(route.Number);
        TypeLabel.Text = route.Type ?? "";
        LinksListView.ItemsSource = route.Links;
    }

    public RouteTrackPage(GpxTrack track)
    {
        InitializeComponent();

        Title = "Track";
        NameLabel.Text = track.Name ?? "";
        CommentLabel.Text = track.Comment ?? "";
        DescriptionLabel.Text = track.Description ?? "";
        SourceLabel.Text = track.Source ?? "";
        NumberLabel.Text = Utils.GetUInt(track.Number);
        TypeLabel.Text = track.Type ?? "";
        LinksListView.ItemsSource = track.Links;
    }
}