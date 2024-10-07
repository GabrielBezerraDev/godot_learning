using Godot;
using System;

public partial class physics : RigidBody2D
{

	public RigidBody2D rigidBody2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rigidBody2D = GetNode<RigidBody2D>(".");
		if(rigidBody2D != null){
			GD.Print($"teste {rigidBody2D}");
		}else{
			GD.Print($"testando Godot");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
