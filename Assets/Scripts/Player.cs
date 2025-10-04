using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            speed * Time.deltaTime,
            0,
            0
        );

        if (transform.position.x > 8.35)
        {
            transform.position = new Vector3(
                8.35f,
                transform.position.y,
                0
            );
        }
        else if (transform.position.x < -8.35)
        {
            transform.position = new Vector3(
                -8.35f,
                transform.position.y,
                0
            );
        }
        else if (transform.position.y > 4.5)
        {
            transform.position = new Vector3(
                transform.position.x,
                4.5f,
                0
            );
        }
        else if (transform.position.y < -4.5)
        {
            transform.position = new Vector3(
                transform.position.x,
                -4.5f,
                0
            );
        }
    }
}
