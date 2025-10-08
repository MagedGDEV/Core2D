using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum ItemType { Coin, Health, Ammo, Inventory }
    [SerializeField] ItemType itemType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Triggered when collision detected with this game object
    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            player.GetComponent<Player>().coinsCollected++;
            Destroy(gameObject); // gameObject similar to this
        }
    }
}
