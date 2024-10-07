using Godot;
using System;

public partial class HealthBar : ProgressBar
{
	// Called when the node enters the scene tree for the first time.
	public HealthBar healthBar;
	public float currentValueHealthBar = 100f;

	public override void _Ready()
	{
		healthBar = GetNode<HealthBar>(".");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void takeDamage(float damage){
		currentValueHealthBar = currentValueHealthBar - damage;
		healthBar.Value = currentValueHealthBar;
	}

}
