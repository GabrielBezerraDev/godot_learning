using Godot;
using System;

public partial class CharacterPhysics : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.

	public float velocityH = 180;
	public float velocityV = 150;

	public bool isJump = false;
	public Vector2 velocity;

	public float gravity = 70f;
	public HealthBar healthBar;

	public AnimatedSprite2D animated;
	public override void _Ready()
	{
		GD.Print($"velocidade Y: {GetGravity()}");
		healthBar = GetNode<HealthBar>("Control/ProgressBar");
		animated = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animated.Play("idle");
	}


    public override void _PhysicsProcess(double delta)
    {
		GD.Print(velocity.Y);
		velocity = Velocity;
		velocity.Y += gravity * (float) delta;
		float input = Input.GetAxis("ui_left","ui_right");
		bool teste = Input.IsActionJustPressed("ui_accept");
		bool throwAnFloor = Input.IsActionJustPressed("ui_down");
		if(teste && !isJump){
			 velocity.Y = velocityV * -1;
			 characterJump();
		} 
		if(input > 0){
			animationsCharacter("run");
			animated.Scale = new Vector2(1f,1f);
		}else if(input < 0){
			animationsCharacter("run");
			animated.Scale = new Vector2(-1f,1f);
		}else{
			animationsCharacter("idle");
		}

		if(throwAnFloor){ 
			gravity = 30000f;
		}else{
			gravity = 70f;
		}

		if(velocity.Y > 0 && isJump){
			animated.Play("falling");
		}
		velocity.X = velocityH*input;
		Velocity = velocity;
		MoveAndSlide();
    }

	public void animationsCharacter(String animation){
		if(!isJump) animated.Play(animation);
	}

	public void characterJump(){
		isJump = true;
		animated.Play("jump");
	}

	public void characterAnFloor(){
		isJump = false;
		animationsCharacter("idle");
	}
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

	public HealthBar getHealthBar(){
		return healthBar;
	}
}
