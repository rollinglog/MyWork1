using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerObj;
    [SerializeField]
    EnemyManager enemyManager;
    public bool isDead = false;
    [SerializeField]
    Player player;
    [SerializeField]
    TMP_Text gameOverText;
    //ΩÃ±€≈Ê ∆–≈œ
    private static  PlayerManager S_instance = null;
    public static PlayerManager Instance
    {
        get
        {
            if (S_instance == null)
            {
                S_instance = FindObjectOfType(typeof(PlayerManager)) as PlayerManager;
            }
            return S_instance;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame==true)
        {
            Restart();
        }
    }
    public void Restart()
    {
        if (isDead==true)
        {
            player.playerHP = 20;
            isDead = false;
            playerObj.gameObject.SetActive(true);
            playerObj.transform.position = Vector3.zero;
            gameOverText.gameObject.SetActive(false);
            enemyManager.SpawnEnemies();
        }
    }
}
