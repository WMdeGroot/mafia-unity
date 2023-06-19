using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool aimPressed = Input.GetMouseButton(1);


        if (aimPressed && !forwardPressed) 
        {
            weapon.SetActive(true);
            Debug.Log("Weapon is true");
        }
        else
        {
            weapon.SetActive(false);
        }
    }
}
