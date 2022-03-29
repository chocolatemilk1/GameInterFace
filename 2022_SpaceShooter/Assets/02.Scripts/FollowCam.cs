using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;    // Main Camera �ڽ��� Transform ������Ʈ

    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;   //���� ������κ��� ������ �Ÿ�

    [Range(0.0f, 10.0f)]
    public float height = 2.0f; //Y������ �̵��� ����

    public float damping = 10.0f;

    public float targetOffset = 2.0f;

    private Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        camTr = GetComponent<Transform>();  //Main Camera �ڽ��� Transform ������Ʈ ����
    }

    void LateUpdate()
    {
        //�����ؾ� �� ����� �������� distance��ŭ �̵�
        //���̸� height��ŭ �̵�
        Vector3 pos = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);

        camTr.position = Vector3.SmoothDamp(camTr.position, pos, ref velocity, damping);

        //Camera�� �ǹ� ��ǥ�� ���� ȸ��
        camTr.LookAt(targetTr.position + (targetTr.up * targetOffset));
    }
}
