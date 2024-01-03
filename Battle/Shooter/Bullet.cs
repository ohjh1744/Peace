using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float Damage = 1f;
    public float life_time = 5f;
    public GameObject CollisionEffect = null;
    public bool IsPenetration = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boarder")
        {
            IsPenetration = false;
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        if (CollisionEffect != null)
        {
            var obj = Instantiate(CollisionEffect, transform.position, transform.rotation);
            obj.transform.parent = null;
        }
        if (!IsPenetration)
        {
            if (gameObject != null) { Object.Destroy(gameObject); }
        }
    }


    private float t;
    private void OnEnable()
    {
        t = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - t > life_time)
        {
            DestroyBullet();
        }
    }

}
