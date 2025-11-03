using UnityEngine;

public class PlatformScroller : MonoBehaviour
{
    public float scrollSpeed = 0.1f;

    private Renderer platformRenderer;
    private PlayerJump playerJumpScript;

    private void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        playerJumpScript = GameObject.Find("Player").GetComponent<PlayerJump>();
    }

    private void Update()
    {
        if (!playerJumpScript.gameOver)
        {
            float offset = Time.time * scrollSpeed;
            platformRenderer.material.mainTextureOffset = new Vector2(-offset, 0);
        }
    }
}
