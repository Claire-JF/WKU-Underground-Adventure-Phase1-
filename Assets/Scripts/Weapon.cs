using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //here is the damage struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    //here is the Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //Swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    //这里做出判断，如果是敌人就可以输出攻击，如果是npc或玩家就不可
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

            //我们在这里建一个伤害对象，我们会将其发送到我们击打的fighter tag对象
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("Receive Damage",dmg);
        }
        
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");
    }
}
