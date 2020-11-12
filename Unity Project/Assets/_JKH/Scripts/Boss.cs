using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject bossBullet;
    float count;
    float bossCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 0.5f)
        {
            count = 0;
            Fire();
        }
        bossCount += Time.deltaTime;
        if (bossCount > 2.0f)
        {
            bossCount = 0;
            BossFire();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void BossFire()
    {
        for (int i = 0; i < 36; i++)
        {
            Instantiate(bossBullet, transform.position, Quaternion.Euler(0, i * 10, 0));
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(enemyBullet);
        bullet.transform.position = transform.position;
    }
    
}
