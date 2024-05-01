using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public float speed;
    public Transform moveSpot1;
    public Transform moveSpot2;
    private bool movingToSpot2 = true;
    private bool facingRight = true;

    void Update()
    {
        Transform targetSpot = movingToSpot2 ? moveSpot2 : moveSpot1;
        transform.position = Vector3.MoveTowards(transform.position, targetSpot.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetSpot.position) < 0.2f)
        {
            movingToSpot2 = !movingToSpot2;
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x = Mathf.Abs(theScale.x) * (facingRight ? 1 : -1);
        transform.localScale = theScale;
    }
}
