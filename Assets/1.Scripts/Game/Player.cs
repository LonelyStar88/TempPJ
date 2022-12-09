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
    private UnityEngine.UI.Image hpImage;

    [SerializeField]
    private Animator animator;
 
    // Start is called before the first frame update

    

    float Cooltime = 0f;
    float damage = 50f;

    bool isdamage;
    public bool isDie = false;
    public float curHP = 100;
    public float maxHP = 100;
    public float HP
    {
        get { return curHP; }
        set
        {
            curHP -= value;
            if (curHP <= 0)
            {
                Animation("Die");
                //Debug.Log("Game Over!");
                isDie = true;
                return;
            }
        }
    }
    public float MaxHP
    {
        set { curHP = maxHP = value; }
    }
    //float time = 0f;
    void Start()
    {
        hpImage = transform.GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Image>();
        MaxHP = maxHP;
        isdamage = false;
        isDie = false;
    }

    // Update is called once per frame
    void Update()
    {
        Cooltime += Time.deltaTime;
        
        // 카메라가 나를 따라오게 만듬
        Vector3 cameraPos = new Vector3(transform.position.x, cameraTrans.position.y, cameraTrans.position.z);
        cameraTrans.position = cameraPos;

        // 캐릭터 이동 범위 지정
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 3f;
        float clampX = Mathf.Clamp(transform.position.x + x, -35f, 35f);
        transform.position = new Vector3(clampX, 0f, 0f);

        // 캐릭터 이동에 따른 애니메이션 작업
        if(x == 0)
        {
            //멈춰있는 상태
            Animation("Idle");
        }
        else
        {
            if(true)
            {
                //이동
                Animation("Run");

                if(x > 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 90f, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, -90f, 0);
                }
            }
            else
            {
                /*
                //공격
                Animation("Attack");*/
            }
            
        }
        /*
        if(Input.GetKeyDown(KeyCode.F1))
        {
            float dis = Vector3.Distance(transform.position, Target.transform.position);
            if (dis < 12f)
            {
                if (Cooltime > 2f)
                {
                    Cooltime = 0f;
                    Animation("Attack");
                    isdamage = true;
                    StartCoroutine("Damage");
                }
            }
            else
            {
                Debug.Log("Too far!");
            }
        }*/
    }

    public void Animation(string aniName)
    {
        animator.SetTrigger(aniName);
    }
    IEnumerator Damage()
    {
        if (isdamage)
        {
            yield return new WaitForSeconds(2f);
            Target.GetComponent<EnemyCastle>().HP = damage;
            
        }
        isdamage = false;

    }
    public void Damage(float argDmg)
    {
        HP = argDmg;
        hpImage.fillAmount = HP / maxHP;
    }
}
