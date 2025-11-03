using UnityEngine;

public class PlatformScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Speed of the illusion
    private Renderer platformRenderer;

    private void Start()
    {
        platformRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Scroll the texture to the left over time
        float offset = Time.time * scrollSpeed;
        platformRenderer.material.mainTextureOffset = new Vector2(-offset, 0);
    }
}
