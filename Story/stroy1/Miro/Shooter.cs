using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // "Bullet" 프리팹을 할당할 변수
    public GameObject bullet;
    private float bulletSpeed = 10f; // 총알의 속도

    private float shootTimer = 0f;   // 발사 타이머
    private float shootInterval = 2f; // 발사 간격

    void Start()
    {   
        bulletPrefab = Resources.Load<GameObject>("Prefabs/bullet");
        
        if (bulletPrefab == null)
        {
            Debug.LogError("프리팹을 찾을 수 없습니다. Resources 폴더에 'MyPrefab'이 존재해야 합니다.");
        }
        // "Bullet" 프리팹을 인스턴스화하여 총알 생성
        bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.SetActive(false);
    }

    void Update()
    {
        // 타이머 업데이트
        shootTimer += Time.deltaTime;

        // 발사 간격마다 총알 발사
        if (shootTimer >= shootInterval)
        {
            ShootBullet();
            shootTimer = 0f;  // 타이머 초기화
        }
    }

    void ShootBullet()
    {
        //활성화
        bullet.SetActive(true);
        // 총알에 속도를 줌
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.up * bulletSpeed;
    }
}
