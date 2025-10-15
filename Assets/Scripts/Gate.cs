using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredInventoryItem;

    private Player player;

    void Start()
    {
        player = Player.Instance;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject && player.inventory.ContainsKey(requiredInventoryItem))
        {
            player.RemoveInventoryItem(requiredInventoryItem);
            Destroy(gameObject);   
        }
    }
}
