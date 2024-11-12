using Godot;
using System.Collections.Generic;

public class GameStateFlags: Node
{
    // Instantiate Dictionaries for Game State Flags set to Null
    private Dictionary<string, bool> worldFlags; // Just declare the variable but do not assign a value by removing the right side of the logic
    private Dictionary<string, bool> levelProgressionFlags;
    private Dictionary<string, bool> cityTitanFlags; 
    private Dictionary<string, bool> cityNileFlags; 
    private Dictionary<string, bool> cityCaesarFlags; 


    // Declare Path to JSON
    private string worldFlagsPath = "res://Scripts/Main/GameDatabase/GameFlags/WorldFlags.json";
    private string levelProgressionFlagsPath = "res://Scripts/Main?GameDatabase/GameFlags/LevelProgressionFlags.json";
    private string cityTitanFlagsPath = "res://Scripts/Main/GameDatabase/GameFlags/CityTitanFlags.json";
    private string cityNileFlagsPath = "res://Scripts/Main/GameDatabase/GameFlags/CityNileFlags.json";
    private string cityCaesarFlagsPath = "res://Scripts/Main/GameDatabase/GameFlags/CityCaesarFlags.json";


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
        // Declare a variable named 'flags' and assign it an empty dictionary
        var flags = new Dictionary<string, bool>();

        // Create a new file object to interact with the file system
        var file = new File();
        Error err = file.Open(filePath, File.ModeFlags.Read);

        // Check if there was an error opening the file
        if (err != Error.Ok)
            {
                GD.PrintErr($"File not found or could not be opened: {filePath}");
                return flags; // Return an empty dictionary if the file could not be opened
            }

            // If file was opened successfully, read its contents as a string
            var jsonContent = file.GetAsText();
            // Close the file after reading to free resources
            file.Close();

            // Parse the JSON content into a Godot JSON result
            var jsonResult = JSON.Parse(jsonContent);
            if (jsonResult.Error != Error.Ok)
            {
                GD.PrintErr($"Error parsing JSON from {filePath}: {jsonResult.ErrorString}");
                return flags; // Return an empty dictionary if parsing failed
            }

            // Cast the result to a Godot dictionary
            var jsonDict = jsonResult.Result as Godot.Collections.Dictionary;
            if (jsonDict != null)
            {
                // Iterate through the keys in the dictionary and populate 'flags'
                foreach (var key in jsonDict.Keys)
                {
                    flags[key.ToString()] = (bool)jsonDict[key];
                }
            }

            // Return the populated 'flags' dictionary
            return flags;
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