using UnityEngine;

public class Enemy : PhysicsObject
{
    [SerializeField] private float speed = 2;
    [SerializeField] private int direction = 1;
    [SerializeField] private int attackPower = 1;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private RaycastHit2D rightLedgeRay;
    [SerializeField] private RaycastHit2D rightWallRay;
    [SerializeField] private RaycastHit2D leftLedgeRay;
    [SerializeField] private RaycastHit2D leftWallRay;
    [SerializeField] private Vector2 rayCastOffset = new Vector2(1, 0);
    [SerializeField] private int ledgeDistance = 1;

    void Start()
    {

    }

    void Update()
    {
        targetVelocity.x = direction * speed;
        if (direction == 1)
        {
            rightLedgeRay = Physics2D.Raycast(
                new Vector2(
                    transform.position.x + rayCastOffset.x,
                    transform.position.y
                ),
                Vector2.down,
                ledgeDistance
            );
            Debug.DrawRay(
                new Vector2(
                    transform.position.x + rayCastOffset.x,
                    transform.position.y
                ),
                Vector2.down * ledgeDistance,
                Color.red
            );
            rightWallRay = Physics2D.Raycast(
                new Vector2(
                    transform.position.x,
                    transform.position.y
                ),
                Vector2.right,
                ledgeDistance,
                raycastLayerMask
            );
            Debug.DrawRay(
                new Vector2(
                    transform.position.x,
                    transform.position.y
                ),
                Vector2.right * ledgeDistance,
                Color.yellow
            );
            if (rightLedgeRay.collider == null || rightWallRay.collider != null)
                direction = -1;
        }
        else
        {
            leftLedgeRay = Physics2D.Raycast(
                new Vector2(
                    transform.position.x - rayCastOffset.x,
                    transform.position.y
                ),
                Vector2.down,
                ledgeDistance
            );
            Debug.DrawRay(
                new Vector2(
                    transform.position.x - rayCastOffset.x,
                    transform.position.y
                ),
                Vector2.down * ledgeDistance,
                Color.red
            );
            leftWallRay = Physics2D.Raycast(
                new Vector2(
                    transform.position.x,
                    transform.position.y
                ),
                Vector2.left,
                ledgeDistance,
                raycastLayerMask
            );
            Debug.DrawRay(
                new Vector2(
                    transform.position.x,
                    transform.position.y
                ),
                Vector2.left * ledgeDistance,
                Color.yellow
            );
            if (leftLedgeRay.collider == null || leftWallRay.collider != null)
                direction = 1;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.health -= attackPower;
            Player.Instance.UpdateUI();
        }
    }
}
