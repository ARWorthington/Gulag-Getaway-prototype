using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform focusObject;
    public bool isInCombatCamera;

    // Start is called before the first frame update
    void Start()
    {
        isInCombatCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        isInCombatCamera = CharacterController.isInCombat;

        if(isInCombatCamera == false)
        {
            transform.position = new Vector3(focusObject.position.x, transform.position.y, transform.position.z);
        }
        

    }

    

}
