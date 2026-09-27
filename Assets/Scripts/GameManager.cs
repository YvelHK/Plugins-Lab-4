using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public bool gameOver = false;

    private InputAction restart;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);

        restart = InputSystem.actions.FindAction("Restart");
        restart.performed += Restart;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }
    }

    void Restart(InputAction.CallbackContext ctx)
    {
        if (gameOver)
        {
            // Unsubscribe from restart and restart the game
            restart.performed -= Restart;
            SceneManager.LoadScene("Week5Lab");
        }
    }
}
