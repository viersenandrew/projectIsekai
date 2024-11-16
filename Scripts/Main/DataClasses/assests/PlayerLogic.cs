using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class PlayerLogic : CharacterBody2D
{
	[Export] // Allows you to export a value with the class member and becomes editing becomes available in the property editor
    public int Speed { get; set; } = 400;
	[Export]
	public int DashSpeed { get; set; } = 600;
    [Export]
    public int Health { get; set; } = 100;
    [Export]
    public int Money { get; set; } = 0;
    [Export]
    public int Experience { get; set; } = 0;
    [Export]
    public int Renown { get; set; } = 0;
    public int[,,] Inventory = {{},{},{}}
    
    

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
