using Godot;
using System.Collections.Generic;


public class Quest: Node 
{
    // Declare the properties of the Quest class
    public string QuestId = { get; set; }
    public string QuestName = { get; set; }
    public string QuestDescription = { get; set; }
    public int CurrentStage = { get; set; }
    public bool QuestActive = { get; set; }
    // Reference to GameStateFlags for world triggers
    private GameStateFlags gameStateFlags;
    // Stages: Dicitionary that maps the quest's stage together.
    public Dicitionary<string, Dicitionary<string, object>> Stages {get; set; }
    
    public override void _Ready()
    {
        gameStateFlags = GetNode<GameStateFlags>("res://Scripts/Main/GameStateFlags.cs")
    }

    // Constructor to intialize properties
    public Quest(string questId, string questName, string questDescription)
    {
        QuestId = questId;
        QuestName = questName;
        QuestDescription = questDescription;
        
    }

    public void CompleteQuest(int money, int renown, int experience, List<string> items, List<string> worldFlagsToTrigger)
    {
        // Update the player's money
        GD.Print($"Awarding {money} gold to the player")
        // Update the player's renown
        GD.Print($"Awarding {renown} renown to the player")
        // Update the player's experience points
        GD.Print($"Awarding {experience} experience to the player")
       

        if (items != null && items.Count > 0)
        {
            foreach (string item in items)
            {
                GD.Print($"Awarding {items} renown to the player")
            }
        }

    }
}