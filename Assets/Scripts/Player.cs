using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : PhysicsObject
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float jumpPower = 12;

    private Vector2 healthBarOrgSize;
    private int maxHealth = 100;

    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    public int health = 50;
    public int coinsCollected = 0;
    public Text coinsText;
    public Image healthBar;
    public Image inventoryItemImage;
    public Sprite inventoryBlank;

    void Start()
    {
        healthBarOrgSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
    }

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
            (float)health / maxHealth * healthBarOrgSize.x,
            healthBar.rectTransform.sizeDelta.y
        );
    }

    public void AddInventoryItem(string name, Sprite image)
    {
        inventory.Add(name, image);
        inventoryItemImage.sprite = image;
    }
    
    public void RemoveInventoryItem(string name)
    {
        inventory.Remove(name);
        inventoryItemImage.sprite = inventoryBlank;
    }
}
