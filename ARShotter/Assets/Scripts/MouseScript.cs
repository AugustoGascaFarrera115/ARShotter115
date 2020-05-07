using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public Texture2D cursorTexture;

    private CursorMode mode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;

    public GameObject mousePoint;
    private GameObject instanteatedMouse;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, mode);

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;


            if (Physics.Raycast(ray, out rayHit))
            {
                if (rayHit.collider is TerrainCollider)
                {
                    Vector3 temporal_position = rayHit.point;
                    temporal_position.y = 0.25f; //0.35f


                    if (instanteatedMouse == null)
                    {
                        instanteatedMouse = Instantiate(mousePoint) as GameObject;
                        instanteatedMouse.transform.position = temporal_position;
                    }
                    else
                    {
                        Destroy(instanteatedMouse);
                        instanteatedMouse = Instantiate(mousePoint) as GameObject;
                        instanteatedMouse.transform.position = temporal_position;
                    }



                }
            }
        }

    }
}
