using UnityEngine;

public class Possessable : MonoBehaviour
{
    private bool isPossessed = false;
    private SpriteRenderer spriteRenderer;

    public Sprite normalSprite;
    public Sprite possessedSprite;

    public float fadeDuration = 1f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Possess()
    {
        if (!isPossessed)
        {
            isPossessed = true;
            GameManager.instance.AddPossession();

            if (possessedSprite != null)
                spriteRenderer.sprite = possessedSprite;

            StartCoroutine(FadeOut());
        }
    }

    private System.Collections.IEnumerator FadeOut()
    {
        float elapsed = 0f;
        Color startColor = spriteRenderer.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
          gameObject.SetActive(false);
    }
}