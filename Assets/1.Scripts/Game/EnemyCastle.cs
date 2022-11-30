using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCastle : MonoBehaviour
{
    
    private float maxHP = 1000f;
    private float curHP = 0f;

    [SerializeField]
    private TMP_Text HPTxt;
    [SerializeField]
    private Image HPImage;
    [SerializeField]
    private Transform canvas;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        HP = 0;
    }

    void Update()
    {
        canvas.LookAt(Camera.main.transform);  
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
            HPImage.fillAmount = curHP / maxHP;
            HPTxt.text = string.Format("{0}/{1}", curHP, maxHP);
        }
    }
}
