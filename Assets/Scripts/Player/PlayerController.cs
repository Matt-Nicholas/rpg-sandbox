using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int ControllerID;
    
    //public GameObject player
    [SerializeField] Animator animator;
    float _attackTime;
    float _animCounter;

    float _timeSinceMove;
    [SerializeField] private int _moveSpeed;
    private float _moveDelay = 0.05f;
    private float _moveStartTime;
    private float _moveDistance;
    private Vector3 _moveEndPoint = new Vector3();
    private bool _moved;
    //float playerHeight = 1;
    //float playerwidth = 1;


    private void Start()
    {
        
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;    //Get Animator controller
        for(int i = 0; i < ac.animationClips.Length; i++)                 //For all animations
        {
            if(ac.animationClips[i].name == "hero1_f_attack")        //If it has the same name as your clip
            {
                _attackTime = ac.animationClips[i].length;
            }
        }
    }

    void Update () { 

        // fsm needed here
        // if is dead...
        // else if is being attacked...
        // else if is attacking...
        if(Input.GetButtonDown("Fire1"))
        {
            PerformAttack();
        }
        if(_animCounter <= Time.deltaTime)
        {
            animator.SetBool("attacking", false);
        }
        else
        {
            _animCounter -= Time.deltaTime;
        }
        // else if is walking...
        GetInput();


    }

    private void FixedUpdate()
    {
        HandelMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Interactable"))
        {
            GameObject interactedObject = collision.gameObject;
            Interactable interactable = interactedObject.GetComponent<Interactable>();
            interactable.Interact();
        }
    }

    void PerformAttack()
    {
        animator.SetBool("attacking", true);
        _animCounter = _attackTime + Time.deltaTime;
    }

    void HandelMovement()
    {
                // else if is interacting...
        // Distance moved = time * speed.
        float distCovered = (Time.time - _moveStartTime) * _moveSpeed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / _moveDistance;

        // Set our position as a fraction of the distance between the markers.
        if(_moved && fracJourney != float.NaN)
            transform.position = Vector3.Lerp(transform.position, _moveEndPoint, fracJourney);
        /*ransform.position = */

    }

    void GetInput()
    {
        if(_timeSinceMove < _moveDelay)
        {
            _timeSinceMove += Time.deltaTime;
            return;
        }

        float horizontalInput = InputManager.MainHorizontal(ControllerID);
        float verticalInput = InputManager.MainVertical(ControllerID);

        float verticalMovement = 0f;
        float horizontalMovement = 0f;

        _moved = true;
        if(Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput) && Mathf.Abs(horizontalInput) > 0.2)
        {
            horizontalMovement = (float)0.5 * Mathf.Sign(horizontalInput);
        }
        else if(Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput) && Mathf.Abs(verticalInput) > 0.2)
        {
            verticalMovement = (float)0.5 * Mathf.Sign(verticalInput);
        }
        else
        {
            _moved = false;
        }

        if(_moved)
        {
            _timeSinceMove = 0;
            // Keep a note of the time the movement started.
            _moveStartTime = Time.time;
            // Calculate the journey length.
            _moveEndPoint = new Vector3(transform.position.x + horizontalMovement, transform.position.y + verticalMovement);
            _moveDistance = Vector3.Distance(transform.position, _moveEndPoint);

            //transform.position = new Vector3(transform.position.x + horizontalMovement, transform.position.y + verticalMovement);
        }
    }

    public void MoveToNextCsreen(Vector2 movement)
    {
        transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, transform.position.z);
    }
}
