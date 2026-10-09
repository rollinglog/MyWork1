using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 20.0f;
    Vector3 bulletDirection = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void BulletSetDirection(Vector3 direction){ 
        bulletDirection = direction;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDirection * bulletSpeed ;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border") || collision.gameObject.CompareTag("Enemy")) {
            //Debug.Log('충돌 테스트');
            Destroy(gameObject); }
    }
}
