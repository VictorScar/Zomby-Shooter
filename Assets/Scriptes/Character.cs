using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float health = 1f;
    [SerializeField] protected float speed = 1f;
    //[SerializeField] protected float damage = 1f;
    [SerializeField] protected float atackSpeed = 2f;
    [SerializeField] protected GameObject damageeffect;
    [SerializeField] protected Animator characterAnimator;
    [SerializeField] protected Vector3 damageEffectPosition;

    public virtual void Attack()
    {

    }

    public virtual void TakeDamage(float damage)
    {
        if (health >= 0)
        {
            health -= damage;
        }
        if (damageeffect != null)
        {
            Instantiate(damageeffect, transform.position + damageEffectPosition, Quaternion.identity, transform);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
