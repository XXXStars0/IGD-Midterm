using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public int id = 0;
    private AudioSource get;
    private AudioSource can;
    private GameObject ItemHolderObject;

    public bool isTouchTrigger;
    public bool touchTrigger;
    public bool clickTrigger;
    // Start is called before the first frame update
    void Start()
    {
        get = GameObject.Find("SE_Get").GetComponent<AudioSource>();
        can = GameObject.Find("SE_Cancel").GetComponent<AudioSource>();
        ItemHolderObject = GameObject.Find("ItemHolder");
        isTouchTrigger = this.GetComponent<InteractiveTrigger>().isTouchTrigger;

    }

    // Update is called once per frame
    void Update()
    {
        if (clickTrigger || (touchTrigger&& isTouchTrigger))
        {
            if (ItemHolderObject.GetComponent<ItemHolder>().itemID==0) {
                get.Play();
                StartCoroutine(getItem());
            }
            else
            {
                can.Play();
                closeTruggers();
            }
        }
    }


    IEnumerator getItem()
    {
        closeTruggers();
        /*Color c = GetComponent<SpriteRenderer>().color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.5f)
        {
            c.a = alpha;
            GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(0.1f);
        }*/
        this.transform.localScale += new Vector3(0.25f,0.25f,0.25f);
        yield return new WaitForSeconds(0.25f);
        this.transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        ItemHolderObject.GetComponent<ItemHolder>().itemID = id;
        if (id == 24)
        {
            GameObject.Find("Toaster").GetComponent<Animator>().SetTrigger("BreadTake");
        }
        Destroy(gameObject); 
    }

    void closeTruggers()
    {
        touchTrigger = false;
        clickTrigger = false;
        this.GetComponent<InteractiveTrigger>().touchTrigger = false;
        this.GetComponent<InteractiveTrigger>().clickTrigger = false;
    }
}
