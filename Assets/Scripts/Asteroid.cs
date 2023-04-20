using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// controls behaviour of asteroids
/// </summary>
public class Asteroid : MonoBehaviour
{
    SpriteRenderer asteroidSpriteRenderer;
    [SerializeField]
    Sprite[] asteroidSpriteArr;
    // Start is called before the first frame update
    void Awake()
    {
        asteroidSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ApplyRandomSprite();
    }
    void ApplyRandomSprite()
    {
        int index = Random.Range(0, asteroidSpriteArr.Length);
        asteroidSpriteRenderer.sprite = asteroidSpriteArr[index];
        gameObject.GetComponent<SpriteRenderer>().sprite = asteroidSpriteRenderer.sprite;
    }
}
