using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject[] treePrefabs;       
    public MeshCollider groundCollider;    
    public Transform player;               
    public float minPlayerDistance = 10f;  

    public int treeCount = 200;            
    public Vector2 scaleRange = new Vector2(0.9f, 1.2f); 

    void Start()
    {
        Bounds bounds = groundCollider.GetComponent<MeshRenderer>().bounds;

        for (int i = 0; i < treeCount; i++)
        {
            SpawnTree(bounds);
        }
    }

    void SpawnTree(Bounds bounds)
    {
        for (int attempt = 0; attempt < 50; attempt++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                50f,
                Random.Range(bounds.min.z, bounds.max.z)
            );

            // jangan terlalu dekat player
            if (Vector3.Distance(randomPos, player.position) < minPlayerDistance)
                continue;

            // raycast ke tanah
            if (Physics.Raycast(randomPos, Vector3.down, out RaycastHit hit, 200f))
            {
                if (hit.collider == groundCollider)
                {
                    int index = Random.Range(0, treePrefabs.Length);
                    GameObject tree = Instantiate(treePrefabs[index], hit.point, Quaternion.identity);

                    // rotasi mengikuti normal tanah + random Y
                    tree.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    tree.transform.Rotate(0f, Random.Range(0f, 360f), 0f, Space.Self);

                    // scale random
                    float s = Random.Range(scaleRange.x, scaleRange.y);
                    tree.transform.localScale *= s;

                    return;
                }
            }
        }
    }
}
