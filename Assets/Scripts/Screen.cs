using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {

    public int tileKey;
    public BoxCollider2D col;

    void Update()
    {

    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    // if both players are touching the next screen
    //    if(true)
    //    {
    //        col.enabled = false;
    //        // move players into this screen 
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag != "Player") return;

    //    ScreenManager.Instance.ScreenToEnter = this;
        
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.tag != "Player")
    //    {
    //        if(collision.tag == "Projectile")
    //            Destroy(collision.gameObject);

    //        return;
    //    }

        //if(ScreenManager.Instance.CurrentScreen  != ScreenManager.Instance.ScreenToEnter)
        //{
        //    ScreenManager.Instance.LoadScreen();
        //}

        //col.enabled = true;
    //}

}
