using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject enemyBullet;
    float count;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        count += Time.deltaTime;
        if (count > 0.5f)
        {
            count = 0;
            Fire();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void Fire()
    {
        GameObject bullet = Instantiate(enemyBullet);
        bullet.transform.position = transform.position;
    }
}
