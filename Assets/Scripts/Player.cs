using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : PhysicsObject
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float jumpPower = 12;
    private Vector2 healthBarOrgSize;
    private int maxHealth = 100;
    public int health = 50;
    public int coinsCollected = 0;
    public Text coinsText;
    public Image healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBarOrgSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
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
        healthBar.rectTransform.sizeDelta = new Vector2(
            (float) health / maxHealth * healthBarOrgSize.x,
            healthBar.rectTransform.sizeDelta.y
        );
    }
}
