using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed=10.0f;
    
    public int playerHP = 20;
    [SerializeField]
    UnityEngine.UI.Slider playerHPSlider;
    [SerializeField]
    TMP_Text gameOverText;
    public BulletManager bulletManager;
    Vector3 moveDirection=Vector3.zero;
    [SerializeField]
    GameObject muzzle;
    void Start()
    {
        //playerRigid = GetComponent<Rigidbody2D>();
    }


    public void OnMove(InputAction.CallbackContext context)
    {

        moveDirection = context.ReadValue<Vector2>();
        if (moveDirection != Vector3.zero) muzzle.transform.localPosition = moveDirection;
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        if (bullets.Length<5)
        {
        Vector3 fireDirection = muzzle.transform.position - transform.position;
        bulletManager.Fire(muzzle.transform.position, fireDirection);

        }

    }
    

    // Update is called once per frame
    void Update()
    {
        if (playerHP<=0)
        {
            PlayerManager.Instance.isDead = true;
            gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
        }

        playerHPSlider.value = playerHP;

        if (moveDirection != Vector3.zero) muzzle.transform.localPosition = moveDirection.normalized*0.25f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        playerHPSlider.transform.rotation = Quaternion.identity;
        playerHPSlider.transform.position = gameObject.transform.position + new Vector3(0f,0.5f,0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHP--;
            
        }

    }
}
