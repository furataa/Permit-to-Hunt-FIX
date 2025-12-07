using UnityEngine;

public class ShopPopupAnim : MonoBehaviour
{
    public float speed = 10f;
    Vector3 targetScale;

    void OnEnable()
    {
        transform.localScale = Vector3.zero;
        targetScale = Vector3.one;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);
    }
}
