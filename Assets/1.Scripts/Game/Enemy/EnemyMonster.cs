using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster : MonoBehaviour
{
    private GameObject targetCastle;
    private GameObject target;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private UnityEngine.UI.Image hpImage;

    private float delayTime = 0f;
    float attackTime = 0f;
    private float damage = 0;
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
                Destroy(gameObject);
            }
        }
    }
    public float MaxHP
    {
        set { curHP = maxHP = value; }
    }

    DataPawn.EnemyPawnData data = new DataPawn.EnemyPawnData();

    public void Initialized(DataPawn.EnemyPawnData argData)
    {
        data.damage = argData.damage;
        data.delaytime = argData.delaytime;
        data.hp = argData.hp;
        data.attackdelaytime = argData.attackdelaytime;

        MaxHP = data.hp;
        damage = data.damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        hpImage = transform.GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Image>();
        targetCastle = GameObject.FindGameObjectWithTag("MyCastle");
    }

    // Update is called once per frame
    void Update()
    {
        delayTime += Time.deltaTime;

        
        // 가장 가까운 적 찾기
        FindEnemy();

        
    }
    void FindEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("My");
        if (objs.Length != 0)
        {
            //적을 찾는다.
            float dis = 0;
            float findIdx = -1;
            GameObject target = null;
            for (int i = 0; i < objs.Length; i++)
            {
                // 나와 가까운 적을 찾는다.
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
                    //공격
                    Attack(target);

                    Animation("Attack");
                }
                else
                {
                    //이동
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
                    // 공격
                    Animation("Attack");

                }
            }
            else
            {
                // 이동
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
        targetCastle.GetComponent<MyCastle>().Damage(damage);
    }
    void Attack(GameObject obj)
    {
        attackTime += Time.deltaTime;
        
        if (attackTime > data.attackdelaytime)
        {
            if (obj.name != "Player")
            {
                obj.GetComponent<Monster>().Damage(damage);
            }
            else
            {
                if (!obj.GetComponent<Player>().isDie)
                {
                    obj.GetComponent<Player>().Damage(damage);
                }
            }
            attackTime = 0f;
        }
    }
    public void Damage(float argDmg)
    {
        HP = argDmg;
        hpImage.fillAmount = HP / maxHP;
    }
}
