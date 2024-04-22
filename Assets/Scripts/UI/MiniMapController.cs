using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    public Transform player; // �÷��̾� Transform
    public RectTransform mapRect; // ���� UI Rect Transform
    public RectTransform playerIcon; // �÷��̾� ������ UI Rect Transform

    // MapController�� ���ǵ� minPosition�� maxPosition ����
    public BoxCollider2D regionCollider; // ���� ������ �ڽ� �ݶ��̴�

    void Update()
    {
        if (regionCollider != null)
        {
            // ���� ������ �ڽ� �ݶ��̴��� �������� �÷��̾��� ��ġ�� ����
            Vector2 mapPosition = new Vector2(
                Mathf.Clamp(player.position.x, regionCollider.bounds.min.x, regionCollider.bounds.max.x),
                Mathf.Clamp(player.position.y, regionCollider.bounds.min.y, regionCollider.bounds.max.y)
            );

            // ���� ���� ��ǥ�� UI ������ ��ǥ�� ��ȯ
            Vector2 normalizedPosition = new Vector2(
                Mathf.InverseLerp(regionCollider.bounds.min.x, regionCollider.bounds.max.x, mapPosition.x),
                Mathf.InverseLerp(regionCollider.bounds.min.y, regionCollider.bounds.max.y, mapPosition.y)
            );

            // UI ������ ũ�⿡ �°� ��ȯ
            Vector2 mapRectSize = mapRect.rect.size;
            Vector2 mapPositionPixels = new Vector2(
                normalizedPosition.x * mapRectSize.x,
                normalizedPosition.y * mapRectSize.y
            );

            // UI ���� ������ �÷��̾� �������� ��ġ ����
            playerIcon.anchoredPosition = mapPositionPixels;
        }
    }
}
