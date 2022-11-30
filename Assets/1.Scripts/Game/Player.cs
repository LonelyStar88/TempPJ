using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    private Transform cameraTrans;
    [SerializeField]
    private Image PlayerHPimage;
    [SerializeField]
    private TMP_Text PlayerHPTxt;
    // Start is called before the first frame update

    float curHP = 0;
    float maxHP = 100;

    float Cooltime = 0f;
    float damage = 50f;
    //float time = 0f;
    void Start()
    {
        curHP = maxHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        Cooltime += Time.deltaTime;
        PlayerHPimage.fillAmount = curHP / maxHP;
        PlayerHPTxt.text = string.Format("{0}/{1}", curHP, maxHP);
        Vector3 cameraPos = new Vector3(transform.position.x, cameraTrans.position.y, cameraTrans.position.z);
        cameraTrans.position = cameraPos;
        float x = Input.GetAxisRaw("Horizontal");
        if(transform.position.x > -36f && transform.position.x < 36f)
        {
            transform.position += new Vector3(x, 0, 0) * Time.deltaTime * 5f;
        }
        else if(transform.position.x <= -36f)
        {
            transform.position = new Vector3(-35.9f, 1f,0);
        }
        else
        {
            transform.position = new Vector3(35.9f, 1f, 0);
        }

        if(Input.GetKeyDown(KeyCode.F1))
        {
            float dis = Vector3.Distance(transform.position, Target.transform.position);
            if (dis < 12f)
            {
                if (Cooltime > 10f)
                {
                    Cooltime = 0f;
                    Target.GetComponent<EnemyCastle>().HP = damage;
                }
            }
        }
    }
}
