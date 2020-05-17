using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLOBS.Assets.Project_Assets.Scripts;

public class EnemyDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == this.gameObject.GetComponentInParent<NPC>().getEnemy()){
            this.gameObject.GetComponentInParent<NPC>().EnemyDetection();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == this.gameObject.GetComponentInParent<NPC>().getEnemy()){
            this.gameObject.GetComponentInParent<NPC>().EnemyLost();
        }
    }
}
