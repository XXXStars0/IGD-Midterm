using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public int itemID = 0;
    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public GameObject[] throwables;
    private AudioSource SE_Unuseable;
    private AudioSource SE_Throw;
    private AudioSource SE_Get;
    public int toastCount=0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SE_Unuseable = GameObject.Find("SE_Cancel").GetComponent<AudioSource>();
        SE_Throw = GameObject.Find("SE_Throw").GetComponent<AudioSource>();
        SE_Get = GameObject.Find("SE_Get").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Draw current Item
        spriteRenderer.sprite = spriteArray[itemID];
        //Use current Item
        if (Input.GetButtonDown("Fire2"))
        {
            switch (itemID)
            {
                case 6:
                    itemID = 5;
                    SE_Get.Play();
                    GameObject.Find("Vpet Beeping Sound").GetComponent<Alarm_Check>().isAlarming = false;
                    break;
                case 11:
                    SE_Throw.Play();
                    itemID = 27;
                    break;
                case 16:
                    itemID = 15;
                    SE_Get.Play();
                    GameObject.Find("PhoneAlarmClock").GetComponent<Alarm_Check>().isAlarming = false;
                    break;
                case 24:
                    if (GameObject.Find("Washer").GetComponent<WashingUp>().isCleaned) {
                        GameObject.Find("NeedBread").GetComponent<SpriteRenderer>().enabled = false;
                        GameObject.Find("Player").GetComponent<PlayerController>().canWalk = false;
                        GameObject.Find("SE_EatinToast").GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        SE_Unuseable.Play();
                    }
                    break;
                case 27:
                    SE_Throw.Play();
                    itemID = 11;
                    break;
                default:
                    //Unuseable or no items
                    SE_Unuseable.Play();
                    break;
            }
        }
        //Finish Eat'in Bread
        if (itemID==24&&!GameObject.Find("SE_EatinToast").GetComponent<AudioSource>().isPlaying && !GameObject.Find("Player").GetComponent<PlayerController>().canWalk)
        {
            toastCount++;
            SE_Get.Play();
            GameObject.Find("Player").GetComponent<PlayerController>().canWalk = true;
            itemID = 0;
            if (toastCount < 2) { GameObject.Find("NeedBread").GetComponent<SpriteRenderer>().enabled = true; }
        }
        //Throw Item
        if (Input.GetButtonDown("Fire3"))
        {
            bool throwable = false;
            float pos_X = GameObject.Find("Player").GetComponent<Transform>().position.x;
            float pos_Y = GameObject.Find("Player").GetComponent<Transform>().position.y;
            GameObject currItem;
            switch (itemID)
            {
                case 2:
                    currItem = throwables[5];
                    throwable = true;
                    break;
                case 3:
                    currItem = throwables[15];
                    throwable = true;
                    break;
                case 4:
                    currItem = throwables[16];
                    throwable = true;
                    break;
                case 5:
                    currItem = throwables[11];
                    throwable = true;
                    break;
                case 6:
                    currItem = throwables[12];
                    throwable = true;
                    break;
                case 11:
                    currItem = throwables[8];
                    throwable = true;
                    break;
                case 15:
                    currItem = throwables[4];
                    throwable = true;
                    break;
                case 16:
                    currItem = throwables[3];
                    throwable = true;
                    break;
                case 17:
                    currItem = throwables[7];
                    throwable = true;
                    break;
                case 18:
                    currItem = throwables[6];
                    throwable = true;
                    break;
                case 19:
                    currItem = throwables[10];
                    throwable = true;
                    break;
                case 20:
                    currItem = throwables[0];
                    throwable = true;
                    break;
                case 21:
                    currItem = throwables[1];
                    throwable = true;
                    break;
                case 22:
                    currItem = throwables[2];
                    throwable = true;
                    break;
                case 23:
                    currItem = throwables[13];
                    throwable = true;
                    break;
                case 24:
                    currItem = throwables[14];
                    throwable = true;
                    break;
                case 25:
                    currItem = throwables[17];
                    throwable = true;
                    break;
                case 27:
                    currItem = throwables[9];
                    throwable = true;
                    break;
                case 28:
                    currItem = throwables[18];
                    throwable = true;
                    break;
                default:
                    currItem = null;
                    //No items or unthrowable
                    SE_Unuseable.Play();
                    break;
            }
            if (throwable)
            {
               StartCoroutine( throwItem(pos_X,pos_Y,currItem));
            }
        }
    }

    IEnumerator throwItem(float pos_X, float pos_Y, GameObject currItem)
    {
        this.transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
        SE_Throw.Play();
        yield return new WaitForSeconds(0.25f);
        this.transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        
        itemID = 0;
        Object.Instantiate(currItem, new Vector3(pos_X, pos_Y, 0), Quaternion.identity);
    }

}
