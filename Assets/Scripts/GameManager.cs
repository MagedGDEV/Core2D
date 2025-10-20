using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text coinsText;
    public Image healthBar;
    public Image inventoryItemImage;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindAnyObjectByType<GameManager>();
            return instance;
        }
    }

    void Awake()
    {
        if (GameObject.Find("New Game Manager"))
            Destroy(gameObject);  
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.name = "New Game Manager";
    }

    void Update()
    {
        
    }
}
