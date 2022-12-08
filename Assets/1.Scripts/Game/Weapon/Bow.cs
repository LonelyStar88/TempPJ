using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{
    public override void Initialize()
    {
        data.damage = 8;
        data.name = "Bow";
    }
    public override void Attack()
    {
        base.Attack();
    }
}
