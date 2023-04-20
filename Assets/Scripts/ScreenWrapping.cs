using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{
    // screen wrapping support
    float colliderRadius;

    // Start is called before the first frame update
    void Start()
    {   if(gameObject.GetComponent<CircleCollider2D>())
        {
            colliderRadius = GetComponent<CircleCollider2D>().radius;
        }
        else if(gameObject.GetComponent<BoxCollider2D>())
        {
            colliderRadius = GetComponent<BoxCollider2D>().size.x / 2;
        }
    }

    /// <summary>
    /// Called when the game object becomes invisible to the camera
    /// </summary>
    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        // check left, right, top, and bottom sides
        if (position.x + colliderRadius < ScreenUtils.ScreenLeft ||
            position.x - colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y - colliderRadius > ScreenUtils.ScreenTop ||
            position.y + colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // screen wrap
        transform.position = position;
    }
}
