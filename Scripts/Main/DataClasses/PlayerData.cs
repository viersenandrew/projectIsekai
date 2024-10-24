using System.Collections.Generic;
using Godot;

public class PlayerData {

    public bool newFile = true;
    public string saveFileVersion = GameMaster.gameVersion;
    public int xPosition = 0;
    public int yPosition = 0;
    public eSceneNames savedScene = eSceneNames.Level1;
    [Export]
    public int BaseDashSpeed {get; set;}
    [Export]
    public int DashSpeedModifier {get; set;}
    public PlayerData(int baseDashSpeed = 600 , int dashSpeedModifier = 0)
    {
        BaseDashSpeed = baseDashSpeed;
        DashSpeedModifier = dashSpeedModifier;
    }

    public float GetDashSpeed()
    {
        return BaseDashSpeed + DashSpeedModifier;
    }

    
    public Dictionary<string, string> sampleDictionary = new Dictionary<string, string>() {
        { "zero", "0" },
        { "one", "1" },
        { "two", "2" },
        { "test", "original test" },
    };

}