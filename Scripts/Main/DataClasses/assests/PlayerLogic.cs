using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class PlayerLogic : CharacterBody2D
{
	[Export]
    public int Speed { get; set; } = 400;
	[Export]
	public int DashSpeed { get; set; } = 600;
    
    

    public void GetInput()
    {

        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * Speed;
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }
}
