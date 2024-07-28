using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum tags
{
    MENU,
    PIZZA,
}


public class DraggableObj : MonoBehaviour
{
    [SerializeField] public tags nameTag;

    public string itemID; //identificador del objeto
    public bool pizzaTopping;
    public Transform[] dropAreaPositions;

    private Vector3 dragOffset;
    private Camera cam;

    [SerializeField] private float speed = 10f;
    [SerializeField] private bool itemBeingDragged;
    private bool inDropArea;

    [SerializeField] private GameObject target;

    private Vector2 initialPos;
    public AudioClip PickUpSound;

    private void Awake()
    {
        cam = Camera.main; //reference to main camera 
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePosition();
        itemBeingDragged = true;

        initialPos = transform.position;
        SpawnDraggableObject();

        SoundController.Instance.PlayClip(PickUpSound);
    }


    /// <summary>
    /// Spawnea el objeto que se coge
    /// </summary>
    public void SpawnDraggableObject()
    {
        Instantiate(gameObject, new Vector3(initialPos.x, initialPos.y, 0f), Quaternion.identity);
    }


    /// <summary>
    /// Acciones mientras se hace drag
    /// </summary>
    private void OnMouseDrag()
    {
        if (itemBeingDragged)
        {
            //Move the item towards the position of the mouse
            transform.position = Vector3.MoveTowards(transform.position, GetMousePosition() + dragOffset, speed);
        }
    }

    /// <summary>
    /// Acciones al levantar el click del raton
    /// </summary>
    private void OnMouseUp()
    {
        itemBeingDragged = false;
        if (inDropArea)
        {
            //compruebo si forma parte de los ingredientes de la pizza
            if (pizzaTopping)
            {
                Pizza pizza = target.GetComponent<Pizza>();
                pizza.UpdateSprite(itemID);
                Destroy(gameObject, 0.2f);
            }
            else if (GameManager.Instance.menuItemsCounter < 2) FindAvailablePosition();
            else
            {
                Destroy(gameObject);
            }

            gameObject.GetComponent<Collider2D>().enabled = false;
        } else {
            //destroy the object when dropping outside the drop area
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Obtiene la position del raton
    /// </summary>
    /// <returns></returns>
    Vector3 GetMousePosition()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; //no haria falta, pero por si acaso
        return mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == nameTag.ToString())
        {
            inDropArea = true;
            target = collision.gameObject;

            Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == nameTag.ToString())
        {
            inDropArea = false;
            target = null;
        }
    }


    private void FindAvailablePosition()
    {
        if (target != null)
        {
            dropAreaPositions = target.GetComponentsInChildren<Transform>();
            float distance = 100f;
            Vector3 newPos = Vector3.zero;
            for (int i = 0; i < dropAreaPositions.Length; i++)
            {
                if (dropAreaPositions[i].tag == "Pos" && dropAreaPositions[i] != null &&
                    dropAreaPositions[i].childCount <= 0)
                {
                    float newDistance = Vector2.Distance(dropAreaPositions[i].transform.position, GetMousePosition());
                    if (newDistance < distance)
                    {
                        newPos = dropAreaPositions[i].transform.position;
                        gameObject.transform.parent = dropAreaPositions[i].transform;
                    }

                    Debug.Log("Hay posicion disponible");
                }
            }

            transform.position = newPos;
            GameManager.Instance.menu.Add(itemID);
            GameManager.Instance.menuItemsCounter++; //aumentamos el contador de objetos
        }
    }
}