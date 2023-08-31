using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;  // �÷��̾� ĳ������ Transform
    public float distance = 3f;  // ī�޶�� ĳ���� ������ �Ÿ�
    public float height = 2.0f;  // ī�޶��� ����
    public float smoothSpeed = 10.0f;  // ī�޶� �̵� ������ ��wa

    private Vector3 offset;  // �ʱ� ī�޶�� ĳ������ ������

    private void Start()
    {
        offset = new Vector3(0f, height, -distance);
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // ī�޶� ��ġ ������Ʈ
            Vector3 targetPosition = target.position + target.TransformDirection(offset);
            //targetPosition.y = targetPosition.y + height;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            // ī�޶� ĳ���͸� �ٶ󺸵��� ȸ��
            transform.LookAt(target);
        }
        
    }

}
