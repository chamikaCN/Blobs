using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLOBS.Assets.Project_Assets.Scripts;

public class Ball : MonoBehaviour
{
    public float speed;
    Vector2 direction;

    private void Start() {
        speed = 10f;
        direction = transform.parent.GetComponent<Blob>().getMovingDirection();
    }
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void setDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!(other.gameObject.name == transform.parent.gameObject.name))
        {
            if (other.gameObject.name != "Vision")
            {
                if (other.gameObject.tag == "Blob")
                {
                    other.gameObject.GetComponent<Blob>().getDamage();
                }
                Destroy(this.gameObject);
            }
        }
        
    }
    
    

}
