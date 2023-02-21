namespace GpxViewer;

public class ColorName
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