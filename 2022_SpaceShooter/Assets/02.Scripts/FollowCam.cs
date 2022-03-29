using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;    // Main Camera 자신의 Transform 컴포넌트

    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;   //따라갈 대상으로부터 떨어질 거리

    [Range(0.0f, 10.0f)]
    public float height = 2.0f; //Y축으로 이동할 높이

    public float damping = 10.0f;

    public float targetOffset = 2.0f;

    private Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        camTr = GetComponent<Transform>();  //Main Camera 자신의 Transform 컴포넌트 추출
    }

    void LateUpdate()
    {
        //추적해야 할 대상의 뒤쪽으로 distance만큼 이동
        //높이를 height만큼 이동
        Vector3 pos = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);

        camTr.position = Vector3.SmoothDamp(camTr.position, pos, ref velocity, damping);

        //Camera를 피벗 좌표를 향해 회전
        camTr.LookAt(targetTr.position + (targetTr.up * targetOffset));
    }
}
