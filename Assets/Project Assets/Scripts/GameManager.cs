using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace BLOBS.Assets.Project_Assets.Scripts
{
    public static class GameManager{
        static List<Blob> playerBlobs, enemyBlobs;
        public static Blob[] initialBlobs;
        static Blob currentBlob;
        static int playerCount,enemyCount,currentPlayerBlobIndex;
        static string playerTeam,enemyTeam;

        public static void teamAssign(){
        //just for testing////////////////////////////////////////////
        GameManager.setTeamOrange();
        //////////////////////////////////////////////////////////////

        int initialBlobsSize = initialBlobs.Length;
        playerBlobs = new List<Blob>();
        enemyBlobs = new List<Blob>();

        for (int i = 0; i < initialBlobsSize; i++)
        {
            if (initialBlobs[i].gameObject.name == GameManager.getTeam())
            {
                playerBlobs.Add(initialBlobs[i]);
                }
            else
            {
                enemyBlobs.Add(initialBlobs[i]);
            }
            initialBlobs[i].setID(i);
        }
        
        playerCount = playerBlobs.Count;
        enemyCount = enemyBlobs.Count;
        currentBlob = playerBlobs[2];
        currentPlayerBlobIndex = 2 ;
        currentBlob.GetComponent<NPC>().setPlayerControl();
        //testShow(playerBlobs);
        //currentBlob.changeSelector();
        //Debug.Log("change1");
        //changeBlob();
        //Debug.Log("change2");
        }

        public static void changeBlob(){
            //currentBlob.changeSelector();
            currentBlob.GetComponent<NPC>().resetPlayerControl();
            if(playerCount>1){
                if ((currentPlayerBlobIndex + 1) == playerCount){
                    currentBlob = playerBlobs[0];
                    currentPlayerBlobIndex = 0;
                }else{
                    currentBlob = playerBlobs[currentPlayerBlobIndex+1];
                    currentPlayerBlobIndex += 1;
                }
            }else if(playerCount == 1){
                currentBlob = playerBlobs[0];
                currentPlayerBlobIndex = 0;
            }
            currentBlob.GetComponent<NPC>().setPlayerControl();
            //currentBlob.changeSelector();
            //Debug.Log(playerCount + "players present");
        }

        public static Blob getCurrentBlob(){
            return currentBlob;
        }

        public static void setTeamBlue(){
            playerTeam = "BlueBlob";
            enemyTeam = "OrangeBlob";
        }
        public static void setTeamOrange(){
            playerTeam = "OrangeBlob";
            enemyTeam = "BlueBlob";
        }
        public static string getTeam(){
            return playerTeam;
        }

        public static void destroyCheck(Blob blob){
            if(blob == GameManager.getCurrentBlob()){
                if(playerCount > 1){
                    playerBlobs.Remove(currentBlob);
                    playerCount -= 1;
                    GameManager.changeBlob();
                }else{
                    SceneManager.LoadScene("GameScene");
                }
            }else if(blob.GetComponent<NPC>().getTeam() == getTeam()){
                playerBlobs.Remove(blob);
                playerCount -= 1;
            }
            Debug.Log(playerCount + " players present");
        }

        public static string getEnemyTeam(){
            return enemyTeam;
        }

        public static int getPlayerCount(){
            return playerCount;
        }

        public static void testShow(List<Blob> blobList){
            foreach (var blob in blobList)
            {
                Debug.Log(blob.name + blob.getID());
            }
        }

    }
}