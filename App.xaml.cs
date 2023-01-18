namespace GpxViewer;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

	protected override Window CreateWindow(IActivationState activationState)
	{
		Window window = base.CreateWindow(activationState);
        Settings.SetWindowFrame(window);
        window.Destroying += (s, e) =>
        {
            Settings.SaveWindowFrame(window);
        };
		return window;
	}
}
