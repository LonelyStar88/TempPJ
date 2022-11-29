using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private GameObject targetCastle;
    private GameObject target;

    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        targetCastle = GameObject.FindGameObjectWithTag("enemyCastle");
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ����� �� ã��
        FindEnemy();
    }
    void FindEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");
        if(objs.Length != 0)
        {
            //���� ã�´�.
        }
        else
        {
            float dis = Vector3.Distance(transform.position, targetCastle.transform.position);
            if (dis < 5)
            {
                // ����
                Animation("Attack");
            }
            else
            {
                // �̵�
                Animation("Walk");
                transform.position += Vector3.right * Time.deltaTime * 10f;
            }
        }

        void Animation(string aniName)
        {
            animator.SetTrigger(aniName);
        }
    }
}
