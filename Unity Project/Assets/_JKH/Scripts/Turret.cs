using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 공장(프리팹)
    public GameObject firePoint;        //총알 발사위치

    float count;

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 1)
        {
            count = 0;
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = firePoint.transform.position;
    }
}
