using Godot;
using System.Collections.Generic;

public class GameStateFlags: Node
{
    // Instantiate Dictionaries for Game State Flags
    private Dictionary<string, bool> worldFlags = new Dictionary<string, bool>();
    private Dictionary<string, bool> levelProgressionFlags = new Dictionary<string, bool>();
    private Dictionary<string, bool> cityTitanFlags = new Dictionary<string, bool>();
    private Dictionary<string, bool> cityNileFlags = new Dictionary<string, bool>();
    private Dictionary<string, bool> cityCaesarFlags = new Dictionary<string, bool>();


    // Declare Path to JSON
    private string worldFlagsPath = "res://Scripts/Main/GameDatabase/WorldFlags.json";
    private string levelProgressionFlagsPath = "res://Scripts/Main?GameDatabase/LevelProgressionFlags.json";
    private string cityTitanFlagsPath = "res://Scripts/Main/GameDatabase/CityTitanFlags.json";
    private string cityNileFlagsPath = "res://Scripts/Main/GameDatabase/CityNileFlags.json";
    private string cityCaesarFlagsPath = "res://Scripts/Main/GameDatabase/CityCaesarFlags.json";


    public override void _Ready()
    {
        // Load JSON data into dictionaries
        worldFlags = LoadFlagsFromJson(worldFlagsPath);
        levelProgressionFlags = LoadFlagsFromJson(levelProgressionFlagsPath);
        cityTitanFlags = LoadFlagsFromJson(cityTitanFlagsPath);
        cityNileFlags = LoadFlagsFromJson(cityNileFlagsPath);
        cityCaesarFlags = LoadFlagsFromJson(cityCaesarFlagsPath)

        
    }

    // Function to load flags from JSON file
    private Dictionary<string, bool> LoadFlagsFromJson(string filePath)
    {
        var flags = new Dictionary<string, bool>();

        if (!File.Exists(filePath))
        {
            GD.PrintErr($"File not found: {filePath}");
            return flags;
        }
        var file = new File();
        file.Open(filePath, file.ModeFlags.Read);
        var jsonContent = file.GetAsText();
        file.Close();

        var jsonResult = JSON.Parse(jsonContent);
        if (jsonResult.Error != Error.Ok)
        {
            GD.PrintErr($"Error parsing JSON from {filePath}: {jsonResult.ErrorString}");
            return flags;
        }

        // Convert Json to dicitionary
        var jsonDict = jsonResult.Result as Godot.Collections.Dicitionary;
        if (jsonDict != null)
        {
            foreach (var key in jsonDict.keys)
            {
                flags[key.ToString()] = (bool)jsonDict[key];
            }
        }
        return flags
    }

    // SetFlag updates in-memory data 
    public void SetFlag(string category, string flagName, bool state)
    {
        switch (category)
        {
            case "World":
            if (worldFlags.ContainsKey(flagName))
                worldFlags[flagName] = state;
            break;

            case "Progression":
            if (levelProgressionFlags.ContainsKey(flagName))
                levelProgressionFlags[flagName] = state;
            break;

            case "CityTitan":
            if (cityTitanFlags.ContainsKey(flagName))
                cityTitanFlags[flagName] = state;
            break;

            case "CityNile":
            if (cityNileFlags.ContainsKey(flagName))
                cityNileFlags[flagName] = state;
            break;

            case "CityCaesar":
            if (cityCaesarFlags.ContainsKey(flagName))
                cityCaesarFlags[flagName] = state;
            break;
            

        }
    }    
}