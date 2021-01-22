using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 250);
    }

    public void KillOldBullet()
    {
        Destroy(gameObject, 2.0f);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //Debug.Log("test_buillet");
        Destroy(gameObject, 0.0f);
    }
}