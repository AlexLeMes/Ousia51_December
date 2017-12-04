using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : Node
{


    public override void Execute()
    {
        Debug.Log("state" + state);
        if (BT.waypoint)
        {
          
          //  BT.transform.LookAt(new Vector3(BT.waypoints[BT.target].transform.position.x, BT.player.transform.forward.y, BT.waypoints[BT.target].transform.position.z));





            Vector3 dir = (BT.waypoints[BT.target].transform.position - BT.transform.position).normalized;

            float distance = (BT.waypoints[BT.target].transform.position - BT.transform.position).magnitude;//Vector3.Distance(BT.transform.position, BT.waypoints[BT.target].transform.position);


            //BT.transform.position += BT.steeringforce;






            //Vector3.MoveTowards(BT.transform.position, BT.player.transform.position, BT.speed * BT.deceleration);













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

            if (Physics.Raycast(left, BT.transform.forward, out BT.hit, 5f))
            {
                Debug.DrawLine(BT.transform.position, BT.hitInfo.point, Color.red);

                if (BT.hitInfo.transform != BT.player.transform )
                {
                    dir += BT.hitInfo.normal * 50;
                }
            }
            if (Physics.Raycast(right, BT.transform.forward, out BT.hitInfo, 5f))
            {
                Debug.DrawLine(BT.transform.position, BT.hitInfo.point, Color.green);
                if (BT.hitInfo.transform != BT.player.transform)
                {
                    dir += BT.hitInfo.normal * 50;
                }

            }

            Quaternion rot = Quaternion.LookRotation(dir);
            BT.transform.rotation = Quaternion.Slerp(BT.transform.rotation, rot, Time.deltaTime);
            BT.transform.position += BT.transform.forward * BT.speed *  Time.deltaTime;

            //Debug.Log(BT.hitInfo + "yes");














            // Debug.Log(Vector3.Distance(BT.transform.position, BT.waypoints[BT.target].transform.position));
            Debug.Log(distance);
            Vector3 directin = (BT.waypoints[BT.target].transform.position - BT.transform.position).normalized;

            state = Node_State.running;
            if (BT.waypoint)
            {
               
                //Vector3 directin = (BT.waypoints[BT.target].transform.position - BT.transform.position).normalized;
                
                if (distance < BT.slowradius)
                {
                    BT.deceleration = (0 - (BT.speed * BT.speed)) / (2 * BT.slowradius);
                    BT.speed = Mathf.Clamp(BT.speed, 2f, 5f);
                    BT.speed += BT.deceleration;
                    BT.steeringforce = directin.normalized * Time.deltaTime * BT.speed;



                   Vector3.MoveTowards(BT.transform.position, BT.waypoints[BT.target].transform.position, BT.speed * BT.deceleration);

                }


                else
                {
                    BT.speed = BT.moveSpeed;
                    BT.steeringforce = directin.normalized * Time.deltaTime * BT.speed;
                    Vector3.MoveTowards(BT.transform.position, BT.waypoints[BT.target].transform.position, BT.speed );

                }
                 
               
               // BT.transform.position += BT.steeringforce;
               // Vector3.MoveTowards(BT.transform.position, BT.waypoints[BT.target].transform.position, BT.speed);








                if (Vector3.Distance(BT.transform.position, BT.waypoints[BT.target].transform.position) < 1f)
                {
                    BT.target++;
                    if (BT.target == BT.waypoints.Length)
                    {

                        Debug.Log("patrol" + state);
                        BT.target = 0;
                    }

                    else
                    {

                        state = Node_State.faliure;



                    }









                }

            }
        }
    }
}

