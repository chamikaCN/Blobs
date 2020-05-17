using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLOBS.Assets.Project_Assets.Scripts;
public class PlayerManager : MonoBehaviour
{
    bool playerChanged;

    void Start(){
        GameManager.initialBlobs = FindObjectsOfType<Blob>();
        GameManager.teamAssign();
        playerChanged = false;
    }

    void Update()
    {
        //Blob Movement
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        GameManager.getCurrentBlob().movement(new Vector2(horizontalMove,verticalMove));

        //Blob Change
        if ((Input.GetKey(KeyCode.Z)) && (!playerChanged)){
            changeBlob();
        }

        //Blob Attack
        if (Input.GetKey(KeyCode.Space)){
            GameManager.getCurrentBlob().attack();
        }
    }

    void changeBlob(){
        GameManager.getCurrentBlob().movement(new Vector2(0,0));
        if(GameManager.getPlayerCount()>1){
            GameManager.changeBlob();
            playerChanged = true;
            StartCoroutine(changeReset());
        }
    }

    IEnumerator changeReset(){
        yield return new WaitForSeconds(1f);
        playerChanged = false;
    }
}
