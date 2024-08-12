using Godot;
using System;

public partial class GameMaster : Node
{
	
	// Release.Features.Patch
	public static string gameVersion = "0.1.1 Build Date: 7/24/24";

	//The slot number saved and loaded to by default:
	public static int currentSlotNum = 0;

	//Pause Functionality
	public static bool paused = false;
	public static bool pauseAllowed = false;

	//Cutscene Functionality
	public static bool ignorePlayerInput = false;

	//Base Player Data
	//Initilizes a runtime copy of PlayerData
	public static PlayerData playerData = new PlayerData();

	//Game Data
	public static GameData gameData = new GameData();

	//Data Types Enum
    public enum SaveTypes { playerDat, gameDat }

    //Save Slots
	//When adding more save slots update all PlayerData Save/Load Functions
    public static PlayerData loadedPlayerDataSlot1 = new PlayerData();
    public static PlayerData loadedPlayerDataSlot2 = new PlayerData();
    public static PlayerData loadedPlayerDataSlot3 = new PlayerData();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
        //Populate Dictionaries
        playerData.init();
        loadedPlayerDataSlot1.init();
        loadedPlayerDataSlot2.init();
        loadedPlayerDataSlot3.init();

        //Load Game System Data
        LoadGameData();

        //Load saved Player Data into seperate fields so they can be displayed / manipulated on the save/load menu
        LoadPlayerDataSlot(1);
        LoadPlayerDataSlot(2);
        LoadPlayerDataSlot(3);

        //Set full screen
        //DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
	}
	/*Method Stubs for Save and Load Function
	 ***  Methods are created further down *** */
	// Takes a slot number and loads it into the Runtime.
	public static void SavePlayerData(int slotNum) { Save(SaveTypes.playerDat, slotNum); }
    public static void LoadPlayerData(int slotNum) { Load(SaveTypes.playerDat, slotNum, false); }
	/* Takes a slot number and loads it into the DataSlot which is then used by
	the above LoadPlayerData() method to load into the Runtime.
	*/
    public static void LoadPlayerDataSlot(int slotNum) { Load(SaveTypes.playerDat, slotNum, true); }
    //Overwrites the slot number given with the default player data values.
	public static void DeletePlayerData(int slotNum) { Delete(SaveTypes.playerDat, slotNum); }

	//Method Stubs for Save and Load GameData Load Function
	/*Only 1 GameData needs to exist at one time so the SaveGameData function
    only needs a type*/
	public static void SaveGameData() { Save(SaveTypes.gameDat, 1); }
    public static void LoadGameData() { Load(SaveTypes.gameDat, 1); }
    public static void DeleteGameData() { Delete(SaveTypes.gameDat, 1); }


    private static void Save(SaveTypes mySaveType, int slotNum) {
        //Don't save slot 0
        if (slotNum == 0) { return; }

		//construct a string for the Save File
        string myFilePath = "user://" + mySaveType.ToString() + slotNum + ".sav";

        //Save File Object
        using var saveGame = FileAccess.Open(myFilePath, FileAccess.ModeFlags.Write);

		//create an empty string
        string jsonString = string.Empty;

        //Convert entire class to json string. PlayerData
        if (mySaveType == SaveTypes.playerDat) {
            jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(playerData);
        }
		//Convert entire class to json string. GameData
        if (mySaveType == SaveTypes.gameDat) {
            jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(gameData);
        }


        //Write String to File
        saveGame.StoreLine(jsonString);
    }


    private static void Load(SaveTypes mySaveType, int slotNum, bool loadToSlot = false) {
        string myFilePath = "user://" + mySaveType.ToString() + slotNum + ".sav";

        //Can't open file
        if (FileAccess.FileExists(myFilePath) == false) {
            GD.Print("File doesnt exist: " +  myFilePath);
            initializeSlot(mySaveType, slotNum);
            return;
        }

        // Open File
        var saveGame = FileAccess.Open(myFilePath, FileAccess.ModeFlags.Read);

        //Read File Contents. File is only one line, so it does not need to be iterated.
        var jsonString = saveGame.GetLine();

        if (mySaveType == SaveTypes.playerDat) {
            if (loadToSlot == false) {
                Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, playerData);
            } else {
                if (slotNum == 1) { Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, loadedPlayerDataSlot1); }
                if (slotNum == 2) { Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, loadedPlayerDataSlot2); }
                if (slotNum == 3) { Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, loadedPlayerDataSlot3); }
            }
        }

        if (mySaveType == SaveTypes.gameDat) {
            Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, gameData);
        }
    }


    private static void Delete(SaveTypes mySaveType, int slotNum) {
        string myFilePath = "user://" + mySaveType.ToString() + slotNum + ".sav";

        //Overwrite Player Data for Specified Slot
        if (mySaveType == SaveTypes.playerDat) {
            initializeSlot(SaveTypes.gameDat, slotNum);
        }

        //Overwrite Default Game Data for Specified Slot
        if (mySaveType == SaveTypes.gameDat) { initializeSlot(SaveTypes.gameDat, 1); }

        //Save to file
        Save(mySaveType, slotNum);
    }

    private static void initializeSlot(SaveTypes mySaveType, int slotNum) {
        if (mySaveType == SaveTypes.playerDat) {
            if (slotNum == 0) { playerData = new PlayerData(); playerData.init(); }
            if (slotNum == 1) { loadedPlayerDataSlot1 = new PlayerData(); loadedPlayerDataSlot1.init(); SavePlayerData(slotNum); }
            if (slotNum == 2) { loadedPlayerDataSlot2 = new PlayerData(); loadedPlayerDataSlot2.init(); SavePlayerData(slotNum); }
            if (slotNum == 3) { loadedPlayerDataSlot3 = new PlayerData(); loadedPlayerDataSlot3.init(); SavePlayerData(slotNum); }
        }
        if (mySaveType == SaveTypes.gameDat) { gameData = new GameData(); SaveGameData(); }
    }

}
