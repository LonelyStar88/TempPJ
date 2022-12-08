using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon
{
    public override void Initialize()
    {
        data.damage = 5;
        data.name = "Staff";
    }
    public override void Attack()
    {
        base.Attack();
    }
}
