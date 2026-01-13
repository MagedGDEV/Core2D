using UnityEngine;

public class Enemy : PhysicsObject
{
    public int health = 100;
    [SerializeField] private float maxSpeed = 2;
    [SerializeField] private int direction = 1;
    [SerializeField] private int attackPower = 1;
    [SerializeField] private LayerMask rayCastLayerMask;
    [SerializeField] private RaycastHit2D rightLedgeRaycastHit;
    [SerializeField] private RaycastHit2D rightWallRaycastHit;
    [SerializeField] private RaycastHit2D leftLedgeRaycastHit;
    [SerializeField] private RaycastHit2D leftWallRaycastHit;
    [SerializeField] private Vector2 rayCastOffset = new Vector2(1, 0);
    [SerializeField] private float rayCastLength = 2;
    [SerializeField] private Animator animator;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float hurtSoundVolume = 1;
    [SerializeField] private float deathSoundVolume = 1;

    void Update()
    {
        targetVelocity = new Vector2(maxSpeed * direction, 0);

        //Check for right ledge!
        rightLedgeRaycastHit = Physics2D.Raycast(
            new Vector2(
                transform.position.x + rayCastOffset.x,
                transform.position.y + rayCastOffset.y
            ),
            Vector2.down,
            rayCastLength
        );
        Debug.DrawRay(
            new Vector2(
                transform.position.x + rayCastOffset.x,
                transform.position.y + rayCastOffset.y
            ), 
            Vector2.down * rayCastLength,
            Color.blue
        );
        if (rightLedgeRaycastHit.collider == null) 
            direction = -1;

        //Check for left ledge!
        leftLedgeRaycastHit = Physics2D.Raycast(
            new Vector2(
                transform.position.x - rayCastOffset.x, 
                transform.position.y + rayCastOffset.y
            ), 
            Vector2.down,
            rayCastLength
        );
        Debug.DrawRay(
            new Vector2(
                transform.position.x - rayCastOffset.x, 
                transform.position.y + rayCastOffset.y
            ), 
            Vector2.down * rayCastLength, 
            Color.green
        );
        if (leftLedgeRaycastHit.collider == null) 
            direction = 1;

        //Check for right wall!
        rightWallRaycastHit = Physics2D.Raycast(
            new Vector2(
                transform.position.x + 0.5f, 
                transform.position.y + rayCastOffset.y
            ), 
            Vector2.right, 
            rayCastLength, 
            rayCastLayerMask
        );
        Debug.DrawRay(
            new Vector2(
                transform.position.x + 0.3f, 
                transform.position.y + rayCastOffset.y
            ), 
            Vector2.right * rayCastLength, 
            Color.red
        );
        if (rightWallRaycastHit.collider != null) 
            direction = -1;

        //Check for left wall!
        leftWallRaycastHit = Physics2D.Raycast(
            new Vector2(
                transform.position.x - 0.5f, 
                transform.position.y + rayCastOffset.y
            ), 
            Vector2.left, 
            rayCastLength, 
            rayCastLayerMask
        );
        Debug.DrawRay(
            new Vector2(
                transform.position.x - 0.3f,
                transform.position.y + rayCastOffset.y
            ),
            Vector2.left * rayCastLength,
            Color.magenta
        );
        if (leftWallRaycastHit.collider != null) 
            direction = 1;

        if (health <= 0)
        {
            Player.Instance.sfxAudioSource.PlayOneShot(deathSound, deathSoundVolume);
            Destroy(gameObject); 
        }
    }

    public void Hurt()
    {
        animator.SetTrigger("hurt");
        Player.Instance.sfxAudioSource.PlayOneShot(hurtSound, hurtSoundVolume);
        health -= Player.Instance.attackPower;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.Hurt(attackPower);
        }
    }
}
