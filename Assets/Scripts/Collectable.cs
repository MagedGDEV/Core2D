using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum ItemType { Coin, Health, Ammo, Inventory }

    [SerializeField] private ItemType itemType;
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private string inventoryName;
    [SerializeField] private AudioClip collectableSound;
    [SerializeField] private float collectableSoundVolume = 1;
    [SerializeField] private ParticleSystem particleCollectableExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            if (collectableSound != null)
                Player.Instance.sfxAudioSource.PlayOneShot(collectableSound, collectableSoundVolume * Random.Range(0.8f, 1.4f));
            
            particleCollectableExplosion.transform.parent = null;
            particleCollectableExplosion.gameObject.SetActive(true);
            Destroy(particleCollectableExplosion.gameObject, particleCollectableExplosion.main.duration);

            switch (itemType)
            {
                case ItemType.Coin:
                    Player.Instance.coinsCollected++;
                    break;
                case ItemType.Health:
                    if (Player.Instance.health < 100)
                        Player.Instance.health+=5;
                    break;
                case ItemType.Inventory:
                    Player.Instance.AddInventoryItem(inventoryName, inventorySprite);
                    break;
            }
            Player.Instance.UpdateUI();
            Destroy(gameObject);
        }
    }
}
