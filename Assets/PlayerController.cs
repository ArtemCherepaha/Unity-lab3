using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    private Transform myTransform;            
    private Vector3 destinationPosition;        
    private float destinationDistance;          
    public float moveSpeed;                     
    void Start()
    {
        myTransform = transform;                            
        destinationPosition = myTransform.position;         
    }

    void Update()
    {

        destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);

        if (destinationDistance < .5f)
        {
            moveSpeed = 0; 
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        else if (destinationDistance > .5f)
        {
            moveSpeed = 5;
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
        }



        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {
            Plane playerPlane = new Plane(Vector3.up, myTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                destinationPosition = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                myTransform.rotation = targetRotation;
            }
        }

        else if (Input.GetMouseButton(0) && GUIUtility.hotControl == 0)
        {
            Plane playerPlane = new Plane(Vector3.up, myTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                destinationPosition = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                myTransform.rotation = targetRotation;
            }
           
        }
        if (destinationDistance > .5f)
        {
            myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
        }
    }
}

