using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
    /*
        TODO:
            
    */

    GameObject player;
    Transform pTrans;

    public Transform lookat;

    mouseLookat _mouseLookAt;

    Vector3 playerPos;
    Vector3 gotoPos;
    //public float smoothing = 0.1f;
    //private Vector3 velocity = Vector3.zero;

    public float MaxX = 90;
    public float MinX = -90;

    public float sensitivity = 500f;

    public Vector3 offset;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _mouseLookAt = player.GetComponent<mouseLookat>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        pTrans = player.GetComponent<Transform>();
        transform.position = pTrans.transform.position + offset;

        sensitivity = _mouseLookAt.mouseSensitivity;
    }

    private void Update()
    {
        /*
        if (!moveTowardsPlayer)
        {
            Vector3.MoveTowards(transform.position, player.transform.position, moveTowardsPlayerSpeed * Time.deltaTime);
            transform.LookAt(pTrans.transform);
        }
        else if(moveTowardsPlayer)
        {
            transform.position = pTrans.transform.position + offset;
            //transform.LookAt(pTrans.transform);
        }
        */

        /*
        float horizontal = Input.GetAxis("Mouse X") * sensitivity;
        pTrans.Rotate(0, horizontal, 0);
        */

    }

    
    private void LateUpdate()
    {
        sensitivity = _mouseLookAt.mouseSensitivity;

        transform.localEulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime, 0, 0);


        //&& transform.localEulerAngles.x < 180
        if (transform.localEulerAngles.x > MaxX && transform.localEulerAngles.x < 180)
        {
            // transform.localEulerAngles.x = Mathf.Clamp(transform.localEulerAngles.x, 0, MaxX);
            transform.localEulerAngles = new Vector3(MaxX, 0, 0);
        }
        // && transform.localEulerAngles.x > 180
        if (transform.localEulerAngles.x < MinX && transform.localEulerAngles.x > 180)
        {
            transform.localEulerAngles = new Vector3(MinX, 0, 0);
        }

        float direction = pTrans.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, direction, 0);

        transform.position = pTrans.transform.position + rotation * offset;
        /*
        float direction = pTrans.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, direction, 0);

        transform.position = pTrans.transform.position + rotation * offset;
        transform.LookAt(lookat);
        */
    }     
    
}
