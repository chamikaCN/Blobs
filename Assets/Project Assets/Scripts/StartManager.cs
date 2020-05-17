using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLOBS.Assets.Project_Assets.Scripts;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour
{
    public void selectTeamBlue(){
        GameManager.setTeamBlue();
        SceneManager.LoadScene("GameScene");
    }

    public void selectTeamOrange(){
        GameManager.setTeamOrange();
        SceneManager.LoadScene("GameScene");
    }
}
