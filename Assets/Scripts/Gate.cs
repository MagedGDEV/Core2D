using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredInventoryItem;

    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && player.inventory.ContainsKey(requiredInventoryItem))
        {
            player.RemoveInventoryItem(requiredInventoryItem);
            Destroy(gameObject);   
        }
    }
}
