using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    //플레이어는 사용자가 조작한다.
    //따라서 입력을 받아야 한다.
    //키보드, 마우스 등등 입력은 Input매니저가 담당한다.

    //이동속력
    //public => 인스펙트 창에 변수가 노출된다.
    //기본은 private => 인스펙트 창에 변수가 노출되지 않는다.
    public float speed = 12.0f;
    //public Rigidbody rigid;

    //Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        //tr = GetComponent<transfrom>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis 사용하는 이유?
        //멀티플랫폼 사용때문에 (윈도우, 안드로이드)
        //GetAxis => 1 ~ -1 사이의 값
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //이동처리
        //transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);

        //아래 방법도 가능 (덧셈일때는 크게 상관없지만 뺼셈을 써야 할 경우 아래 방법이 더좋음)
        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        //벡터의 정규화
        //dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);

        //중요
        //P = P0 + vt;
        //위치 = 현재위치 + (방향 * 시간)
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        //transform.position += dir * speed * Time.deltaTime;

        //플레이어를 화면밖으로 나가지 못하게 막기
        //1. 화면밖 공간에 큐브 4개를 만들어서 배치하면 충돌체 때문에 밖으로 벗어나지 못한다.
        // -리지드바디가 포함되어야 충돌처리가 가능함
        float xInput = h * speed + Time.deltaTime;
        float zInput = v * speed + Time.deltaTime;

       // rigid.velocity = new Vector3(xInput, 0f, zInput);
        //2. 플레이어 트랜스폼 포지션 x, y값을 고정시킨다
        transform.Translate(dir * speed * Time.deltaTime);
        //Vector3 position = transform.position;
        //if (position.x > 9.5f)
        //{
        //    position.x = 9.5f;
        //}
        //if (position.x < -9.5f)
        //{
        //    position.x = -9.5f;
        //}
        //if (position.z > 9.5f)
        //{
        //    position.z = 9.5f;
        //}
        //if (position.z < -9.5f)
        //{
        //    position.z = -9.5f;
        //}
        //transform.position = position;
        //3. 메인카메라의 뷰포트를 가져와서 처리한다.
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);



        if (pos.x < 0f) pos.x = 0f;

        if (pos.x > 1f) pos.x = 1f;

        if (pos.y < 0f) pos.y = 0f;

        if (pos.y > 1f) pos.y = 1f;



        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }
}
