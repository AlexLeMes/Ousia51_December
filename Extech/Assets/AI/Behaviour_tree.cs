    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript;



public class Behaviour_tree : MonoBehaviour
{

    public Node root;
    public GameObject player;
    public GameObject[] waypoints;
    public int target;
    public float speed;
    public float moveSpeed;
    public bool playerspotted;
    public bool canmove;
    public float maxdistance = 15;
    public bool waypoint;
    public float angle;
    public float vision = 40;
    public RaycastHit hit;
    public RaycastHit hitInfo;
    public character pct;
    public character ect;
    public float Maxvel = 1;
    public Vector3 Currvel;
    public Vector3 dir;
    public Vector3 tar;
    public float enemieawarness;
    public float slowradius;
    public float deceleration;
    public Vector3 steeringforce;


    public void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        pct = player.GetComponent<character>();
        ect = this.gameObject.GetComponent<character>();

        //InvokeRepeating("updateBehaviourTree", 0f,1f);
        target = 0;

        selector_node selector = new selector_node();

        root = selector;

       
        sequenc_node sequenc = new sequenc_node();
        selector.children.Add(sequenc);
        sequenc.children.Add(new Chase());
        sequenc.children.Add(new attack());
        selector.children.Add(new flee());
        selector.children.Add(new patrol());
        selector.children.Add(new idle());

        root.BT = this;

        root.Start();

    }
    
    public void Update()
    {
        //dir = (tar - transform.position).normalized;


        root.Execute();
        
    }
    /*
    public void updateBehaviourTree()
    {
        dir = (tar - transform.position).normalized;


        root.Execute();
    }
    */
    void OnDrawGizmos()
    {
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, maxdistance);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, vision);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, angle);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, enemieawarness);
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, slowradius);
        }

    }



}
