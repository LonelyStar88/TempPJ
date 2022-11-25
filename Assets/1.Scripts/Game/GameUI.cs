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
