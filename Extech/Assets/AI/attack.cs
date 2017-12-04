using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : Node
{

    
    public override void Execute()
    {
      


        if (Vector3.Distance(BT.transform.position, BT.player.transform.position) < 2 && BT.ect.characterOnFire==false)
        {
            Debug.Log("attack"+state);
            state = Node_State.success;
            BT.pct.takeDamage(0.1f);
            //attack animation here

        }
        else
        {
            state = Node_State.faliure;
        }
        
        

    }
}
