using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x, y;
    private bool isWalking;

    public int dir;
    public float walkingSpeed;
    public bool canWalk;
    private Animator a;
    public AudioSource walkSE;
    // Start is called before the first frame update
    void Start()
    {
        dir = 2;
        //2¡ý4¡û6¡ú8¡ü
        a = this.GetComponent<Animator>();
        isWalking = false;
        canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        a.SetBool("W",isWalking);
        if ((x != 0 || y != 0)&&canWalk)
        {
            if (x < 0)
            {
                dir = 4;
            }
            if (x > 0)
            {
                dir = 6;
            }
            if (y < 0)
            {
                dir = 2;
            }
            if (y > 0)
            {
                dir = 8;
            }
            if (!walkSE.isPlaying)
            {
                a.SetFloat("X", x);
                a.SetFloat("Y", y);
                walkSE.Play(); isWalking = true;
            }

            this.GetComponent<Transform>().Translate(x * Time.deltaTime * walkingSpeed, y * Time.deltaTime * walkingSpeed, 0);
        }
        else
        {
            walkSE.Stop(); isWalking = false;
        }
    }

}
