using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool isPressed;
    private float releaseDelay;
    private float maxDragDistance = 2f;

    private Rigidbody2D rb;
    private SpringJoint2D sj;
    private Rigidbody2D slingrb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        releaseDelay = 1 / (sj.frequency * 4);
        slingrb = sj.connectedBody;
    }
    void Update()
    {
        if (isPressed)
        {
            DragBall();
        }
    }
    private void DragBall()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.position = mousePosition;
        float distance = Vector2.Distance(mousePosition, slingrb.position);
        if (distance > maxDragDistance)
        {
            Vector2 direction = (mousePosition - slingrb.position).normalized;
            rb.position = slingrb.position + direction * maxDragDistance;
        }
        else
        {
            rb.position = mousePosition;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(new Vector2(-2f, -2f));
        Debug.Log("Collide");
    }
}
