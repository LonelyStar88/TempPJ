using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private Image GageImage;
    [SerializeField]
    private TMP_Text GageTxt;

    private float gage = 0;
    private float maxgage = 0;

    private float time = 0f;

    // �� �Ʊ� ���� ����

    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject prefab;

    public bool IsGageCheck(int value)
    {
        //���׽� => ���� ? true : false  -> ���ǿ� �����ϸ� ? �ڿ��� �ٷ� true, :�ڿ��� �ƴϸ� false
        return gage >= value ? true : false;
    }
    public float Gage
    {
        get { return gage; }
        set 
        {
           
            gage = value;
            GageImage.fillAmount = gage / maxgage;
            GageTxt.text = $"{(int)gage} / {(int)maxgage}";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxgage = 100f;
        Gage = 0;

        foreach(DataPawn.PawnData item in DataPawn.Ins.pawnData.pawn)
        {
            Instantiate(prefab, parent).GetComponent<MakePawnItem>().Init(item, this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 0.1f)
        {
            time = 0f;
            if(gage <= maxgage)
            {
                Gage += 0.2f;
            }
        }
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Gage -= 20f;
        }
    }
}
