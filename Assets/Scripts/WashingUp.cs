using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingUp : MonoBehaviour
{
    public bool isCleaned;

    public bool isTouchTrigger;
    public bool touchTrigger;
    public bool clickTrigger;
    // Start is called before the first frame update
    void Start()
    {
        isCleaned = false;
        isTouchTrigger = this.GetComponent<InteractiveTrigger>().isTouchTrigger;
        GameObject.Find("WantWash").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("NeedBread").GetComponent<SpriteRenderer>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickTrigger || (touchTrigger && isTouchTrigger))
        {
            if (!isCleaned)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().canWalk = false;
                StartCoroutine(toWashUp());
            }
        }


    }
    IEnumerator toWashUp()
    {
        closeTruggers();
        GameObject.Find("SE_WashingUP").GetComponent<AudioSource>().Play();
        GameObject.Find("WantWash").GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(18f);
        GameObject.Find("Player").GetComponent<PlayerController>().canWalk = true;
        GameObject.Find("NeedBread").GetComponent<SpriteRenderer>().enabled = true;
        isCleaned = true;
        GameObject.Find("SE_Get").GetComponent<AudioSource>().Play();

    }

    void closeTruggers()
    {
        touchTrigger = false;
        clickTrigger = false;
        this.GetComponent<InteractiveTrigger>().touchTrigger = false;
        this.GetComponent<InteractiveTrigger>().clickTrigger = false;
    }
}
