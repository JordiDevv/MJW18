using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public Vector3 pizzaPoint;

    public Transform platePoint;
    public SpriteRenderer spriteRenderer1, spriteRenderer2;
    private Sprite sprite1, sprite2;
    [SerializeField]
    private bool isComplete; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Actualiza el sprite de la pizza
    /// </summary>
    public void UpdateSprite(string spriteName) {

        if (!sprite1) {
            sprite1 = Resources.Load<Sprite>("Sprites/" + spriteName);
            spriteRenderer1.sprite = sprite1;
            return;
            
        } else if(!isComplete) {
            sprite2 = Resources.Load<Sprite>("Sprites/" + spriteName);
            spriteRenderer2.sprite = sprite2;
            isComplete = true;
            StartCoroutine("Move");
        }

        
       
       
    }



    private IEnumerator Move() {

        yield return new WaitForSeconds(0.2f);
        while (transform.position != pizzaPoint) {
        transform.position = Vector3.MoveTowards(transform.position, pizzaPoint, 0.3f);
        yield return new WaitForSeconds(0.08f);
        }
        while (transform.position != platePoint.transform.position) {
            transform.position = Vector3.MoveTowards(transform.position, platePoint.transform.position, 0.3f);
            yield return new WaitForSeconds(0.08f);
        }
    }
}
