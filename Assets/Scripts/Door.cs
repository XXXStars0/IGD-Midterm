using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnim;
    public bool DoorOpen;
    public bool isTouchTrigger;
    public bool touchTrigger;
    public bool clickTrigger;
    private AudioSource se;
    // Start is called before the first frame update
    void Start()
    {
        isTouchTrigger = this.GetComponent<InteractiveTrigger>().isTouchTrigger;
        doorAnim = this.GetComponent<Animator>();
        DoorOpen = false;
        se = GameObject.Find("SE_Door").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool check = (this.doorAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Door_Opening") && (this.doorAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Door_Closing");
        if (check&&(clickTrigger || (touchTrigger && isTouchTrigger)))
        {
            closeTruggers();
            se.Play();
            DoorOpen = !DoorOpen;
            doorAnim.SetBool("IsOpen", DoorOpen);
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
