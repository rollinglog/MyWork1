using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float enemyMoveSpeed = 4.0f;
    int curEnemyHP = 5;
    [SerializeField]
    Slider hpSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject player;
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (curEnemyHP <= 0) Destroy(gameObject);
        if (PlayerManager.Instance.isDead==true) Destroy(gameObject);

        Vector3 enemyDirection= player.transform.position - transform.position;
        transform.position += enemyDirection.normalized*enemyMoveSpeed*Time.deltaTime;

        hpSlider.transform.rotation = Quaternion.identity;
        hpSlider.transform.position =gameObject.transform.position+ new Vector3(0f, 0.5f, 0f);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")==true)
        {
            curEnemyHP--;
            hpSlider.value = curEnemyHP;
        }
        
    }
}
