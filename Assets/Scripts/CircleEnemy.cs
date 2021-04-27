using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{

    public int health = 100;
    public GameObject deathEffect;
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] postitions;
    private int index;

    public void TakeDamage(int damage){
        health -= damage;
        if(health <= 0){
            Die();
        }
    }

    void Die(){
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, postitions[index], Time.deltaTime * speed);
       if(transform.position == postitions[index]){
           if(index == postitions.Length - 1){
               index = 0;
           }
           else{
               index++;
           }
       }
    }
}
