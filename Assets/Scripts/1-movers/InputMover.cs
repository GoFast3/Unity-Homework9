using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;


/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class InputMover: MonoBehaviour {
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;
    PhotonView view;
    [SerializeField] InputAction move = new InputAction(
        type: InputActionType.Value, expectedControlType: nameof(Vector2));

    private void Start()
    {
     view = GetComponent<PhotonView>();   
    }
    void OnEnable()  {
        move.Enable();
    }

    void OnDisable()  {
        move.Disable();
    }

    void Update() {
        if(view.IsMine){
            Vector2 moveDirection = move.ReadValue<Vector2>();
            Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
            transform.position += movementVector;
            //transform.Translate(movementVector);
            // NOTE: "Translate(movementVector)" uses relative coordinates - 
            //       it moves the object in the coordinate system of the object itself.
            // In contrast, "transform.position += movementVector" would use absolute coordinates -
            //       it moves the object in the coordinate system of the world.
            // It makes a difference only if the object is rotated.
        }
    }
}
