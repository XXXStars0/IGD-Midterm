using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterController : MonoBehaviour
{
    public float toastTime;
    public float timer;
    public GameObject finToast;
    public bool isWorking = false;
    public bool isTouchTrigger;
    public bool touchTrigger;
    public bool clickTrigger;
    // Start is called before the first frame update
    Animator a;
    void Start()
    {
        isTouchTrigger = this.GetComponent<InteractiveTrigger>().isTouchTrigger;
        a = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWorking&&(clickTrigger || (touchTrigger && isTouchTrigger)))
        {
            GameObject.Find("ItemHolder").GetComponent<ItemHolder>().itemID = 0;
            a.SetTrigger("BreadIn");
            isWorking = true;
            timer = toastTime;
            GameObject.Find("SE_ToasterIn").GetComponent<AudioSource>().Play();
        }

        if (isWorking)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                GameObject.Find("SE_ToasterPop").GetComponent<AudioSource>().Play();
                isWorking = false;
                a.SetTrigger("BreadOut");
                closeTruggers();
                Object.Instantiate(finToast, new Vector3(1.68f, -8.87f, 0), Quaternion.identity);
            }
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
