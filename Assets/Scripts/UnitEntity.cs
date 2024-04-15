using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEntity : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer { get; set; }

    public string m_sUnitName;
    public int m_iUnitHP;
    public int m_iUnitAtk;
    public int m_iUnitDef;
    public int m_iUnitSpeed;
    public int m_iCurrentHP;
    public int m_iUnitLevel;
    public Sprite m_spriteUnitImage;
    public GameManager.Type UnitType;
    

    //�ε����� �����ϴ°� ���ҰŰ��Ƽ� ��������ϴ�
    public IAttackBehavior[] m_AttackBehaviors;

   
    //GameManager�� �ִ� UnitTable SO�� �ִ� ������ ������� �ش� ���ӿ�����Ʈ �ʱ�ȭ
    public void SetUnit(string className)
    {
        var UnitData = GameManager.Instance.GetUnitData(className);

        //�̸��� key������ �޾ƿ� value�� unitdata�� unitentity �ʱ�ȭ

        m_sUnitName = UnitData.m_sUnitName;
        gameObject.name += "-" + m_sUnitName;

        m_iUnitLevel = UnitData.m_iUnitLevel;

        //������ ���� ü��/���ݷ�/������ �⺻ + (������ɷ�ġ * ����)�Դϴ�.
        m_iUnitHP = UnitData.m_iUnitHP + (UnitData.m_iLvlModHP * m_iUnitLevel);
        m_iUnitAtk = UnitData.m_iUnitAtk + (UnitData.m_iLvlModAtk * m_iUnitLevel);
        m_iUnitDef = UnitData.m_iUnitDef + (UnitData.m_iLvlModDef * m_iUnitLevel);
        m_iUnitSpeed = UnitData.m_iUnitSpeed + (UnitData.m_iLvlModSpeed * m_iUnitLevel);
        UnitType = UnitData.UnitType;
        m_iCurrentHP = m_iUnitHP;


        //��������Ʈ ����
        //m_SpriteRenderer = GetComponent<SpriteRenderer>();
       // m_SpriteRenderer.sprite = UnitData.m_UnitSprite;
        m_spriteUnitImage = UnitData.m_UnitSprite;
        m_AttackBehaviors = new IAttackBehavior[3];

        //�ε����� �����ϴ°� ���ҰŰ��Ƽ� ��������ϴ�
        m_AttackBehaviors[0] = Instantiate(UnitData.m_AttackBehav_1);
        m_AttackBehaviors[1] = Instantiate(UnitData.m_AttackBehav_2);
        m_AttackBehaviors[2] = Instantiate(UnitData.m_AttackBehav_3);
    }

    //�ε����� �����ϴ°� ���ҰŰ��Ƽ� ��������ϴ�
    public void AttackByIndex(UnitEntity Atker, UnitEntity Defender,int index)
    {
        m_AttackBehaviors[index].ExecuteAttack(Atker, Defender);
    }
    public string GetSkillname(UnitEntity UnitEntity,int index)
    {
        return UnitEntity.m_AttackBehaviors[index].GetSkillName();
    }

    // ü���� ȸ���ϴ� �޼���
    public void Heal(int amount)
    {
        // ȸ������ ���� ü�¿� ����
        m_iCurrentHP += amount;

        // ���� ���� ü���� �ִ� ü���� �ʰ��ϸ�
        if (m_iCurrentHP > m_iUnitHP)
            // ���� ü���� �ִ� ü������ ����
            m_iCurrentHP = m_iUnitHP;
    }

}
