using Godot;
using System;
using System.Collections.Generic;

public partial class teste : Area2D
{

	public CharacterPhysics testeJump;
	public HealthBar healthBar;
	public TileMapLayer _tileMapLayer; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		testeJump = GetNode<CharacterPhysics>("..");
		healthBar = GetNode<HealthBar>("../Control/ProgressBar");
		GD.Print(healthBar);
		Connect("body_shape_entered", Callable.From((Rid bodyRid, Node body, int body_shape_index, int local_shape_index) => 
		{testeF(bodyRid,body);}
		), (uint) GodotObject.ConnectFlags.Persist);
	}

	private void testeF(Rid bodyRid, Node body)
    {
		{
			_tileMapLayer = body as TileMapLayer;
			Godot.Variant valueTileCell = _tileMapLayer.GetCellTileData(_tileMapLayer.GetCoordsForBodyRid(bodyRid)).GetCustomDataByLayerId(0);
			Godot.Collections.Dictionary test = valueTileCell.Obj as Godot.Collections.Dictionary;
			int natureObject = (int) test["nature"];
			GD.Print($"log: {natureObject}");
			testeJump.characterAn Floor();
			if(natureObject == 2){
				Type tipo = Type.GetType((string) test["TypeObject"]);
				TileDamage instancia = Activator.CreateInstance(tipo) as TileDamage;
				instancia.setDamage((float) 1f);
				instancia.DamageCharacter(testeJump);
				instancia.printTest();
			}
			// TileDamage tileDamage = 
			
			// else if(valueTileCell == 2){
			// 	healthBar.takeDamage(20f);
			// instancia.printTest();
			// }

		}
	}

		// Called every frame. 'delddddata' is the elapsed time since the previous frame.
		// public override void _Process(double delta)
		// {w
		// }
}
