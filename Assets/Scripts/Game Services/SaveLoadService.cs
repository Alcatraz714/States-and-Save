using UnityEngine;
using System.IO;

public static class SaveLoadService
{
    private static string path => Path.Combine(Application.persistentDataPath, "gamestate.json");

    public static void SaveGame(GameState gameState)
    {
        var json = JsonUtility.ToJson(gameState, true);
        File.WriteAllText(path, json);
        Debug.Log("Game saved to: " + path);
    }

    public static GameState LoadGame()
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning("Save file not found");
            return new GameState();
        }

        var json = File.ReadAllText(path);
        try
        {
            return JsonUtility.FromJson<GameState>(json);
        }
        catch
        {
            Debug.LogWarning("Corrupted Save File");
            return new GameState();
        }
    }
}
