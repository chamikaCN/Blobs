using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    string team,enemy;

    Vector2[] vectors;

    Vector2 currentDirection,enemyPosition;

    bool directionChanged,enemyDetected,playerControlled;

    void Start()
    {
        vectors = new Vector2[4]{Vector2.down, Vector2.up, Vector2.right, Vector2.left};
        directionChanged = false;
        enemyDetected = false;
        playerControlled = false;
        team = this.gameObject.name;
        if(team == "BlueBlob"){
            enemy = "OrangeBlob";
        }else if(team == "OrangeBlob"){
            enemy = "BlueBlob";
        }
    }

    void Update()
    {
        if(!playerControlled){
            RandomMovement();
            if(enemyDetected){
                this.GetComponent<Blob>().attack();
                //AttackRangeCheck();
            //}else if(enemyDetected){
            }
        }
    }

    public string getTeam(){
        return team;
    }

    public string getEnemy(){
        return enemy;
    }

    public void RandomMovement(){
        if(!directionChanged){
        int randnum = getRandom();
        this.GetComponent<Blob>().movement(vectors[randnum]);
        directionChanged = true;
        StartCoroutine(directionChange());
        }
    }

    public void Chase(){
        this.GetComponent<Blob>().movement(enemyPosition);
        this.GetComponent<Blob>().attack();
    }

    // public void AttackRangeCheck(){
    //     RaycastHit2D attackRay = Physics2D.Raycast(transform.position,Vector2.up,2f);
    //     Debug.DrawRay(transform.position,Vector2.up*2f,Color.yellow);
    //     if(attackRay.collider != null){
    //         Debug.Log(attackRay.collider.name);
    //         if(attackRay.collider.name == "OrangeBlob" || attackRay.collider.name == "BlueBlob" ){
    //             enemyDetected = true;
    //             enemyPosition = attackRay.collider.gameObject.transform.position;
    //         }
    //     }

    // }

    public void EnemyDetection(){
        enemyDetected = true;
    }

    public void EnemyLost(){
        enemyDetected = false;
    }

    int getRandom(){
        System.Random rnd = new System.Random();
        int num  = rnd.Next(0, 4);
        return num;
    }

    public void setPlayerControl(){
        //Debug.Log("enemy set" + name);
        playerControlled = true;
    }

    public void resetPlayerControl(){
        //Debug.Log("enemy reset" + name);
        playerControlled = false;
    }

    IEnumerator directionChange(){
        yield return new WaitForSeconds(0.5f);
        directionChanged = false;
    }
}
