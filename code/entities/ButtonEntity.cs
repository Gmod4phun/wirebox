﻿using Sandbox;
using System;
using System.Linq;

[Library( "ent_button", Title = "Button", Spawnable = true )]
public partial class ButtonEntity : Prop, IUse, WireOutputEntity
{
	public bool On { get; set; } = false;
	public bool IsToggle { get; set; } = false;

	public override void Spawn()
	{
		base.Spawn();
		SetModel( "models/wirebox/katlatze/button.vmdl" );
		SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
	}
	public bool IsUsable( Entity user )
	{
		return true;
	}

	private bool ModelUsesMaterialGroups()
	{
		var model = GetModelName();
		if ( model == "models/wirebox/katlatze/button.vmdl" ) {
			return true;
		}
		return false;
	}

	public bool OnUse( Entity user )
	{
		if ( user is Player player ) {
			On = !On;
			if ( ModelUsesMaterialGroups() ) {
				SetMaterialGroup( On ? 1 : 0 );
			}
			else {
				RenderColor = On ? Color32.Green : Color32.Red;
			}
			WireOutputEntity.WireTriggerOutput( this, "On", On ? 1 : 0 );
		}

		return false;
	}

	public string[] WireGetOutputs()
	{
		return new string[] { "On" };
	}
}
