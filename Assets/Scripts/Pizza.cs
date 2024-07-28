using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public Vector3 pizzaPoint;

    public SpriteRenderer spriteRenderer1, spriteRenderer2;
    private Sprite sprite1, sprite2;
    [SerializeField] private bool isComplete;
    Vector3 TablePos => new(5, -3.37f, 0);

    Vector3 platePoint = new(-3.95f, -3.3f, -0.08f);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveTo(where: TablePos));
    }


    IEnumerator MoveTo(Vector3 where)
    {
        while (transform.position != where)
        {
            transform.position = Vector3.MoveTowards(transform.position, where, 0.7f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Actualiza el sprite de la pizza
    /// </summary>
    public void UpdateSprite(string spriteName)
    {
        if (!sprite1)
        {
            sprite1 = Resources.Load<Sprite>("Sprites/" + spriteName);
            spriteRenderer1.sprite = sprite1;
            GameManager.Instance.menu.Add(spriteName);
            return;
        }
        else if (!isComplete)
        {
            sprite2 = Resources.Load<Sprite>("Sprites/" + spriteName);
            spriteRenderer2.sprite = sprite2;
            isComplete = true;
            GameManager.Instance.menu.Add(spriteName);
            StartCoroutine("Move");
        }
    }


    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.2f);
        while (transform.position != pizzaPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, pizzaPoint, 0.3f);
            yield return new WaitForSeconds(0.04f);
        }

        while (transform.position != platePoint)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, platePoint, 0.3f);
            yield return new WaitForSeconds(0.04f);
        }
    }
}