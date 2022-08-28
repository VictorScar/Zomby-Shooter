using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Bullet bullet;
    [SerializeField] GameObject muzzle;
    [SerializeField] new Camera camera;
    [SerializeField] int reloadSpeed = 3;
    [SerializeField] int magazineСapacity = 30;
    int quantityOfCartridges;

    //float count;


    //Поворот !
    //Стрельба !
    //Смерть

    void Start()
    {
        Game.GameInstance.Player = this;
        quantityOfCartridges = magazineСapacity;
        //camera = Camera.main;
    }

    void Update()
    {

        Vector3 direction = Input.mousePosition - camera.WorldToScreenPoint(transform.position); // Нахождение катетов для расчёта тангенса, а в последствии и градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        transform.rotation = Quaternion.AngleAxis(90 - angle, Vector3.up);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public override void Attack()
    {

        if (quantityOfCartridges > 0)
        {
            Bullet instBullet = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
            quantityOfCartridges--;
        }
        else
        {
            StartCoroutine(Reloading());
        }
    }

    IEnumerator Reloading()
    {
        Game.GameInstance.ReloadingText.SetActive(true);
        yield return new WaitForSeconds(reloadSpeed);
        Game.GameInstance.ReloadingText.SetActive(false);
        quantityOfCartridges = magazineСapacity;
    }
}
