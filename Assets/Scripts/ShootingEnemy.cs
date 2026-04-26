using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; 


    private float timer;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      

        float distance = Vector2.Distance(transform.position, player.transform.position);


        if (distance <= 5f) // Check if player is within 5 units
        {
            timer += Time.deltaTime;

            if (timer >= 2f) // Fire every 2 seconds
            {
                timer = 0f; // Reset the timer
                Shoot();
            }

        }

        

    }

    void Shoot()
            {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }



}
