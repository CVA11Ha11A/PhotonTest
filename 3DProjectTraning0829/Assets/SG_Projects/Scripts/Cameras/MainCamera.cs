using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;  // 플레이어 캐릭터의 Transform
    public float distance = 3f;  // 카메라와 캐릭터 사이의 거리
    public float height = 2.0f;  // 카메라의 높이
    public float smoothSpeed = 10.0f;  // 카메라 이동 스무딩 값wa

    private Vector3 offset;  // 초기 카메라와 캐릭터의 오프셋

    private void Start()
    {
        offset = new Vector3(0f, height, -distance);
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // 카메라 위치 업데이트
            Vector3 targetPosition = target.position + target.TransformDirection(offset);
            //targetPosition.y = targetPosition.y + height;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            // 카메라가 캐릭터를 바라보도록 회전
            transform.LookAt(target);
        }
        
    }

}
