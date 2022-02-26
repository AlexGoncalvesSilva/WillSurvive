using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{

    public float Oxygen;
    public Image Bar;

    public static OxygenBar instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;  
    }

    // Update is called once per frame
    void Update()
    {
       
        Bar.fillAmount = Oxygen / 120;
        Oxygen-= Time.deltaTime;

        if (Oxygen <= 0)
        {
            Debug.Log("GameOver");
            GameControllerGame.instance.ShowGameOverOxygen();
        }
      
    }
}
