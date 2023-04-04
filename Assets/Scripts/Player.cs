using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For any questions of this part, please contact Yuan Shuai for help (vx:YsYs0211)

[RequireComponent(typeof(BoxCollider2D))]
public class Player : Mover
{
    //记录移动
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }
}
