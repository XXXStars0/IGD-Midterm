using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKettle : MonoBehaviour
{
    public bool isTouchTrigger;
    public bool touchTrigger;
    public bool clickTrigger;

    bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        isTouchTrigger = this.GetComponent<InteractiveTrigger>().isTouchTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ItemHolder").GetComponent<ItemHolder>().itemID == 3 && (clickTrigger || (touchTrigger && isTouchTrigger)))
        {
            closeTruggers();
            Debug.Log(GameObject.Find("SE_WaterPour"));
            GameObject.Find("SE_WaterPour").GetComponent<AudioSource>().Play();
            GameObject.Find("Player").GetComponent<PlayerController>().canWalk = false;
            a = true;
        }
        if (a && GameObject.Find("Player").GetComponent<PlayerController>().canWalk == false && !GameObject.Find("SE_WaterPour").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("SE_Get").GetComponent<AudioSource>().Play();
            GameObject.Find("Player").GetComponent<PlayerController>().canWalk = true;
            GameObject.Find("ItemHolder").GetComponent<ItemHolder>().itemID = 4;
            a = false;
        }
    }

    void closeTruggers()
    {
        touchTrigger = false;
        clickTrigger = false;
        this.GetComponent<InteractiveTrigger>().touchTrigger = false;
        this.GetComponent<InteractiveTrigger>().clickTrigger = false;
    }
}
