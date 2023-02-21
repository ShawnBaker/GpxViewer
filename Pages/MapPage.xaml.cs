using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class MapPage : ContentPage
{
    public MapPage(bool showRoutes, bool showWaypoints, bool showTracks)
    {
        InitializeComponent();

        Map.ShowRoutes = showRoutes;
        Map.ShowWaypoints = showWaypoints;
        Map.ShowTracks = showTracks;

        ShowRoutesSwitch.IsToggled = showRoutes;
        ShowWaypointsSwitch.IsToggled = showWaypoints;
        ShowTracksSwitch.IsToggled = showTracks;
        ReductionToleranceLabel.Text = Map.ReductionTolerance.ToString();
        ReductionToleranceStepper.Value = Map.ReductionTolerance;

        var colors = new List<ColorName>()
        {
            new ColorName("White", Colors.White),
            new ColorName("Black", Colors.Black),
            new ColorName("Silver", Colors.Silver),
            new ColorName("Red", Colors.Red),
            new ColorName("Green", Colors.Green),
            new ColorName("Blue", Colors.Blue),
            new ColorName("Yellow", Colors.Yellow),
        };
        RouteColorPicker.ItemsSource = colors;
        RouteColorPicker.SelectedIndex = 5;
        TrackColorPicker.ItemsSource = colors;
        TrackColorPicker.SelectedIndex = 3;
    }

    public MapPage(Gpx gpx)
            : this(true, true, true)
    {
        Map.Gpx = gpx;
        NumPointsLabel.Text = Map.NumTrackPoints.ToString();
        NumReducedPointsLabel.Text = Map.NumReducedTrackPoints.ToString();
    }

    public MapPage(GpxRoute route)
            : this(true, false, false)
    {
        Map.Route = route;
        NumPointsLabel.Text = Map.NumTrackPoints.ToString();
        NumReducedPointsLabel.Text = Map.NumReducedTrackPoints.ToString();
    }

    public MapPage(GpxPointList waypoints)
            : this(false, true, false)
    {
        Map.Waypoints = waypoints;
        NumPointsLabel.Text = Map.NumTrackPoints.ToString();
        NumReducedPointsLabel.Text = Map.NumReducedTrackPoints.ToString();
    }

    public MapPage(GpxTrack track)
            : this(false, false, true)
    {
        Map.Track = track;
        NumPointsLabel.Text = Map.NumTrackPoints.ToString();
        NumReducedPointsLabel.Text = Map.NumReducedTrackPoints.ToString();
    }

    private void ShowRoutesSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Map.ShowRoutes = e.Value;
    }

    private void ShowWaypointsSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Map.ShowWaypoints = e.Value;
    }

    private void ShowTracksSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Map.ShowTracks = e.Value;
    }

    private void ReductionToleranceStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Map.ReductionTolerance = e.NewValue;
        ReductionToleranceLabel.Text = Map.ReductionTolerance.ToString();
        NumPointsLabel.Text = Map.NumTrackPoints.ToString();
        NumReducedPointsLabel.Text = Map.NumReducedTrackPoints.ToString();
    }

    private void RouteColorPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ColorName color = RouteColorPicker.SelectedItem as ColorName;
        Map.RouteColor = color.Color;
    }

    private void TrackColorPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ColorName color = TrackColorPicker.SelectedItem as ColorName;
        Map.TrackColor = color.Color;
    }
}