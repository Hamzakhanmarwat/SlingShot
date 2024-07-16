using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceNeg135 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    public float speedChange;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        speedChange = Mathf.Pow(speedChange, 0.5f);
        Debug.Log(speedChange);
        player.velocity += new Vector2(speedChange * 1f, speedChange * -1f);
    }
}
