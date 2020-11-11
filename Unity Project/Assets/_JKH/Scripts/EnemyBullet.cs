using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject enemy;
    private GameObject player;
    public float speed = 10.0f;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dir = player.transform.position - transform.position;
        dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed *  Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
