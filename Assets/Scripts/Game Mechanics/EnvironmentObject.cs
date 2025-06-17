using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    public string objectId;
    private SpriteRenderer sr;

    private void Awake() => sr = GetComponent<SpriteRenderer>();

    private void Update()
    {
        var env = GameStateManager.Instance?.gameState.environment.Find(e => e.id == objectId);
        if (env != null) sr.color = env.isActive ? Color.green : Color.red;
    }
}
