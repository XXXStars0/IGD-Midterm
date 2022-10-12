using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTrigger : MonoBehaviour
{
    public bool isTouchTrigger;
    public bool touchTrigger;
    public bool clickTrigger;
    // Start is called before the first frame update
    void Start()
    {
        touchTrigger = false;
        clickTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touchTrigger || clickTrigger)
        {
            pick();
            door();
            hold();
            WashingUp();
            toasting();
            WaterKettle();
            fin();
        }
    }
    void fin()
    {
        if (GetComponent<DoorAndFinishCheck>())
        {
            this.GetComponent<DoorAndFinishCheck>().touchTrigger = touchTrigger;
            this.GetComponent<DoorAndFinishCheck>().clickTrigger = clickTrigger;
        }
    }

    void WaterKettle()
    {
        if (GetComponent<WaterKettle>())
        {
            this.GetComponent<WaterKettle>().touchTrigger = touchTrigger;
            this.GetComponent<WaterKettle>().clickTrigger = clickTrigger;
        }
    }
    void toasting()
    {
        if (GetComponent<ToasterController>())
        {
            this.GetComponent<ToasterController>().touchTrigger = touchTrigger;
            this.GetComponent<ToasterController>().clickTrigger = clickTrigger;
        }
    }
    void WashingUp()
    {
        if (GetComponent<WashingUp>() && GameObject.Find("ItemHolder").GetComponent<ItemHolder>().itemID == 0)
        {
            this.GetComponent<WashingUp>().touchTrigger = touchTrigger;
            this.GetComponent<WashingUp>().clickTrigger = clickTrigger;
        }
    }
    void door()
    {
        if (GetComponent<Door>())
        {
            this.GetComponent<Door>().touchTrigger = touchTrigger;
            this.GetComponent<Door>().clickTrigger = clickTrigger;
        }
    }
    void pick()
    {
        if (GetComponent<PickableObject>())
        {
            this.GetComponent<PickableObject>().touchTrigger = touchTrigger;
            this.GetComponent<PickableObject>().clickTrigger = clickTrigger;
        }
    }

    void hold()
    {
        if (GetComponent<ContainerOhject>())
        {
            this.GetComponent<ContainerOhject>().touchTrigger = touchTrigger;
            this.GetComponent<ContainerOhject>().clickTrigger = clickTrigger;
        }
    }
}
