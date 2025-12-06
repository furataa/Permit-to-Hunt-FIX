using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    public GameObject rabbitPrefab;
    public Mesh groundMesh;
    public int rabbitCount = 5;

    void Start()
    {
        SpawnRabbits();
    }

    void SpawnRabbits()
    {
        for (int i = 0; i < rabbitCount; i++)
        {
            Vector3 pos = RandomPointOnMesh(groundMesh);
            Instantiate(rabbitPrefab, pos, Quaternion.identity);
        }
    }

    Vector3 RandomPointOnMesh(Mesh mesh)
    {
        Bounds b = mesh.bounds;
        return new Vector3(
            Random.Range(b.min.x, b.max.x),
            5,
            Random.Range(b.min.z, b.max.z)
        );
    }
}
