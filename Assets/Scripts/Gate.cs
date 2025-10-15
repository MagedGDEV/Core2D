using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredInventoryItem;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            player.RemoveInventoryItem(requiredInventoryItem);
        
        Destroy(gameObject);
    }
}
