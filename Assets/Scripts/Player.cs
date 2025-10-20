using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : PhysicsObject
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float jumpPower = 12;
    [SerializeField] private float attackDuration = 0.1f;
    

    private Vector2 healthBarOrgSize;
    private int maxHealth = 100;

    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    public int health = 50;
    public int coinsCollected = 0;
    public int attackPower = 25;
    public Text coinsText;
    public Image healthBar;
    public Image inventoryItemImage;
    public Sprite inventoryBlank;
    [SerializeField] private GameObject attackBox;

    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
                instance = FindAnyObjectByType<Player>();
            return instance;
        }
    }

    void Awake()
    {

        if (GameObject.Find("New Player"))
            Destroy(gameObject);
            
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.name = "New Player";

        healthBarOrgSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
    }

    void Update()
    {
        targetVelocity.x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && grounded)
            velocity.y = jumpPower;


        if (targetVelocity.x > 0.01)
            transform.localScale = new Vector2(1, 1);
        else if (targetVelocity.x < -0.01)
            transform.localScale = new Vector2(-1, 1);

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }

        if (health <= 0)
            Die();
    }

    private IEnumerator Attack()
    {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackBox.SetActive(false);
    }

    private void Die()
    {
        SceneManager.LoadScene("Level1");
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
