using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refills : MonoBehaviour {
    private GameObject RaycastedObj;
    private float rayLength = 10;
    public LayerMask newLayerMask;
    public PlayerVitals playerVitals;
    public Text PickText;
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = playerVitals.gameObject.transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(playerVitals.gameObject.transform.position, fwd, out hit, rayLength, newLayerMask.value))
        {

            if(hit.collider.CompareTag("Collect"))
            {
                PickText.text = "Left Click To Pick";
                RaycastedObj = hit.collider.gameObject;
                if(Input.GetMouseButtonDown(0))
                {
                    ItemProp ThisItem = RaycastedObj.GetComponent<ItemProp>();
                    ThisItem.Interact();
                    // Do Something
                    
                }
            }
        } else
        {
            PickText.text = "";
        }
    }
}
