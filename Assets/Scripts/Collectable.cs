using Unity.VisualScripting;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            GameObject.Find("Player").GetComponent<Player>().coinsCollected++;
            GameObject.Find("Player").GetComponent<Player>().UpdateUI();
            Destroy(gameObject); // gameObject similar to this
        }
    }
}
