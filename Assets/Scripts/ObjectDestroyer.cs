using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public int hits = 2;
    public int points = 5;
    void Update()
    {
        if(Input.GetMouseButtonUp (0))
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 250f));

            Vector3 direction = worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;

            if(Physics.Raycast(Camera.main.transform.position, direction, out hit, 250f))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);

                if(hit.collider.gameObject.tag == "DesctructibleItem")
                {
                    hits--;

                    if(hits <- 0)
                    {
                        GameManager.Instance.Score += points;
                        Destroy (hit.collider.gameObject);
                    }
                }
            }

            else
            {
                Debug.DrawLine(Camera.main.transform.position, worldMousePosition , Color.red, 0.5f);
            }
        }
        
    }
}
