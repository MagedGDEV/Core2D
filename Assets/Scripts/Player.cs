using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : PhysicsObject
{
    [Header("Attributes")]
    [SerializeField] private float attackDuration = 0.1f;
    public int attackPower = 25;
    public int coinsCollected = 0;
    public int health = 50;
    [SerializeField] private float jumpPower = 12;
    private int maxHealth = 100;
    [SerializeField] private float speed = 4;

    [Header("References")]
    [SerializeField] private GameObject attackBox;
    private Vector2 healthBarOrgSize;
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    public Sprite inventoryBlank;
    [SerializeField] private Animator animator;
    
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
        Spawn();
        
        healthBarOrgSize = GameManager.Instance.healthBar.rectTransform.sizeDelta;
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
            animator.SetTrigger("attack");
            //StartCoroutine(Attack());
        }

        animator.SetFloat("velocityX", Math.Abs(velocity.x) / speed);
        animator.SetFloat("velocityY", velocity.y);
        animator.SetFloat("attackDirectionY", Input.GetAxis("Vertical"));
        animator.SetBool("grounded", grounded);

        if (health <= 0)
            Die();
    }

    public void Spawn()
    {
        gameObject.transform.position = GameObject.Find("Spawn Location").transform.position;
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
        health = 100;
    }

    public void UpdateUI()
    {
        GameManager.Instance.coinsText.text = coinsCollected.ToString();
        GameManager.Instance.healthBar.rectTransform.sizeDelta = new Vector2(
            (float)health / maxHealth * healthBarOrgSize.x,
            GameManager.Instance.healthBar.rectTransform.sizeDelta.y
        );
    }

    public void AddInventoryItem(string name, Sprite image)
    {
        inventory.Add(name, image);
        GameManager.Instance.inventoryItemImage.sprite = image;
    }
    
    public void RemoveInventoryItem(string name)
    {
        inventory.Remove(name);
        GameManager.Instance.inventoryItemImage.sprite = inventoryBlank;
    }
}
