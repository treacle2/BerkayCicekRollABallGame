using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.freezeRotation = true; // Devrilmesin

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            player = playerObject.transform;
        else
            Debug.LogWarning("Player bulunamadı! Tag kontrol et.");
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;

        rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);

        // Oyuncuya doğru dön
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }
}