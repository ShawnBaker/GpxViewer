using FrozenNorth.Gpx;

namespace GpxViewer
{
    public static class Utils
    {
        public static Gpx gpx = null;
        public static event EventHandler GpxLoaded = null;

        public static async Task OpenFileAsync(string fileName)
        {
            gpx = await GpxReader.LoadAsync(fileName);
            GpxLoaded?.Invoke(null, EventArgs.Empty);
        }

        public static async Task OpenFileAsync(Stream stream)
        {
            gpx = await GpxReader.LoadAsync(stream);
            GpxLoaded?.Invoke(null, EventArgs.Empty);
        }

        public static async Task SaveFileAsync(string fileName)
		{
			await GpxWriter.SaveAsync(gpx, fileName);
		}

        public static string GetBounds(GpxBounds bounds)
		{
			return (bounds != null) ? bounds.ToString() : "";
		}

		public static string GetCopyright(GpxCopyright copyright)
		{
			return (copyright != null) ? copyright.ToString() : "";
		}

		public static string GetDouble(double? value)
		{
			return (value != null) ? value.ToString() : "";
		}

		public static string GetEmail(GpxEmail email)
		{
			return (email != null) ? email.ToString() : "";
		}

		public static string GetFix(GpxFix? fix)
		{
			string str = "";
			if (fix != null)
			{
				switch (fix)
				{
					case GpxFix.None:
						str = "None";
						break;
					case GpxFix.TwoD:
						str = "2D";
						break;
					case GpxFix.ThreeD:
						str = "3D";
						break;
					case GpxFix.DGPS:
						str = "DGPS";
						break;
					case GpxFix.PPS:
						str = "PPS";
						break;
				}
			}
			return str;
		}

		public static string GetLink(GpxLink link)
		{
			return (link != null) ? link.ToString() : "";
		}

		public static string GetPrecision(GpxPoint point)
		{
			string str = "";
			if (point.Hdop != null)
			{
				str = "H:" + point.Hdop.ToString();
			}
			if (point.Vdop != null)
			{
				if (!string.IsNullOrEmpty(str)) str += ",";
				str += "V:" + point.Vdop.ToString();
			}
			if (point.Pdop != null)
			{
				if (!string.IsNullOrEmpty(str)) str += ",";
				str += "P:" + point.Pdop.ToString();
			}
			return str;
		}

		public static string GetTime(DateTime? time)
		{
			return (time != null) ? time.Value.ToUniversalTime().ToString(GpxWriter.TimeFormat) : "";
		}

		public static string GetUInt(uint? value)
		{
			return (value != null) ? value.ToString() : "";
		}
	}
}
