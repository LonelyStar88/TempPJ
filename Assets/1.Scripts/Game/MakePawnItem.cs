using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MakePawnItem : MonoBehaviour
{
    [SerializeField]
    private Button makeBtn;
    [SerializeField]
    private GameObject delayObj;
    [SerializeField]
    private Image delayImage;
    [SerializeField]
    private TMP_Text delayTxt;
    [SerializeField]
    private TMP_Text priceTxt;

    private DataPawn.PawnData data = new DataPawn.PawnData();
    private GameUI gameUI;

    // Start is called before the first frame update
    void Start()
    {
        //Init(data);
        delayObj.SetActive(false);
        makeBtn.onClick.AddListener(OnMakePawn);
    }

    public void Init(DataPawn.PawnData pawnData, GameUI ui)
    {
        data.delaymaxtime = pawnData.delaymaxtime;
        data.index = pawnData.index;
        data.price = pawnData.price;

        gameUI = ui;
        priceTxt.text = data.price.ToString();
    }

    void OnMakePawn()
    {
        if(delayImage.fillAmount != 1f)
        {
            return;
        }

        if (gameUI.IsGageCheck(data.price))
        {
            delayObj.SetActive(true);
            gameUI.Gage -= data.price;
            StartCoroutine(DelayTime(data.delaymaxtime));
            Manager.Ins.spawnMgr.MySpawn(data.index);
        }
    }

    

    IEnumerator DelayTime(float delay)
    {

        float max = delay;
        

        delayTxt.text = max.ToString();
        while(true)
        {
            if(delay <= 0)
            {
                delayImage.fillAmount = 1f;
                delayObj.SetActive(false);
                break;
            }
            
            delayImage.fillAmount = (max - delay) / max;
            delayTxt.text = string.Format("{0:0.0}", delay);
            delay -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
