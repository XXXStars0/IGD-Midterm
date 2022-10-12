using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm_Check : MonoBehaviour
{
    public AudioSource SE_Alarm;
    public bool isAlarming = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlarming)
        {
            SE_Alarm.Stop();
        }
    }
}
