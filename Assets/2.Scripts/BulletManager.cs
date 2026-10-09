using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefeb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += bulletDirection * bulletSpeed * Time.deltaTime;
    }
    public void Fire(Vector3 startPos, Vector3 direction) {
        GameObject bullet= Instantiate(bulletPrefeb,startPos,Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.BulletSetDirection(direction);
    }
}
