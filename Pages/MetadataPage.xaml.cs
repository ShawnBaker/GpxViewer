namespace GpxViewer;

public partial class MetadataPage : ContentPage
{
	public MetadataPage()
	{
		InitializeComponent();
        Utils.GpxLoaded += HandleGpxLoaded;
    }

    private void HandleGpxLoaded(object sender, EventArgs e)
    {
        if (Utils.gpx != null)
        {
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
        }
    }
}