using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimationController : MonoBehaviour {

    
    public GameObject enemyModel;
    public Animator anim;
    public Behaviour_tree bt;

    private void Awake()
    {
        anim = enemyModel.GetComponent<Animator>();
        bt = GetComponent<Behaviour_tree>();
    }


    void Update()
    {


        if (bt.ect.characterOnFire == true || bt.playerspotted == true)
        {
            anim.SetInteger("enemyanm", 2);
        }
        else if (bt.waypoints.Length > 0)
        {
            anim.SetInteger("enemyanm", 1);
        }

        else if (bt.attack == true)
        {
            anim.SetInteger("enemyanm", 3);
            bt.idle = false;
        }
        else if (bt.ect.health < 0)
        {
            anim.SetInteger("enemyanm", 4);
        }
        else if (bt.idle == true)
        {
            anim.SetInteger("enemyanm", 0);
        }
    }
}
