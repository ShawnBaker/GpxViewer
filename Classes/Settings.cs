namespace GpxViewer;

public static class Settings
{
    public const string KeyMainWindow = "MainWindow";

    /// <summary>
    /// Sets the position and size of the window.
    /// </summary>
    /// <param name="window">Window to set the position and size for.</param>
    public static void SetWindowFrame(Window window)
    {
        bool ok = false;
        try
        {
            string str = Preferences.Default.Get(KeyMainWindow, "").Trim();
            if (!string.IsNullOrEmpty(str))
            {
                string[] parts = str.Split(',');
                if (int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y) && int.TryParse(parts[2], out int w) && int.TryParse(parts[3], out int h))
                {
                    window.X = x;
                    window.Y = y;
                    window.Width = w;
                    window.Height = h;
                    ok = true;
                }
            }
        }
        catch { }
        if (!ok)
        {
            DisplayInfo displayInfo = DeviceDisplay.MainDisplayInfo;
            window.X = ((int)displayInfo.Width - window.Width) / 2;
            window.Y = ((int)displayInfo.Height - window.Height) / 2;
        }
    }

    /// <summary>
    /// Saves the window position and size to preferences.
    /// </summary>
    /// <param name="window">Window to save the position and size for.</param>
    public static void SaveWindowFrame(Window window)
    {
        string str = string.Format("{0},{1},{2},{3}", window.X, window.Y, window.Width, window.Height);
        Preferences.Default.Set(KeyMainWindow, str);
    }
}
