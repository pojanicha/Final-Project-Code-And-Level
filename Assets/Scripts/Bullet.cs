using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;  
    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            // หายตัวไปเลยกัน error
            Destroy(gameObject);
            return;
        }

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f) // Destroy the bullet after 10 seconds
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Handle player hit logic here (e.g., reduce health)
            Destroy(gameObject); // Destroy the bullet on impact
        }
     
    }
}




