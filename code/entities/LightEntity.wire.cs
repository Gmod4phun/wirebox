using Sandbox;
public partial class LightEntity : WireInputEntity
{
	WirePortData IWireEntity.WirePorts { get; } = new WirePortData();
	public void WireInitialize()
	{
		this.RegisterInputHandler( "On", ( bool value ) => {
			Enabled = value;
		} );
		this.RegisterInputHandler( "Brightness", ( float value ) => {
			BrightnessMultiplier = value;
		} );
	}
}
