using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataAssetManager
{
    //Asset�� �ִ� SO ���� ���̺� �ν��Ͻ�
    UnitTable m_AssetUnitTable;
    ItemTable m_AssetItemTable;
    //������ �̸��� Key������ ���� �����ϴ� Dictionary
    Dictionary<string, UnitTable.UnitStats> m_UnitDic;
    Dictionary<string, ItemTable.ItemStats> m_ItemDic;

    //Init ���
    public void Init(UnitTable tableFromManager_Unit,ItemTable tableFromManager_Item)
    {
        m_AssetUnitTable = tableFromManager_Unit;
        m_AssetItemTable = tableFromManager_Item;
       m_UnitDic = new Dictionary<string, UnitTable.UnitStats>();
        m_ItemDic = new Dictionary<string, ItemTable.ItemStats>();
        if (m_AssetUnitTable == null)
        {
            Debug.LogError("You Missed DataTable in GameManager");
            return;
        }

        if (m_AssetItemTable == null)
        {
            Debug.LogError("You Missed DataTable in GameManager");
            return;
        }

        foreach (var Unit in m_AssetUnitTable.m_Units)
        {
            m_UnitDic.Add(Unit.m_sUnitName, Unit);
        }

        foreach (var Item in m_AssetItemTable.m_Items)
        {
            m_ItemDic.Add(Item.m_sItemName, Item);
        }

        Debug.Log("DataTable:" + m_AssetUnitTable.name + " Init Successful !,DataCount:" + m_UnitDic.Count);
    }
    //������ �����ϰ� �ҷ�����
    public bool GetUnitDataSafe(string className, out UnitTable.UnitStats foundUnitStat)
    {
        if (!m_UnitDic.ContainsKey(className))
        {
            Debug.LogError("There Is No :" + className + "In " + m_AssetUnitTable.name + " Table");
            foundUnitStat = new UnitTable.UnitStats();
            return false;
        }
        foundUnitStat = m_UnitDic[className];
        return true;
    }
    //������ �ҷ�����
    public UnitTable.UnitStats GetUnitData(string className)
    {
        return m_UnitDic[className];
    }
    public ItemTable.ItemStats GetItemData(string className)
    {
        return m_ItemDic[className];
    }
}
