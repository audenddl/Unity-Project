using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;

    float count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 3)
        {
            count = 0;
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(enemy);
        bullet.transform.position = new Vector3(Random.Range(-4, 4), transform.position.y, transform.position.z);
    }
}
