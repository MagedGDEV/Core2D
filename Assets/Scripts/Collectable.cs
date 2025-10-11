using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum ItemType { Coin, Health, Ammo, Inventory }
    [SerializeField] private ItemType itemType;
    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Triggered when collision detected with this game object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (itemType == ItemType.Coin)
                player.coinsCollected++;
            else if (itemType == ItemType.Health)
            {
                if (player.health < 100)
                    player.health+=5;
            }

            player.UpdateUI();
            Destroy(gameObject); // gameObject similar to this
        }
    }
}
