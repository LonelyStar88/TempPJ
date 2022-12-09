using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillC : Skill
{
    public override void Init()
    {
        data.damage = 25;
        data.atkDelay = 0.5f;
        data.atkCount = 5;
        data.UseDelayTime = 8f;
    }
    public override void Attack(List<EnemyMonster> enemies)
    {
        base.Attack(enemies);
    }
}
