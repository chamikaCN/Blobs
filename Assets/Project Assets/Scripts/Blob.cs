using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLOBS.Assets.Project_Assets.Scripts;

public class Blob : MonoBehaviour
{
    public GameObject ball;
    GameObject selector;
    Vector2 movingDirection;
    int health,id;
    bool fired = false;
    Blob myBlob;

    private void Start() {
        health = 2;
        myBlob = this;
        selector = this.transform.GetChild(2).gameObject;
        selector.SetActive(false);
    }

    public void renderSort(){
        this.gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)(this.transform.position.y*-100);
    }

    public void movement(Vector2 newDirection){
        this.GetComponent<Rigidbody2D>().velocity = newDirection;
        if((newDirection != movingDirection) && (newDirection!=Vector2.zero)){
            movingDirection = newDirection;
        }
        renderSort();
    }

    public void attack(){
        if(!fired){
            Instantiate(ball ,transform.position,Quaternion.identity,this.transform); 
            fired = true;
            StartCoroutine(attackReset());  
        }
    }
    IEnumerator attackReset(){
        yield return new WaitForSeconds(2f);
        fired = false;
    }

    public void getDamage(){
        health = health - 1;
        if (health == 1){
            this.transform.localScale = new Vector2(1.5f,1.5f);
        }
        else if(health == 0){
            GameManager.destroyCheck(this);
            Destroy(this.gameObject);
        }
    }

    public Vector2 getMovingDirection(){
        return movingDirection;
    }

    public void changeSelector(){
        //Debug.Log(selector.activeInHierarchy);
        if (selector.activeInHierarchy == true)
        {
            selector.SetActive(false);
        }
        else
        {
            selector.SetActive(true);
        }
    }

    public void setID(int i){
        this.id = i;
    }

    public int getID(){
        return id;
    }
    


}
