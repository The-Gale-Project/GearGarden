using System.Globalization;
using Godot;

public partial class IconButton : Button
{
	[Export]
	public string Unicode { get; set; } = "f2b4";

	[ExportGroup("Font Settings")]
	[Export]
	public Font FontAwesomeRef { get; set; }

	[Export]
	public int FontSize { get; set; } = 32;

	private char realCharacter = '\uf2b4';

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (ushort.TryParse(
				s: this.Unicode,
				style: NumberStyles.HexNumber,
				provider: CultureInfo.InvariantCulture,
				result: out ushort unicode
			)
		)
		{
			this.realCharacter = (char)unicode;
		}

		this.Text = this.realCharacter.ToString();

		this.Theme = new Theme
		{
			DefaultFont = this.FontAwesomeRef,
			DefaultFontSize = this.FontSize
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
