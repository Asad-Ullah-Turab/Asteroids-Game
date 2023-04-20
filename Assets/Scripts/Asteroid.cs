using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// controls behaviour of asteroids
/// </summary>
public class Asteroid : MonoBehaviour
{   // support for random sprite generation
    SpriteRenderer asteroidSpriteRenderer;
    [SerializeField]
    Sprite[] asteroidSpriteArr;

    // support for random force
    Rigidbody2D rb2D;
    const float minForce = 30;
    const float maxForce = 50;
    // Start is called before the first frame update
    void Awake()
    {
        // saved for optimisation
        asteroidSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        ApplyRandomSprite();
        ApplyRandomForce();
    }
    void ApplyRandomSprite()
    {
        int index = Random.Range(0, asteroidSpriteArr.Length);
        asteroidSpriteRenderer.sprite = asteroidSpriteArr[index];
        gameObject.GetComponent<SpriteRenderer>().sprite = asteroidSpriteRenderer.sprite;
    }
    void ApplyRandomForce()
    {
        float force = Random.Range(minForce, maxForce);

        // calculating and converting angle to radians
        float randomAngle = Random.Range(0, 360);
        randomAngle = randomAngle * Mathf.Deg2Rad;

        //applying force in random direction
        Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        rb2D.AddForce(randomDirection * force, ForceMode2D.Force);
    }
}
