using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Node
{
    float MAXSEEAHEAD = 10;
    float radius = 5;
    float distance;
    bool intersect;
    Vector3 avoidanceforce;
    float maxavoidforce;
    Vector3 target;

    Vector3 dir;


   



public override void Execute()
    {

        dir = (BT.player.transform.position - BT.transform.position).normalized;

        Vector3 targetDir = BT.player.transform.position - BT.transform.position;

        if (Vector3.Distance(BT.transform.position, BT.player.transform.position) < BT.enemieawarness)
        {


            Physics.Raycast(BT.transform.position, targetDir.normalized, out BT.hit);
        }
         Debug.DrawRay(BT.transform.position, BT.player.transform.position - BT.transform.position, Color.red);
        BT.angle = Vector3.Angle(targetDir,BT.transform.forward);



        //|| BT.angle <= BT.vision && BT.hit.collider.tag=="Player" 
        if (Vector3.Distance(BT.transform.position, BT.player.transform.position) < BT.maxdistance)
        {

            BT.tar = BT.player.transform.position;

            if (Physics.Raycast(BT.transform.position, BT.transform.forward, out BT.hitInfo, 5f))
            {
                Debug.DrawLine(BT.transform.position, BT.hitInfo.point, Color.blue);
                if (BT.hitInfo.transform != BT.player.transform)
                {
                    dir += BT.hitInfo.normal * 50;
                }
            }

            Vector3 left = BT.transform.position;
            Vector3 right = BT.transform.position;
            left.x -= 7;
            right.x += 7;

            if (Physics.Raycast(left, BT.transform.forward, out BT.hitInfo, 1f))
            {
                Debug.DrawLine(left, BT.hitInfo.point, Color.red);
                if (BT.hitInfo.transform != BT.player.transform)
                {
                    dir += BT.hitInfo.normal * 50;
                }

            }
            if (Physics.Raycast(right, BT.transform.forward, out BT.hitInfo, 1f))
            {
                Debug.DrawLine(right, BT.hitInfo.point, Color.yellow);
                if (BT.hitInfo.transform != BT.player.transform)
                {
                    dir += BT.hitInfo.normal * 50;
                }


            }

            Quaternion rot = Quaternion.LookRotation(BT.dir);
            BT.transform.rotation = Quaternion.Slerp(BT.transform.rotation, rot, Time.deltaTime);
            BT.transform.position += BT.transform.forward * BT.speed * Time.deltaTime;



          //  Vector3 lookatpos = new Vector3(BT.player.transform.position.x, BT.transform.position.y, BT.player.transform.position.z);

            BT.playerspotted = true;
            //BT.transform.LookAt(lookatpos);

            BT.waypoint = false;
            BT.canmove = true;

           // BT.transform.position = Vector3.MoveTowards(BT.transform.position, BT.player.transform.position, BT.speed);
            state = Node_State.success;
            //Debug.Log("chase" + state);








        }
        
        
        else
        {
            BT.waypoint = true;
            BT.canmove = false;
            state = Node_State.faliure;

        }

    


        














     





    }

    
}

