using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillB : Skill
{
    public override void Init()
    {
        data.damage = 25;
        data.atkDelay = 0.5f;
        data.atkCount = 1;
        data.UseDelayTime = 5f;
    }
    public override void Attack(List<EnemyMonster> enemies)
    {
        base.Attack(enemies);
    }
}
