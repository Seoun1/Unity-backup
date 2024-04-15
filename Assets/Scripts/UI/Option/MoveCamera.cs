using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform g_playerTransform; // �÷��̾��� Transform ������Ʈ�� ����Ű�� ����

    void Update()
    {
        if (g_playerTransform != null) // �÷��̾� Transform�� ��ȿ�� ��쿡�� ����
        {
            // ī�޶��� ��ġ�� �÷��̾��� ��ġ�� ����
            Vector3 newPosition = new Vector3(g_playerTransform.position.x, g_playerTransform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
