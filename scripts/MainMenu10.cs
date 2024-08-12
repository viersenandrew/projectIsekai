using Godot;
using System;

public partial class MainMenu10 : Node2D
{
	[Export] public Label myLabel;
	[Export] public eSceneNames mySceneName;

	private int count = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() { 
		//myLabel.Text = "This is what text will look like in-game.";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) { }

	//Button changes scene to Main
	public void _on_start_game_button_up() {
		SceneManager.instance.ChangeScene(eSceneNames.Main);
	}
	public void _on_settings_button_up() {
		SceneManager.instance.ChangeScene(eSceneNames.Settings);
	}

}
