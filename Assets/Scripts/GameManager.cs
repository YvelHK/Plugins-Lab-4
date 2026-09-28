using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public bool gameOver = false;

    private InputAction restart;
    [SerializeField] CinemachineCamera cinemachineCamera;

    // Start is called before the first frame update
    void Start()
    {
        Transform player = Instantiate(playerPrefab, transform.position, Quaternion.identity).transform;
        cinemachineCamera.Follow = player;
        GetComponent<EnemySpawner>().SpawnEnemies();

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
