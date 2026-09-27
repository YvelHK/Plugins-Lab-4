using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;

    private bool canShoot = true;

    private PlayerInput input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        if (input.GetShooting() && canShoot)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canShoot = false;
            StartCoroutine("Cooldown");
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
