using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject prefabBullet;
    [SerializeField] float damage = 5f;
    [SerializeField] float speed = 5f;
    [SerializeField] float liveTime = 5f;
    float count = 0;




    void Update()
    {
        count += Time.deltaTime;
        if (count < liveTime)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var target = collision.collider.gameObject;
        if (target.tag == "Enemy")
        {
            Destroy(gameObject);
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
