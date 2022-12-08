using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public override void Initialize()
    {
        data.damage = 100;
        data.name = "Sword";
    }
    public override void Attack()
    {
        base.Attack();
    }
}
