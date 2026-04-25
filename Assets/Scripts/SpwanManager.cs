using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2f);

    }

    void Spawn()
    {
        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
    }

}
