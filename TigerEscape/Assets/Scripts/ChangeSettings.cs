using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSettings : MonoBehaviour
{
    public Settings mySettings;

    // Change the setting values depending on the mySettings object
    void Start()
    {
        GetComponent<GameManagerX>().life = mySettings.life;
        GetComponent<GameManagerX>().tigerSpeed = mySettings.tigerSpeed;
        GetComponent<GameManagerX>().carSpeed = mySettings.carSpeed;
        GetComponent<GameManagerX>().dartSpeed = mySettings.dartSpeed;
        GetComponent<GameManagerX>().dartReduce = mySettings.dartReduce;
        GetComponent<GameManagerX>().carReduce = mySettings.carReduce;
        GetComponent<GameManagerX>().hunterReduce = mySettings.hunterReduce;

    }

}
