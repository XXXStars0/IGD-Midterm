using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatAndExamTrigger : MonoBehaviour
{
    public string[] interactiveLayers;
    public Rigidbody2D rb_player;
    public float checkLength;
    private LayerMask raycastMask;
    private int dir;
    private Vector2 castDir;
    private GameObject ItemHolderObject;
    //Bubbles
    public GameObject[] Bubbles;
    public bool eventON;

    // Start is called before the first frame update
    void Start()
    {
        eventON = false;
        ItemHolderObject = GameObject.Find("ItemHolder");
        raycastMask = LayerMask.GetMask(interactiveLayers);
        dir = 2;
        Vector2 castDir = Vector2.down;
        foreach(GameObject obj in Bubbles)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        dir = GameObject.Find("Player").GetComponent<PlayerController>().dir;
        //2¡ý4¡û6¡ú8¡ü

        switch (dir)
        {
            case 2:
                castDir = Vector2.down;
                break;
            case 4:
                castDir = Vector2.left;
                break;
            case 6:
                castDir = Vector2.right;
                break;
            case 8:
                castDir = Vector2.up;
                break;
        }
        RaycastHit2D CommuInfo = Physics2D.Raycast(rb_player.position, castDir, checkLength, raycastMask);
        Debug.DrawRay(rb_player.position, castDir * checkLength, Color.green);

        //CircleCast(Vector2 origin, float radius, Vector2 direction, float distance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, float minDepth = -Mathf.Infinity, float maxDepth = Mathf.Infinity);
        // Gizmos.DrawSphere 

        if (CommuInfo && CommuInfo.collider.gameObject.GetComponent<InteractiveTrigger>())
        {
            if (!CommuInfo.collider.gameObject.GetComponent<InteractiveTrigger>().isTouchTrigger && Input.GetButtonDown("Fire1"))
            {
                if (CommuInfo.collider.gameObject.GetComponent<InteractiveTrigger>().clickTrigger == false)
                {
                    CommuInfo.collider.gameObject.GetComponent<InteractiveTrigger>().clickTrigger = true;
                }
            }

            if (CommuInfo.collider.gameObject.GetComponent<InteractiveTrigger>().isTouchTrigger && CommuInfo.collider.gameObject.GetComponent<InteractiveTrigger>().touchTrigger == false)
            {
                CommuInfo.collider.gameObject.GetComponent<InteractiveTrigger>().touchTrigger = true;
            }
        }

        //Bubbles
        if (CommuInfo)
        {
            eventON = true;
            //Pick
            if (CommuInfo.collider.gameObject.GetComponent<PickableObject>() && CommuInfo.collider.gameObject.GetComponent<PickableObject>().isActiveAndEnabled && ItemHolderObject.GetComponent<ItemHolder>().itemID == 0)
            {
                Bubbles[0].SetActive(true);
            }
            else
            {
                Bubbles[0].SetActive(false);
            }
            //Door
            if (CommuInfo.collider.gameObject.GetComponent<Door>())
            {
                Bubbles[1].SetActive(true);
            }
            else
            {
                Bubbles[1].SetActive(false);
            }
            //Container
            if (CommuInfo.collider.gameObject.GetComponent<ContainerOhject>() && CommuInfo.collider.gameObject.GetComponent<ContainerOhject>().isActiveAndEnabled && ItemHolderObject.GetComponent<ItemHolder>().itemID != 0)
            {
                Bubbles[2].SetActive(true);
            }
            else
            {
                Bubbles[2].SetActive(false);
            }
            //Washing
            if (CommuInfo.collider.gameObject.GetComponent<WashingUp>() && !CommuInfo.collider.gameObject.GetComponent<WashingUp>().isCleaned && GameObject.Find("ItemHolder").GetComponent<ItemHolder>().itemID == 0)
            {
                Bubbles[3].SetActive(true);
            }
            else
            {
                Bubbles[3].SetActive(false);
            }
            if (CommuInfo.collider.gameObject.GetComponent<WashingUp>() && CommuInfo.collider.gameObject.GetComponent<WashingUp>().isCleaned)
            {
                Bubbles[4].SetActive(true);
            }
            else
            {
                Bubbles[4].SetActive(false);
            }
            //Toaster(Water Boiler
            if ((CommuInfo.collider.gameObject.GetComponent<WaterKettle>() && ItemHolderObject.GetComponent<ItemHolder>().itemID == 3) || (CommuInfo.collider.gameObject.GetComponent<ToasterController>() && ItemHolderObject.GetComponent<ItemHolder>().itemID == 23))
            {
                Bubbles[5].SetActive(true);
            }
            else
            {
                Bubbles[5].SetActive(false);
            }
            //Door_NG
            if (CommuInfo.collider.gameObject.GetComponent<DoorAndFinishCheck>()&& !CommuInfo.collider.gameObject.GetComponent<DoorAndFinishCheck>().checker)
            {
                Bubbles[6].SetActive(true);
            }
            else
            {
                Bubbles[6].SetActive(false);
            }
            //Door_OK
            if (CommuInfo.collider.gameObject.GetComponent<DoorAndFinishCheck>() && CommuInfo.collider.gameObject.GetComponent<DoorAndFinishCheck>().checker)
            {
                Bubbles[7].SetActive(true);
            }
            else
            {
                Bubbles[7].SetActive(false);
            }
            //end
            //end
        }
        else
        {
            eventON = false;
            foreach (GameObject obj in Bubbles)
            {
                obj.SetActive(false); 
            }
        }
    }
      
}
