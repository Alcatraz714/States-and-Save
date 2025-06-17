using UnityEngine;
using TMPro;

public class DebugPanelUI : MonoBehaviour
{
    public TMP_Text positionText;
    public TMP_Text healthText;
    public TMP_Text inventoryText;

    private void Update()
    {
        var player = GameStateManager.Instance?.gameState.player;
        if (player != null)
        {
            positionText.text = $"Position: {player.position}";
            healthText.text = $"Health: {player.health}";
            inventoryText.text = $"Inventory: {string.Join(", ", player.inventory)}";
        }
    }
}
