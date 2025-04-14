using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float laneDistance = 3f;
    public float jumpForce = 8f;
    public float gravity = -20f;
    public float laneChangeSpeed = 10f;
    public float slideDuration = 1f;
    public Transform PlayerBody;

    private CharacterController controller;
    private int currentLane = 1;
    private float verticalVelocity;
    private bool isSliding = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            currentLane = Mathf.Max(0, currentLane - 1);
        else if (Input.GetKeyDown(KeyCode.A))
            currentLane = Mathf.Min(2, currentLane + 1);

        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (currentLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (currentLane == 2)
            targetPosition += Vector3.right * laneDistance;

        Vector3 move = Vector3.zero;
        move.x = (targetPosition - transform.position).x * laneChangeSpeed;

        if (controller.isGrounded)
        {
            verticalVelocity = -1f;

            if (Input.GetKeyDown(KeyCode.W))
                verticalVelocity = jumpForce;

            if (Input.GetKeyDown(KeyCode.S) && !isSliding)
                StartCoroutine(Slide());
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        move.y = verticalVelocity;

        controller.Move(move * Time.deltaTime);
    }

    IEnumerator Slide()
    {
        isSliding = true;

        controller.height = 1f;
        controller.center = new Vector3(0, 0.5f, 0);

        if (PlayerBody != null)
        {
            PlayerBody.localScale = new Vector3(1f, 0.5f, 1f);
            PlayerBody.localPosition = new Vector3(0f, 0.5f, 0f);
        }

        yield return new WaitForSeconds(slideDuration);

        controller.height = 2f;
        controller.center = new Vector3(0, 1f, 0);

        if (PlayerBody != null)
        {
            PlayerBody.localScale = new Vector3(1f, 1f, 1f);
            PlayerBody.localPosition = new Vector3(0f, 1f, 0f);
        }

        controller.Move(Vector3.up * 0.1f);

        isSliding = false;
    }
}