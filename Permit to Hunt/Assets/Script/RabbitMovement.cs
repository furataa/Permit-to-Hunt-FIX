using UnityEngine;
using System.Collections.Generic;

public class RabbitMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    public float jumpInterval = 2f;       // waktu antar lompatan
    public LayerMask obstacleLayer;       // layer pohon

    private Rigidbody rb;
    private Animator animator;
    private Vector3 targetPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        PickNewTarget();
        InvokeRepeating("PickNewTarget", 0, jumpInterval);
    }

    void PickNewTarget()
    {
        // ambil random direction di sekitar kelinci
        Vector3 randomDir = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        Vector3 pos = transform.position + randomDir;

        // raycast ke bawah untuk memastikan ada tanah
        if (Physics.Raycast(pos + Vector3.up * 5f, Vector3.down, out RaycastHit hit, 10f))
        {
            targetPos = hit.point;
        }
        else
        {
            targetPos = transform.position; // kalau gagal, tetap di tempat
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = targetPos - transform.position;
        direction.y = 0;

        if (direction.magnitude > 0.1f)
        {
            // cek obstacle di depan
            if (!Physics.Raycast(transform.position + Vector3.up * 0.5f, direction.normalized, 1f, obstacleLayer))
            {
                // gerak ke target
                Vector3 move = direction.normalized * moveSpeed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + move);

                // rotasi kelinci
                transform.rotation = Quaternion.LookRotation(direction);

                // animasi lompat
                if (animator) animator.SetBool("isJumping", true);
            }
            else
            {
                // obstacle di depan, pilih target baru
                PickNewTarget();
            }
        }
        else
        {
            // sampai target
            if (animator) animator.SetBool("isJumping", false);
        }
    }
}
