using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.layer);
        Destroy(collision.gameObject);
    }
}
