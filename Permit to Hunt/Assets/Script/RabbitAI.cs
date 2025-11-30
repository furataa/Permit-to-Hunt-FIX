using UnityEngine;

public class RabbitAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float turnSpeed = 120f;
    public float obstacleCheckDistance = 1f;
    public LayerMask obstacleLayer;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Mainkan animasi lompat (loop)
        anim.Play("Jump", 0);

        // Cek apakah ada obstacle (pohon) di depan
        if (Physics.Raycast(transform.position + Vector3.up * 0.3f, transform.forward, obstacleCheckDistance, obstacleLayer))
        {
            // Putar ke kanan secara perlahan
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        else
        {
            // Bergerak maju
            controller.Move(transform.forward * moveSpeed * Time.deltaTime);
        }
    }
}
