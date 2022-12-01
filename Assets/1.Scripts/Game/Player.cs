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
    private Animator animator;
 
    // Start is called before the first frame update

    float curHP = 0;
    float maxHP = 100;

    float Cooltime = 0f;
    float damage = 50f;

    bool isdamaged;
    //float time = 0f;
    void Start()
    {
        curHP = maxHP;
        isdamaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        Cooltime += Time.deltaTime;
        
        // ī�޶� ���� ������� ����
        Vector3 cameraPos = new Vector3(transform.position.x, cameraTrans.position.y, cameraTrans.position.z);
        cameraTrans.position = cameraPos;

        // ĳ���� �̵� ���� ����
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 3f;
        float clampX = Mathf.Clamp(transform.position.x + x, -35f, 35f);
        transform.position = new Vector3(clampX, 0f, 0f);

        // ĳ���� �̵��� ���� �ִϸ��̼� �۾�
        if(x == 0)
        {
            //�����ִ� ����
            Animation("Idle");
        }
        else
        {
            if(true)
            {
                //�̵�
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
                //����
                Animation("Attack");*/
            }
            
        }

        if(Input.GetKeyDown(KeyCode.F1))
        {
            float dis = Vector3.Distance(transform.position, Target.transform.position);
            if (dis < 12f)
            {
                if (Cooltime > 2f)
                {
                    Cooltime = 0f;
                    Animation("Attack");
                    isdamaged = true;
                    StartCoroutine("Damaged");
                }
            }
            else
            {
                Debug.Log("Too far!");
            }
        }
    }

    public void Animation(string aniName)
    {
        animator.SetTrigger(aniName);
    }
    IEnumerator Damaged()
    {
        if (isdamaged)
        {
            yield return new WaitForSeconds(2f);
            Target.GetComponent<EnemyCastle>().HP = damage;
            
        }
        isdamaged = false;

    }
}
