using Godot;
using System.Collections.Generic;

public class GameStateFlags: Node
{
    // Instantiate Dictionaries for Game State Flags
    private Dictionary<string, bool> worldFlags; // Just declare the variable but do not assign a value by removing the right side of the logic
    private Dictionary<string, bool> levelProgressionFlags;
    private Dictionary<string, bool> cityTitanFlags; 
    private Dictionary<string, bool> cityNileFlags; 
    private Dictionary<string, bool> cityCaesarFlags; 


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
        // Declare a variable named flags and assign it the value of a new dictionary 
        var flags = new Dictionary<string, bool>();

        // check if the filePath doesn't exist using File's Exists() method
        if (!File.Exists(filePath))
        {
            // if it doesn't exist print file not found
            GD.PrintErr($"File not found: {filePath}");
            // then return to the flags variable
            return flags;
        }

        // declare a variable called file and assign it to a new instantiation of a file object
        var file = new File();
        // access the members of the File object and use the Open() method to open a file named filePath
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