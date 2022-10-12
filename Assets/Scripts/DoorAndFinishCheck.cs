using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorAndFinishCheck : MonoBehaviour
{
    public bool isTouchTrigger;
    public bool touchTrigger;
    public bool clickTrigger;
    public bool checker;
    public Sprite Door_Open;

    AudioSource SE_Door;
    AudioSource SE_No;
    // Start is called before the first frame update
    void Start()
    {
        SE_Door = GameObject.Find("SE_Door").GetComponent<AudioSource>();
        SE_No = GameObject.Find("SE_Cancel").GetComponent<AudioSource>();
        checker = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ItemHolder").GetComponent<ItemHolder>().itemID==19 && GameObject.Find("ItemHolder").GetComponent<ItemHolder>().toastCount>=2)
        {
            checker = true;
        }
        if (clickTrigger || (touchTrigger && isTouchTrigger))
        {
            if (checker)
            {
                StartCoroutine(gameEnd());
            }
            else
            {
                SE_No.Play();
                closeTruggers();
            }
        }
    }

    IEnumerator gameEnd()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().canWalk = false;
        closeTruggers();
        this.GetComponent<SpriteRenderer>().sprite = Door_Open;
        GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
        SE_Door.Play();
        yield return new WaitForSeconds(1f);
        GameObject.Find("SE_Fin").GetComponent<AudioSource>().Play();
        GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("End");

    }
    void closeTruggers()
    {
        touchTrigger = false;
        clickTrigger = false;
        this.GetComponent<InteractiveTrigger>().touchTrigger = false;
        this.GetComponent<InteractiveTrigger>().clickTrigger = false;
    }
}
