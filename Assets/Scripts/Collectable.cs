using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum ItemType { Coin, Health, Ammo, Inventory }

    [SerializeField] private ItemType itemType;
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private string inventoryName;

    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            switch (itemType)
            {
                case ItemType.Coin:
                    player.coinsCollected++;
                    break;
                case ItemType.Health:
                    if (player.health < 100)
                        player.health+=5;
                    break;
                case ItemType.Inventory:
                    player.AddInventoryItem(inventoryName, inventorySprite);
                    break;
            }
            player.UpdateUI();
            Destroy(gameObject);
        }
    }
}
