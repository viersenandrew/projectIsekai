using Godot;
using System.Collection.Generic;

public class GameStateFlags: Node
{
    // Dictionary for World States
    private Dictionary<string, bool> worldFlags = new Dictionary<string, bool>();
    private Dictionary<string, bool> progressionFlags = new Dictionary<string, bool>();
    private Dictionary<string, bool> cityTitanFlags = new Dictionary<string, bool>();
    private Dictionary<string, bool> cityNileFlags = new Dictionary<string, bool>();
    
}