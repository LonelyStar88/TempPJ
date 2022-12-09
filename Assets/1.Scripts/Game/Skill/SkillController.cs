using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public Skill[] skills;
    private Skill skill;
    //�ӽ� ����
    public BoxCollider Boxcol;

    private List<EnemyMonster> enemies = new List<EnemyMonster>();

    void Start()
    {
        Boxcol.enabled = false;  
    }
    public void Use()
    {
        //��ų �ʱ�ȭ
        skill.Init();

        //��ų ���
        skill.Attack(enemies);

        //���� ���ʹ� ����
        enemies.Clear();
        StartCoroutine("BoxColOff");
    }

    IEnumerator BoxColOff()
    {
        yield return new WaitForSeconds(0.5f);
        Boxcol.enabled = false;
    }

    

    public void OnUseSkill(int index)
    {
        Boxcol.enabled = true;
        skill = skills[index];
        Invoke("DelaySkillUse", 0.5f);
    }

    void DelaySkillUse()
    {
        Use();
    }
   
    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.CompareTag("enemy"))
        {
            Debug.Log("Add");
            enemies.Add(other.GetComponent<EnemyMonster>());
        }
        
    }
}
