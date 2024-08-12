using Godot;
using System;
using System.Collections.Generic;

//Create an enumerated list called eSceneNames
public enum eSceneNames {
	MainMenu = 10,
	Settings = 20,
	Main = 30, 
	Inventory = 80,
	Shopping = 85,
	CombatTestScene = 90,
	SpecialThanks = 99

}
public partial class SceneManager : Node {

	// Create a SceneManager class called instance
	
	public static SceneManager instance;

		// Create a C# Dicitionary containing the scene's enum eSceneNames value and inherit the SceneData class
		// This allows you to store multiple values from the SceneData() class
		// Note: Godot's Dictionary system does not like custom classes
		public Dictionary<eSceneNames, SceneData> sceneDictionary = new Dictionary<eSceneNames, SceneData>() {
			//Connect this via the Godot Project Setting Auto-Load Feature
			{eSceneNames.MainMenu, new SceneData("res://Scenes/10_MainMenu.tscn", "Main Menu", false) },
			{eSceneNames.Settings, new SceneData("res://Scenes/20_Settings_Scene.tscn", "Settings", false) },
			{eSceneNames.Main, new SceneData("res://Scenes/30_Main.tscn", "Main", true) },
			{eSceneNames.Inventory, new SceneData("res://Scenes/80_Inventory.tscn", "Inventory", false) },
			{eSceneNames.Shopping, new SceneData("res://Scenes/85_Shopping.tscn", "Shopping", false) },
			{eSceneNames.CombatTestScene, new SceneData("res://Scenes/90_CombatTestScene.tscn", "CombatTestScene", false) },
			{eSceneNames.SpecialThanks, new SceneData("res://Scenes/99_SpecialThanks.tscn", "SpecialThanks", false) }
		};
	public override void _Ready() {
		instance = this;
		
	}

	public void ChangeScene(eSceneNames mySceneName) {
		string myPath = sceneDictionary[mySceneName].path;
		GameMaster.pauseAllowed = sceneDictionary[mySceneName].pauseAllowed;
		GetTree().ChangeSceneToFile(myPath);
	}
}
