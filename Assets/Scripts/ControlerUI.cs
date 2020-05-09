using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlerUI : MonoBehaviour
{
    // Start is called before the first frame update
    DataInfo dI;
    [SerializeField] Image image;



    void Start()
    {
        dI = DataInfo.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }



    private void UpdateHealth()
    {
        dI.cancer = Mathf.Clamp(dI.cancer, 0, dI.cancerMax);
        float amount = (float)dI.cancer / dI.cancerMax;
        image.fillAmount = amount;
    }
}
