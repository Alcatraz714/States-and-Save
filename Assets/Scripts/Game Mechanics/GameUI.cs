using UnityEngine;

public class GameUI : MonoBehaviour
{
    public void OnMovePlayer()
    {
        var pos = GameStateManager.Instance.gameState.player.position;
        GameStateManager.Instance.MovePlayer(pos + Vector2.right);
    }

    public void OnPickupItem() => GameStateManager.Instance.PickupItem("item_apple");
    public void OnUseItem() => GameStateManager.Instance.UseItem("item_apple");
    public void OnInteract() => GameStateManager.Instance.InteractWithEnvironment("door_main");

    public void OnSave() => SaveLoadService.SaveGame(GameStateManager.Instance.gameState);
    public void OnLoad()
    {
        var loaded = SaveLoadService.LoadGame();
        if (loaded != null) GameStateManager.Instance.gameState = loaded;
    }

    public void OnReset() => GameStateManager.Instance.ResetGame();
}
