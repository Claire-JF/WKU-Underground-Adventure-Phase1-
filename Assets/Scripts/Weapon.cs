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

    //���������жϣ�����ǵ��˾Ϳ�����������������npc����ҾͲ���
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

            //���������ｨһ���˺��������ǻὫ�䷢�͵����ǻ����fighter tag����
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
