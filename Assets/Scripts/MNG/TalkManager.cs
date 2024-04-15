using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ȭ �� ĳ���� �ʻ�ȭ�� �����ϴ� ��ũ��Ʈ
public class TalkManager : MonoBehaviour
{
    // ��ȭ �����͸� ������ ��ųʸ�
    Dictionary<int, string[]> talkData;
    // ĳ���� �ʻ�ȭ�� ������ ��ųʸ�
    Dictionary<int, Sprite> portraitData;

    // �ʻ�ȭ ��������Ʈ �迭
    public Sprite[] portraitArr;

    // �ʱ�ȭ �Լ�
    void Awake()
    {
        // ��ųʸ����� �ʱ�ȭ
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        // ������ ���� �Լ� ȣ��
        GenerateData();
    }

    // ��ȭ �� �ʻ�ȭ ������ ���� �Լ�
    void GenerateData()
    {
        // ��ȭ ������ �߰�
        talkData.Add(1000, new string[] { "�ȳ�!:0", "������ �ݰ���!:0" });
        talkData.Add(2000, new string[] { "���!:0", "������ �ݰ���!:0" });

        // ������ ��ȭ ������ �߰�
        talkData.Add(200, new string[] { "������1 �̴�." });
        talkData.Add(300, new string[] { "������2 �̴�." });

        // �ʻ�ȭ ������ �߰�
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 0, portraitArr[1]);
    }

    // ������ ��ȭ ID�� ��ȭ �ε����� �ش��ϴ� ��ȭ ��ȯ
    public string GetTalk(int id, int talkIndex)
    {
        // ��ȭ �ε����� ��ȭ ������ ���̿� ������ null ��ȯ
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        // �׷��� ������ �ش� ��ȭ ��ȯ
        else
        {
            return talkData[id][talkIndex];
        }
    }

    // ������ ID�� �ʻ�ȭ �ε����� �ش��ϴ� �ʻ�ȭ ��ȯ
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        // ID�� �ε����� ����Ͽ� �ʻ�ȭ ��ȯ
        return portraitData[id + portraitIndex];
    }
}
