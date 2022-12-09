using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillA : Skill
{
    public override void Init()
    {
        data.damage = 25;
        data.atkDelay = 0;
        data.atkCount = 0;
        data.UseDelayTime = 2f;
    }
    public override void Attack(List<EnemyMonster> enemies)
    {
        base.Attack(enemies);
    }
}
