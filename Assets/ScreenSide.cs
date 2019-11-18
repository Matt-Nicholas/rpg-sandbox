using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSide : MonoBehaviour {

    [SerializeField] private Vector2 _movement;
    [SerializeField] private Vector2 _camMovement;
    public bool BothPlayersTouching;
    public List<PlayerController> players = new List<PlayerController>();


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.transform.CompareTag("Player") /* || If we are at the edge of the world */)
        {
            return;
        }

        players.Add(collision.transform.gameObject.GetComponent<PlayerController>());

        float xDiff = Mathf.Sign(transform.position.x - collision.transform.position.x);
        float yDiff = Mathf.Sign(transform.position.y - collision.transform.position.y);


        if(players.Count == 2)
        {
            CameraController.Instance.Move(new Vector2(_camMovement.x * xDiff, _camMovement.y * yDiff));

            foreach(PlayerController pc in players)
            {
                pc.MoveToNextCsreen(new Vector2(_movement.x * xDiff, _movement.y * yDiff));
            }
            players.Clear();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(!collision.transform.CompareTag("Player") /* || If we are at the edge of the world */)
        {
            return;
        }

        PlayerController pc = collision.transform.gameObject.GetComponent<PlayerController>();

        for(int i = 0; i < players.Count; i++)
        {
            if(pc == players[i])
            {
                players.Remove(pc);
            }
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
