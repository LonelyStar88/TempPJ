using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCastle : MonoBehaviour
{
    
    private float maxHP = 1000f;
    private float curHP = 0f;

  
   
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 1000f;
        curHP = maxHP;
        HP = 0;
    }

    void Update()
    {
         
    }
    //값을 넣고 빼는 형태로 적합한 케이스
    public float HP
    {
        get { return curHP; }
        set
        {
            if (curHP > 0)
            {
                curHP -= value;
                
            }
            else
            {
                curHP = 0;
            }
          
        }
    }

    public float MaxHP
    {
        get { return maxHP; }
        set
        {
            maxHP = value;
        }
    }
    public void Damage(float damage)
    {
        HP = damage;
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
