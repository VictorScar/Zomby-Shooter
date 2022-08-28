using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float atackSpeed = 2f;
    [SerializeField] protected GameObject damageeffect;
    [SerializeField] protected Animator characterAnimator;
    [SerializeField] protected Vector3 damageEffectPosition;
    [SerializeField] protected AudioClip damageEffectSound;
    [SerializeField] protected AudioSource characterAudio;
    [SerializeField] protected AudioClip attackEffectSound;
    [SerializeField] protected AudioClip deathEffectSound;


    public float Health { get => health; private set => health = value; }

    public virtual void Attack()
    {

    }

    public virtual void TakeDamage(float damage)
    {
        if (Health >= 0)
        {
            Health -= damage;
            if (damageeffect != null)
            {
                Instantiate(damageeffect, transform.position + damageEffectPosition, Quaternion.identity, transform);
            }

            if (damageEffectSound != null)
            {
                characterAudio.clip = damageEffectSound;
                characterAudio.Play();
            }
        }

    }

    public virtual void Die()
    {
        if (deathEffectSound != null)
        {
            characterAudio.clip = deathEffectSound;
            characterAudio.Play();
        }
      
        Destroy(gameObject);
    }
}
