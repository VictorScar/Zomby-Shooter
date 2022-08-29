using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Bullet bullet;
    [SerializeField] GameObject muzzle;
    [SerializeField] PlayerInputs playerInputs;
    [SerializeField] int reloadSpeed = 3;
    [SerializeField] int magazineСapacity = 30;
    public event Action OnPlayerDie;
    int quantityOfCartridges;
    bool isBlockedInputs = false;

    void Start()
    {
        Game.GameInstance.Player = this;
        quantityOfCartridges = magazineСapacity;
    }

    void Update()
    {
        characterAnimator.Play("assault_combat_idle");
        if (!isBlockedInputs)
        {
            Rotation();

            if (playerInputs.PressFire())
            {
                Attack();
            }
        }
        
        if (Health <= 0)
        {
            Die();
        }
        Game.GameInstance.UIScreen.ShowQuantityCartridge(quantityOfCartridges);
    }

    void Rotation()
    {
        Quaternion direction = playerInputs.GetDirection();
        if (direction != null)
        {
            transform.rotation = direction;
        }

    }

    public override void Attack()
    {

        if (quantityOfCartridges > 0)
        {
            Bullet instBullet = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
            quantityOfCartridges--;
            characterAnimator.Play("assault_combat_shoot");
            characterAudio.clip = attackEffectSound;
            characterAudio.Play();
        }
        else
        {
            StartCoroutine(Reloading());
        }
    }

    IEnumerator Reloading()
    {
        isBlockedInputs = true;
        Game.GameInstance.UIScreen.ShowReloading(true);
        characterAnimator.Play("assault_combat_shoot_burst");
        yield return new WaitForSeconds(reloadSpeed);
        Game.GameInstance.UIScreen.ShowReloading(false);
        quantityOfCartridges = magazineСapacity;
        isBlockedInputs=false;
    }

    public override void Die()
    {
        isBlockedInputs = true;
        base.Die();
        OnPlayerDie();
    }
}
