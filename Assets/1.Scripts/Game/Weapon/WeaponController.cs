using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        weapon.Attack();
    }
}
