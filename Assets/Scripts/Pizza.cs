using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private Sprite sprite;
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
        sprite = Resources.Load<Sprite>("Sprites/" + spriteName);
        spriteRenderer.sprite = sprite;
       Debug.Log(sprite);
    }
}
