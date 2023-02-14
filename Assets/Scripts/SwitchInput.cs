using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInput : MonoBehaviour
{
    public GameObject realityRoom;
    public GameObject nightmareRoom;
    public Material material;
    public bool b = true;
    //private bool oddClick = true;
    private bool isSwitch = false;
    private float currentTime = 0f;
    public float transTimer;
    public int transSpeed;
    private int startValue;
    private float i;
    private int j = 0;
    public float returnDelay;

    private void Awake()
    {
        i = transSpeed;
        startValue = transSpeed;
        material.color = new Color(0.6f, 0.6f, 0.6f, 1.0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Debug.Log(material.color.a);
        SwitchRoom();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isSwitch)
        {
            isSwitch = true;
            j++;
            //Debug.Log(j);
        }
    }

    private void FixedUpdate()
    {
        if (isSwitch && j%2 == 1)
        {
            SwitchProcess();
        }
        if(isSwitch && j % 2 == 0)
        {
            isSwitch = !isSwitch;
            transSpeed = startValue;
            Invoke("ReturnReality", returnDelay);
        }
    }

    void SwitchProcess()
    {
        currentTime += Time.deltaTime;
        if(currentTime > transTimer)
        {
            if (transSpeed > 0)
            {
                transSpeed--;
                material.color = new Color(0.6f, 0.6f, 0.6f, Mathf.Lerp(0, 1, transSpeed / i));
            }
            else
            {
                SwitchRoom();
                isSwitch = !isSwitch; ;
                //Debug.Log(isSwitch);
            }
            currentTime = 0f;
        }

    }

    void SwitchRoom()
    {
        realityRoom.SetActive(b);
        nightmareRoom.SetActive(!b);
        b = !b;
    }

    void ReturnReality()
    {
        realityRoom.SetActive(b);
        nightmareRoom.SetActive(!b);
        b = !b;
        material.color = new Color(0.6f, 0.6f, 0.6f, 1.0f);
    }
}
