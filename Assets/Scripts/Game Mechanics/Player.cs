using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Awake() => sr = GetComponent<SpriteRenderer>();

    private void Update()
    {
        if (GameStateManager.Instance?.gameState?.player != null)
        {
            transform.position = GameStateManager.Instance.gameState.player.position;
        }
    }

    public void HealEffect()
    {
        StartCoroutine(FlashGreen());
    }

    IEnumerator FlashGreen()
    {
        sr.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}
