using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : PhysicsObject
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float jumpPower = 12;
    public int coinsCollected = 0;
    public Text coinsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity.x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && grounded)
            velocity.y = jumpPower;
    }

    public void UpdateUI()
    {
        coinsText.text = coinsCollected.ToString();
    }
}
