using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : Node
{


    public override void Execute()
    {



        if (Vector3.Distance(BT.transform.position, BT._player.transform.position) <= BT.attackRange && BT.ect.characterOnFire == false)
        {
            BT.playerspotted = false;
            BT.attack = true;
            BT.transform.LookAt(BT._player.transform.position);
            Debug.Log("attack" + state);
            state = Node_State.success;
            // BT.pct.takeDamage(0.1f);
            BT.speed = 0;

        }
        else
        {
            BT.playerspotted = true;
            BT.attack = false;
            state = Node_State.faliure;
            BT.speed = BT.movespeed;
        }



    }
}