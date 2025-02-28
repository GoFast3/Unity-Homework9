using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter: ClickSpawner {
    [SerializeField]
    [Tooltip("How many points to add to the shooter, if the laser hits its target")]
    int pointsToAdd = 1;
    PhotonView view;

    // A reference to the field that holds the score that has to be updated when the laser hits its target.
    NumberField scoreField;  

    private void Start() {
        view = GetComponent<PhotonView>();  
        scoreField = GetComponentInChildren<NumberField>();
        if (!scoreField)
            Debug.LogError($"No child of {gameObject.name} has a NumberField component!");
    }

    protected override GameObject spawnObject() {
        if(view.IsMine){
            GameObject newObject = base.spawnObject();  // base = super

            // Modify the text field of the new object.
            ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
            if (newObjectScoreAdder)
                newObjectScoreAdder.SetScoreField(scoreField).SetPointsToAdd(pointsToAdd);

            return newObject;
        }
        else{return null;}
    }
}
