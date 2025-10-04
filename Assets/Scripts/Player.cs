using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int health = 20;
    [SerializeField] private float recoveryCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0
        ) * speed * Time.deltaTime;
        recoveryCounter += Time.deltaTime;

        if (transform.position.x > 8.35)
        {
            transform.position = new Vector3(
                8.35f,
                transform.position.y,
                0
            );
            Hurt();
        }
        else if (transform.position.x < -8.35)
        {
            transform.position = new Vector3(
                -8.35f,
                transform.position.y,
                0
            );
            Hurt();
        }
        else if (transform.position.y > 4.5)
        {
            transform.position = new Vector3(
                transform.position.x,
                4.5f,
                0
            );
            Hurt();
        }
        else if (transform.position.y < -4.5)
        {
            transform.position = new Vector3(
                transform.position.x,
                -4.5f,
                0
            );
            Hurt();
        }
    }

    void Hurt()
    {
        if (recoveryCounter > 2)
        {
            health -= 1;
            recoveryCounter = 0;
            Debug.Log("Health: " + health);
        }

    }
}
