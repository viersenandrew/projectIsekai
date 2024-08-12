using Godot;
using System;

public class SceneData
{
	//Create a constructor for the class SceneData by creating the SceneData method
	public SceneData(string path, string sceneName, bool pauseAllowed) {
		this.path = path;
		this.sceneName = sceneName;
		this.pauseAllowed = pauseAllowed;
	}
	public string path { set; get; }
	public string sceneName { set; get;}
	public bool pauseAllowed {set; get;}
}
