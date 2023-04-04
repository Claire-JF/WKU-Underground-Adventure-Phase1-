using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For any questions of this part, please contact Wang Junfeng for help (vx:winter-camellia)


public class Chest : Collectable
{
    public Sprite emptyChest;//箱子开过后的样子
    public int pesosAmount = 5; //箱子里的金币数量

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
}
