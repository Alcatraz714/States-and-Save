using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemId;

    private void Update()
    {
        var item = GameStateManager.Instance?.gameState.items.Find(i => i.id == itemId);
        gameObject.SetActive(item != null && !item.pickedUp);
    }
}
