using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public TextMeshProUGUI coinText;

    Vector3 originalScale;

    void Start()
    {
        originalScale = coinText.transform.localScale;

        // Register event
        playerStats.OnCoinChanged += UpdateCoinUI;
    }

    void UpdateCoinUI(int newCoins)
    {
        coinText.text = newCoins.ToString();
        StopAllCoroutines();
        StartCoroutine(PopAnimation());
    }

    System.Collections.IEnumerator PopAnimation()
    {
        // Besarin
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * 8f;
            coinText.transform.localScale = Vector3.Lerp(originalScale, originalScale * 1.3f, t);
            yield return null;
        }

        // Balikin ke normal
        t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * 8f;
            coinText.transform.localScale = Vector3.Lerp(originalScale * 1.3f, originalScale, t);
            yield return null;
        }

        coinText.transform.localScale = originalScale;
    }
}
