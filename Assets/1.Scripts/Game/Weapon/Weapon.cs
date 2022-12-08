using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WeaponData
{
    public int damage;
    public string name;
}
public abstract class Weapon : MonoBehaviour
{
    public WeaponData data = new WeaponData();
    public abstract void Initialize();

    public virtual void Attack()
    {
        Debug.Log($"{data.name} : {data.damage} ");
    }
}
