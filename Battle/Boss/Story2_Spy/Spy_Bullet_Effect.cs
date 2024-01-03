using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy_Bullet_Effect : MonoBehaviour
{
    public bool isRotate = false;
    public bool isTriggerBullet = false;
    // Update is called once per frame
    void Update()
    {
        if (isRotate)
        {
            transform.Rotate(Vector3.back * 100f * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent<Spy_Bullet_Effect>(out Spy_Bullet_Effect ef) && ef.isTriggerBullet == true)
        {
            other.GetComponent<Bullet>().DestroyBullet();
            var o = Instantiate(gameObject, transform.position, transform.rotation);

            //현재 속력을 유지한 채 45방향으로 굴절
            var rb = GetComponent<Rigidbody2D>();
            rb.velocity = Quaternion.Euler(0f, 0f, 90f) * rb.velocity;

            //현재 속력을 유지한 채 클론도 -45방향으로 굴절
            var rb2 = o.GetComponent<Rigidbody2D>();
            rb2.velocity = Quaternion.Euler(0f, 0f, -180f) * rb.velocity;
        }
    }
}
