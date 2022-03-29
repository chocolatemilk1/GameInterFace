using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl: MonoBehaviour
{
    private Transform tr;

    private Animation anim;

    public float MoveSPD = 10f;
    public float turnSpeed = 80.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        anim.Play("Idle");
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        //Debug.Log("h= " + h);
        //Debug.Log("v= " + v);

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        
        tr.Translate(moveDir * MoveSPD * Time.deltaTime);

        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        //키보드 입력값을 기준으로 동작할 애니메이션 수행

        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.25f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.25f);
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);
        }
    }
}
