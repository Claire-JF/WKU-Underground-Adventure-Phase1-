using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For any questions of this part, please contact Wang Junfeng for help (vx:winter-camellia)


public class Collectable : Collidable
{
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        { //只有玩家与之碰撞才给钱，而非其他的物体（敌人，npc等）
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
