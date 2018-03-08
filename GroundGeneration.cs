using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGeneration : MonoBehaviour
{

    public int width = 10;
    public int height = 10;

    public GameObject Ground;

    public static float ToSingle(double value)
    {
        return (float)value;
    }

    void Start()
    {
        float spriteWidth = this.Ground.GetComponent<SpriteRenderer>().bounds.size.x;
        float spriteHeight = this.Ground.GetComponent<SpriteRenderer>().bounds.size.y;

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                var pos = new Vector2((float)(spriteWidth * w), (float)(spriteHeight * h));
                GameObject Ground = Instantiate(this.Ground, pos, Quaternion.identity) as GameObject;

                pos = new Vector2((float)(spriteWidth * w + (spriteWidth / 2)), (float)(spriteHeight * h + (spriteHeight / 2)));
                GameObject Ground2 = Instantiate(this.Ground, pos, Quaternion.identity) as GameObject;
            }
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero
           );

            if (hit.collider != null)
            {
                hit.collider.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}