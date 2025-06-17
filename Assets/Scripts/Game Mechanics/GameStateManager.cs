using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject itemApple;
    public static GameStateManager Instance { get; private set; }
    public GameState gameState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            ResetGame();
        }
        else Destroy(gameObject);
    }

    public void MovePlayer(Vector2 newPos)
    {
        float clampedX = Mathf.Clamp(newPos.x, -10f, 10f); // clamped values for x since we only move in x direction
        gameState.player.position = newPos;
    }

    public void PickupItem(string itemId)
    {
        var item = gameState.items.FirstOrDefault(i => i.id == itemId && !i.pickedUp);
        if (item == null) return;

        if (Vector2.Distance(item.position, gameState.player.position) <= 1.5f)
        {
            item.pickedUp = true;
            gameState.player.inventory.Add(itemId);
        }
    }

    public void UseItem(string itemId)
    {
        var player = gameState.player;
        if (!player.inventory.Contains(itemId)) return;

        if (itemId == "item_apple")
        {
            player.health = Mathf.Min(100, player.health + 10);
            player.health = Mathf.Clamp(player.health, 0, 100); // clamping health so that we dont exceed 100 or max hp
            GameObject.FindWithTag("Player")?.GetComponent<Player>()?.HealEffect();
        }

        player.inventory.Remove(itemId);
    }

    public void InteractWithEnvironment(string objectId)
    {
        var env = gameState.environment.FirstOrDefault(e => e.id == objectId);
        if (env == null) return;

        Vector2 playerPos = gameState.player.position;

        GameObject doorObj = GameObject.Find(objectId);
        if (doorObj == null)
        {
            Debug.LogWarning($"Environment object '{objectId}' not found in scene.");
            return;
        }

        Vector2 objectPos = doorObj.transform.position;

        if (Vector2.Distance(playerPos, objectPos) > 1.5f)
        {
            Debug.Log("Player too far to interact.");
            return;
        }

        env.isActive = !env.isActive;

        var sr = doorObj.GetComponent<SpriteRenderer>();
        //Moved the fucntion to object script itself no longer needed here
        //if (sr != null)
        //sr.color = env.isActive ? Color.blue : Color.red;

        Debug.Log($"Toggled {objectId} to {(env.isActive ? "active" : "inactive")}.");
    }

    public void ResetGame()
    {
        gameState = new GameState
        {
            player = new PlayerState
            {
                position = new Vector2(-4, 0),
                health = 100,
                inventory = new List<string>()
            },
            items = new List<ItemState>
            {
                new() { id = "item_apple", position = new Vector2(0, 1), pickedUp = false },
                new() { id = "item_key", position = new Vector2(5, 0), pickedUp = false }
            },
            environment = new List<EnvironmentState>
            {
                new() { id = "door_main", isActive = false }
            }
        };

        if (itemApple != null) itemApple.SetActive(true);
        Debug.Log("Game state has been reset.");
    }
}
