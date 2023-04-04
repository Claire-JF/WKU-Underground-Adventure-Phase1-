using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    public BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

    //碰撞检测
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        // 重设movedelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //切换角色左右方向
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //add push vector
        moveDelta += pushDirection;

        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);


        //碰撞时阻止角色移动
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("actor", "blocking"));
        if (hit.collider == null)
        {
            //移动角色
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("actor", "blocking"));
        if (hit.collider == null)
        {
            //移动角色
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
