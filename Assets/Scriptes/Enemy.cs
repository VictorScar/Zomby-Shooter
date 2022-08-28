using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected float damage = 1f;
    [SerializeField] Player target;
    [SerializeField] Collider enemyCollider;
    [SerializeField] Vector3 ofset = new Vector3(0f, 0, 0.2f);
    float count = 0;
    bool distanceOfAtackX = false;
    bool distanceOfAtackZ = false;

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
            if (Health > 0)
            {
                if (transform.position.z - target.transform.position.z == ofset.z | transform.position.z - target.transform.position.z <= ofset.z + 1f | transform.position.z - target.transform.position.z <= ofset.z - 1f)
                {
                    distanceOfAtackZ = true;
                }
                if (transform.position.x - target.transform.position.x == ofset.x | transform.position.x - target.transform.position.x <= ofset.x + 1f | transform.position.x - target.transform.position.x <= ofset.x - 1f)
                {
                    distanceOfAtackX = true;
                }

                if (!(distanceOfAtackZ && distanceOfAtackX))
                {
                    characterAnimator.Play("Zombie1_Walk");
                    transform.LookAt(target.transform.position);
                    transform.Translate(-transform.forward * speed * Time.deltaTime);
                }

                else
                {
                    Attack();
                }
            }
            else
            {
                Destroy(enemyCollider);
                Die();
            }

        }
        else
        {
            characterAnimator.Play("Zombie1_Idle");
        }
    }

    public override void Attack()
    {
        if (attackEffectSound != null)
        {
            characterAudio.clip = attackEffectSound;
        }
        if (count == 0)
        {
            characterAnimator.Play("Zombie1 atack");
            characterAudio.Play();
            target.TakeDamage(damage);
            count = atackSpeed;
        }
        count += Time.deltaTime;
    }

    public override void Die()
    {
        if (characterAnimator != null)
        {
            characterAnimator.Play("Zombie1_Death");
        }
        if (deathEffectSound != null)
        {
            characterAudio.clip = deathEffectSound;
            characterAudio.Play();
        }
        StartCoroutine(DieAnimation());
    }

    IEnumerator DieAnimation()
    {

        yield return new WaitForSeconds(3);
        base.Die();
    }
}
