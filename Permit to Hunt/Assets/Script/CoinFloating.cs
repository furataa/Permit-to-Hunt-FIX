using UnityEngine;

public class CoinFloating : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float lifeTime = 1.5f;

    void Update()
    {
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
