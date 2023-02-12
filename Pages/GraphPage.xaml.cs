using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class GraphPage : ContentPage
{
    private DateTime originalStartTime;
    private DateTime originalEndTime;

    public GraphPage(GpxTrack track)
	{
		InitializeComponent();

		Graph.Track = track;
		originalStartTime = track.Segments.StartTime;
        originalEndTime = track.Segments.EndTime;

        ShowPositionBarSwitch.IsToggled = Graph.ShowPositionBar;
		UserCanMovePositionBarSwitch.IsToggled = Graph.UserCanMovePositionBar;
		UserCanMovePositionBarSwitch.IsEnabled = Graph.ShowPositionBar;
		PaddingLabel.Text = Graph.Padding.ToString();
		PaddingStepper.Value = Graph.Padding;
        LineWidthLabel.Text = Graph.LineWidth.ToString();
        LineWidthStepper.Value = Graph.LineWidth;
        PositionBarEndWidthLabel.Text = Graph.PositionBarEndWidth.ToString();
        PositionBarEndWidthStepper.Value = Graph.PositionBarEndWidth;
        PositionBarEndWidthStepper.IsEnabled = Graph.ShowPositionBar;
		MinElevationRangeLabel.Text = Graph.MinElevationRange.ToString();
        MinElevationRangeStepper.Value = Graph.MinElevationRange;
        ReductionToleranceLabel.Text = Graph.ReductionTolerance.ToString();
        ReductionToleranceStepper.Value = Graph.ReductionTolerance;
        NumPointsLabel.Text = Graph.NumPoints.ToString();
		NumReducedPointsLabel.Text = Graph.NumReducedPoints.ToString();

		var colors = new List<ColorName>()
		{
            new ColorName("Transparent", Colors.Transparent),
            new ColorName("White", Colors.White),
            new ColorName("Black", Colors.Black),
            new ColorName("Silver", Colors.Silver),
            new ColorName("Red", Colors.Red),
			new ColorName("Green", Colors.Green),
			new ColorName("Blue", Colors.Blue),
            new ColorName("Yellow", Colors.Yellow),
        };
		BackgroundColorPicker.ItemsSource = colors;
		BackgroundColorPicker.SelectedIndex = 3;
        LineColorPicker.ItemsSource = colors;
        LineColorPicker.SelectedIndex = 7;
        PositionBarColorPicker.ItemsSource = colors;
        PositionBarColorPicker.SelectedIndex = 4;

		StartTimeLabel.Text = Graph.StartTime.ToString("HH:mm:ss");
		EndTimeLabel.Text = Graph.EndTime.ToString("HH:mm:ss");
    }

    private void ShowPositionBarSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		Graph.ShowPositionBar = e.Value;
		UserCanMovePositionBarSwitch.IsEnabled = Graph.ShowPositionBar;
		PositionBarEndWidthStepper.IsEnabled = Graph.ShowPositionBar;
	}

	private void UserCanMovePositionBarSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		Graph.UserCanMovePositionBar = e.Value;
	}

	private void PaddingStepper_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		Graph.Padding = (int)e.NewValue;
		PaddingLabel.Text = Graph.Padding.ToString();
	}

	private void LineWidthStepper_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		Graph.LineWidth = (int)e.NewValue;
		LineWidthLabel.Text = Graph.LineWidth.ToString();
	}

	private void PositionBarEndWidthStepper_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		Graph.PositionBarEndWidth= (int)e.NewValue;
		PositionBarEndWidthLabel.Text = Graph.PositionBarEndWidth.ToString();
	}

	private void MinElevationRangeStepper_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		Graph.MinElevationRange= (int)e.NewValue;
		MinElevationRangeLabel.Text = Graph.MinElevationRange.ToString();
	}

	private void ReductionToleranceStepper_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		Graph.ReductionTolerance = e.NewValue;
		ReductionToleranceLabel.Text = Graph.ReductionTolerance.ToString();
		NumPointsLabel.Text = Graph.NumPoints.ToString();
		NumReducedPointsLabel.Text = Graph.NumReducedPoints.ToString();
	}

    private void BackgroundColorPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ColorName color = BackgroundColorPicker.SelectedItem as ColorName;
        Graph.BackgroundColor = color.Color;
    }

    private void LineColorPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ColorName color = LineColorPicker.SelectedItem as ColorName;
        Graph.LineColor = color.Color;
    }

    private void PositionBarColorPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ColorName color = PositionBarColorPicker.SelectedItem as ColorName;
        Graph.PositionBarColor = color.Color;
    }

    private void StartTimeStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		Graph.StartTime = originalStartTime + TimeSpan.FromMinutes((int)e.NewValue);
        StartTimeLabel.Text = Graph.StartTime.ToString("HH:mm:ss");
    }

    private void EndTimeStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Graph.EndTime = originalEndTime + TimeSpan.FromMinutes((int)e.NewValue);
        EndTimeLabel.Text = Graph.EndTime.ToString("HH:mm:ss");
    }

    private class ColorName
	{
		public string Name { get; set; }
        public Color Color { get; set; }

		public ColorName(string name, Color color)
		{
			Name = name;
			Color = color;
		}

        public override string ToString()
        {
            return Name;
        }
    }
}