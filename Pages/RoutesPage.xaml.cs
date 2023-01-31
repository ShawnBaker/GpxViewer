using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class RoutesPage : ContentPage
{
    public RoutesPage()
	{
		InitializeComponent();
		Utils.GpxLoaded += HandleGpxLoaded;
        RoutesListView.ItemTapped += RoutesListView_ItemTapped;
        RoutesListView.ItemSelected += RoutesListView_ItemSelected;
        PointsListView.ItemTapped += PointsListView_ItemTapped;
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

    private void RoutesListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		var route = (GpxRoute)e.Item;
        if (route != null)
        {
            Navigation.PushAsync(new RouteTrackPage(route));
        }
    }

    private void RoutesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var route = (GpxRoute)e.SelectedItem;
		if (route != null)
		{
			PointsListView.ItemsSource = route.Points;
        }
    }

    private void RoutesListView_DoubleTapped(object sender, TappedEventArgs e)
    {
        var route = (GpxRoute)RoutesListView.SelectedItem;
        if (route != null)
        {
            Navigation.PushAsync(new RouteTrackPage(route));
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