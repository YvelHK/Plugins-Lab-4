using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;

    private PlayerInput input;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Lock movement instead of wraparound to not break cinemachine
        Vector2 move = input.GetMoveInput();
        if (Mathf.Abs(transform.position.x) > horizontalScreenLimit && (move.x > 0 == transform.position.x > 0))
            move.x = 0;
        if (Mathf.Abs(transform.position.y) > verticalScreenLimit && (move.y > 0 == transform.position.y > 0))
            move.y = 0;

        transform.Translate(move * Time.deltaTime * speed);
    }
}
