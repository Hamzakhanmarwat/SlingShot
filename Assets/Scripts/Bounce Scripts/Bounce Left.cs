using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceLeft : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    public float speedChange;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.velocity += new Vector2(speedChange * -1f, 0);
    }
}
