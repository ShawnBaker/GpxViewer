namespace GpxViewer;

public partial class MainPage : ContentPage
{
    private bool enableSaveButton = false;
    private List<string> BuiltinFiles = new List<string>()
    {
        "ashland.gpx",
        "blue_hills.gpx",
        "fells_loop.gpx",
        "foxboro.gpx",
        "mystic_basin_trail.gpx"
    };

    public MainPage()
    {
        InitializeComponent();
        FilesListView.ItemsSource = BuiltinFiles;
        FilesListView.ItemSelected += FilesListView_ItemSelected;
		Utils.GpxLoaded += HandleGpxLoaded;
#if !WINDOWS && !MACCATALYST
        LoadButton.IsVisible = false;
        SaveButton.IsVisible = false;
#endif
    }

    private void HandleGpxLoaded(object sender, EventArgs e)
	{
        if (Utils.gpx != null)
        {
            CreatorLabel.Text = Utils.gpx.Creator ?? "";
            VersionLabel.Text = Utils.gpx.Version ?? "";
		}
        else
        {
            CreatorLabel.Text = "";
            VersionLabel.Text = "";
        }
        SaveButton.IsEnabled = enableSaveButton;
    }

    private async void FilesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        string fileName = (string)e.SelectedItem;
        if (!string.IsNullOrEmpty(fileName))
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
            FileNameLabel.Text = fileName;
            enableSaveButton = false;
            await Utils.OpenFileAsync(stream);
        }
    }

    private async void LoadButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            LoadButton.IsEnabled = false;
            
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
                FileNameLabel.Text = Path.GetFileName(fileName);
                enableSaveButton = true;
                await Utils.OpenFileAsync(fileName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        LoadButton.IsEnabled = true;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        string fileName = Path.GetFileNameWithoutExtension(Utils.gpx.FileName) + "_2" + Path.GetExtension(Utils.gpx.FileName);
        fileName = Path.Combine(Path.GetDirectoryName(Utils.gpx.FileName), fileName);
        await Utils.SaveFileAsync(fileName);
	}
}
