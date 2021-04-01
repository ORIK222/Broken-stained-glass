using UnityEngine;

public class Chip : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public void Init(Color color, Vector2 size)
    {
        _spriteRenderer.color = color;
        transform.localScale = size;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

}
