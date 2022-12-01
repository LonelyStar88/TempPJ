using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private GameObject targetCastle;
    private GameObject target;

    [SerializeField]
    private Animator animator;

    private float delayTime = 0f;

    private float damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        targetCastle = GameObject.FindGameObjectWithTag("enemyCastle");
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
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");
        if(objs.Length != 0)
        {
            //적을 찾는다.
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
                transform.position += Vector3.right * Time.deltaTime * 3f;
            }
        }

        void Animation(string aniName)
        {
            animator.SetTrigger(aniName);
        }

        void AttackCastle()
        {
            targetCastle.GetComponent<EnemyCastle>().HP = damage;
        }
    }
}
