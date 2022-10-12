using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Title : MonoBehaviour
{
    float x;
    public float walkingSpeed=5;
    public CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam.m_Lens.OrthographicSize = 6;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");

        this.GetComponent<Transform>().Translate(x * Time.deltaTime * walkingSpeed,0,0);
        if (this.GetComponent<Transform>().position.x < -32) { this.GetComponent<Transform>().SetPositionAndRotation(new Vector3(-32f,0,0),Quaternion.identity); }
        if (this.GetComponent<Transform>().position.x > 50) { SceneManager.LoadScene("Main"); }
    }
}
