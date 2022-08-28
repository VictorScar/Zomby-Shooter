using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    //[SerializeField] float health = 1f;
    //[SerializeField] float speed = 1f;
    [SerializeField] protected float damage = 1f;
    //[SerializeField] float atackSpeed = 2f;
    [SerializeField] Player target;
    //[SerializeField] GameObject damageeffect;
    [SerializeField] Vector3 ofset = new Vector3(0f, 0, 0.2f);
    float count = 0;
    bool distanceOfAtack = false;

    private void Start()
    {
        if (target == null)
        {
            target = Game.GameInstance.Player;
        }

    }

    void Update()
    {
        if (target != null)
        {
            if (transform.position.z - target.transform.position.z == ofset.z | transform.position.z - target.transform.position.z <= ofset.z + 1f | transform.position.z - target.transform.position.z <= ofset.z - 1f)
            {
                distanceOfAtack = true;
            }

            if (!distanceOfAtack)
            {
                transform.LookAt(target.transform.position);
                //transform.Translate((target.transform.position - transform.position).normalized * speed * Time.deltaTime);
                //transform.LookAt(target.transform.position);
                transform.Translate(-transform.forward * speed * Time.deltaTime);
            }

            else
            {
                Attack();
            }
            //if (transform.position.z - target.transform.position.z == ofset.z && transform.position.x - target.transform.position.x == ofset.x)
            //{
            //    Atack();
            //}
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public override void Attack()
    {
        base.Attack();
        count += Time.deltaTime;
        if (count >= atackSpeed)
        {
            target.TakeDamage(damage);
            count = 0;
        }
    }

    //public override void TakeDamage(float damage)
    //{
    //    if (health >= 0)
    //    {
    //        health -= damage;
    //    }
    //    if (damageeffect != null)
    //    {
    //        Instantiate(damageeffect, transform.position + damageEffectPosition, Quaternion.identity, transform);
    //    }
    //}

}
