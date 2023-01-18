using FrozenNorth.Gpx;

namespace GpxViewer;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
		Utils.GpxLoaded += HandleGpxLoaded;
    }

	private void HandleGpxLoaded(object sender, EventArgs e)
	{
        if (Utils.gpx != null)
        {
            CreatorLabel.Text = Utils.gpx.Creator ?? "";
            VersionLabel.Text = Utils.gpx.Version ?? "";
            NameLabel.Text = Utils.gpx.Metadata.Name ?? "";
            DescriptionLabel.Text = Utils.gpx.Metadata.Description ?? "";
            if (Utils.gpx.Metadata.Author != null)
            {
                AuthorLabel.Text = Utils.gpx.Metadata.Author.Name ?? "";
                EmailLabel.Text = Utils.GetEmail(Utils.gpx.Metadata.Author.Email);
                LinkLabel.Text = Utils.GetLink(Utils.gpx.Metadata.Author.Link);
            }
            CopyrightLabel.Text = Utils.GetCopyright(Utils.gpx.Metadata.Copyright);
            TimeLabel.Text = Utils.GetTime(Utils.gpx.Metadata.Time);
            KeywordsLabel.Text = Utils.gpx.Metadata.Keywords ?? "";
            BoundsLabel.Text = Utils.GetBounds(Utils.gpx.Metadata.Bounds);
            LinksListView.ItemsSource = Utils.gpx.Metadata.Links;
            SaveButton.IsEnabled = true;
		}
	}

	private async void LoadButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            FilePickerFileType fileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
					{ DevicePlatform.WinUI, new[] { ".gpx" } },
					{ DevicePlatform.macOS, new[] { "gpx" } },
				}
			);
            PickOptions options = new()
            {
                FileTypes = fileType,
            };
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                string fileName = result.FullPath;
                FileNameEntry.Text = Path.GetFileName(fileName);
                Utils.OpenFile(fileName);
            }
        }
        catch { }
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        string fileName = Path.GetFileNameWithoutExtension(Utils.gpx.FileName) + "_2" + Path.GetExtension(Utils.gpx.FileName);
        fileName = Path.Combine(Path.GetDirectoryName(Utils.gpx.FileName), fileName);
        Utils.SaveFile(fileName);
	}
}
