using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed = 5f;
    private int index;
    private int direction = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[index].position) < 0.1f)
        {
            if (index == points.Length - 1)
            {
                direction = -1;
            }
            else if (index == 0)
            {
                direction = 1;
            }

            index += direction;
        }

       

        transform.position = Vector2.MoveTowards(transform.position, points[index].position, moveSpeed * Time.deltaTime);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }






}



