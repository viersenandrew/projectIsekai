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
    // Stages: Dicitionary that maps the quest's stage together.
    public Dicitionary<string, Dicitionary<string, object>> Stages {get; set; }
    
    // Constructor to intialize properties
    public Quest(string questId, string questName, string questDescription)
    {
        QuestId = questId;
        QuestName = questName;
        QuestDescription = questDescription;
        
    }
}