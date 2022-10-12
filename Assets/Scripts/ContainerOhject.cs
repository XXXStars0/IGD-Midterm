using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerOhject : MonoBehaviour
{
    public int[] RequiredItems;
    public Sprite Stage1;
    public Sprite Stage2;
    public bool pickAble;
    private bool[] Requirement;

    public bool isTouchTrigger;
    public bool touchTrigger;
    public bool clickTrigger;

    GameObject ItemHolderObject;
    int CurrItemID;
    // Start is called before the first frame update
    void Start()
    {
        isTouchTrigger = this.GetComponent<InteractiveTrigger>().isTouchTrigger;
        ItemHolderObject = GameObject.Find("ItemHolder");
        Requirement = new bool[RequiredItems.Length];
        if (pickAble) { this.gameObject.GetComponent<PickableObject>().enabled = false; }
    }

    // Update is called once per frame
    void Update()
    {
        if (clickTrigger || (touchTrigger && isTouchTrigger))
        {
            bool isPut = false;
            CurrItemID = ItemHolderObject.GetComponent<ItemHolder>().itemID;
            for(int i=0;i< RequiredItems.Length;i++)
            {
                if (CurrItemID == RequiredItems[i] && !Requirement[i])
                {
                    isPut = true;
                    Requirement[i] = true;
                    StartCoroutine(putItem());
                    break;
                }
            }
            if (!isPut)
            {
                GameObject.Find("SE_Cancel").GetComponent<AudioSource>().Play();
            }
            int count = 0;
            for(int i=0;i< RequiredItems.Length; i++)
            {
                if (Requirement[i])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            if(count== RequiredItems.Length)
            {
                GameObject.Find("SE_Get").GetComponent<AudioSource>().Play();
                if (pickAble) { this.gameObject.GetComponent<PickableObject>().enabled = true; }
                this.gameObject.GetComponent<ContainerOhject>().enabled = false;
            }
            closeTruggers();
        }
    }

    IEnumerator putItem()
    {
        this.GetComponent<SpriteRenderer>().sprite = Stage2;
        GameObject.Find("ItemHolder").transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
        GameObject.Find("SE_Throw").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.25f);
        GameObject.Find("ItemHolder").transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        ItemHolderObject.GetComponent<ItemHolder>().itemID = 0;
        this.GetComponent<SpriteRenderer>().sprite = Stage1;
    }

    void closeTruggers()
    {
        touchTrigger = false;
        clickTrigger = false;
        this.GetComponent<InteractiveTrigger>().touchTrigger = false;
        this.GetComponent<InteractiveTrigger>().clickTrigger = false;
    }
}
