using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For any questions of this part, please contact Wang Junfeng for help (vx:winter-camellia)


public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10]; //存储与其碰撞的物体

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits); //把碰到的东西放进hit数组里

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            OnCollide(hits[i]);
            
            hits[i] = null; //清空
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("OnCollide was not implemented in " + this.name);
    }
}
