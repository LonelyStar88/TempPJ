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

    // Start is called before the first frame update
    void Start()
    {
        delayObj.SetActive(false);
        makeBtn.onClick.AddListener(OnMakePawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMakePawn()
    {
        delayObj.SetActive(true);
        StartCoroutine(DelayTime(3f));
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
