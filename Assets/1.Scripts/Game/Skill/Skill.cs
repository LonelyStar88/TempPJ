using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SkillAtkData
{
    public int damage;
    public int atkCount;
    public float atkDelay;
    public float UseDelayTime;
}
public abstract class Skill : MonoBehaviour
{
    public SkillAtkData data = new SkillAtkData();
    public abstract void Init();

    public virtual void Attack(List<EnemyMonster> enemies)
    {
        if(data.atkCount != 0)
        {
            StartCoroutine(CoAttack(enemies)); //단순 문자열 호출이아닌, 인자값이 들어가는 코루틴 함수 사용시, 직접 딜레이를 넣어줘야한다.
        }
        else
        {
            foreach(var item in enemies)
            {
                item.Damage(data.damage);
            }
        }

    }

    IEnumerator CoAttack(List<EnemyMonster> enemies)
    {
        for(int i = 0; i < data.atkCount; i++)
        {
            foreach (var item in enemies)
            {
                item.Damage(data.damage);
            }
            yield return new WaitForSeconds(data.atkDelay);
        }
       
    }
       
}
