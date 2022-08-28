using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject prefabBullet;
    
   //[SerializeField] Player player;
    
    [SerializeField] GameObject effect2;


    [SerializeField] float damage = 5f;
    [SerializeField] float speed = 5f;
    [SerializeField] float liveTime = 5f;
    [SerializeField] Player player;
    Vector3 direction;
    float count = 0;
 
    void Start()
    {
       direction = player.transform.forward;
    }


    void Update()
    {
        count += Time.deltaTime;
        if (count < liveTime)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            //transform.position += new Vector3(0,0, transform.position.z + speed * Time.deltaTime) ;
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
            //Instantiate(effect2);
        }
    }
}
