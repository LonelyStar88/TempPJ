using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster : MonoBehaviour
{
    private GameObject targetCastle;
    private GameObject target;

    [SerializeField]
    private Animator animator;

    private float delayTime = 0f;

    private float damage = 1f;

    public float curHP = 0;
    public float maxHP = 100;
    public float HP
    {
        get { return curHP; }
        set
        {
            curHP -= value;
            if (curHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public float MaxHP
    {
        set { curHP = maxHP = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        targetCastle = GameObject.FindGameObjectWithTag("MyCastle");
    }

    // Update is called once per frame
    void Update()
    {
        delayTime += Time.deltaTime;
        // ���� ����� �� ã��
        FindEnemy();
    }
    void FindEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("My");
        if (objs.Length != 0)
        {
            //���� ã�´�.
            float dis = 0;
            float findIdx = -1;
            GameObject target = null;
            for (int i = 0; i < objs.Length; i++)
            {
                // ���� ����� ���� ã�´�.
                float distance = Vector3.Distance(transform.position, objs[i].transform.position);
                if (dis == 0 || dis > distance)
                {
                    dis = distance;
                    findIdx = i;
                    target = objs[i];
                }

            }
            if (findIdx == -1)
            {
                return;
            }
            if (target != null)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);

                if (distance < 10)
                {
                    //����
                }
                else
                {
                    //�̵�
                    Animation("Walk");
                    transform.position += Vector3.left * Time.deltaTime * 3f;
                }
            }
        }
        else
        {
            float dis = Vector3.Distance(transform.position, targetCastle.transform.position);

            if (dis < 10)
            {
                if (delayTime > 1f)
                {
                    delayTime = 0;
                    AttackCastle();
                    // ����
                    Animation("Attack");

                }
            }
            else
            {
                // �̵�
                Animation("Walk");
                transform.position += Vector3.left * Time.deltaTime * 3f;
            }
        }

       
    }
    void Animation(string aniName)
    {
        animator.SetTrigger(aniName);
    }
    void AttackCastle()
    {
        targetCastle.GetComponent<MyCastle>().HP = damage;
    }
    void Attack()
    {

    }
    public void Damage(float argDmg)
    {
        HP = argDmg;
    }
}
