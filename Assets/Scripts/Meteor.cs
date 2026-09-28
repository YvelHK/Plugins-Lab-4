using Unity.Cinemachine;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] int HP;
    private int hitCount = 0;

    CinemachineImpulseSource impulse;
    private void Start()
    {
        impulse = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.5f);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }

        if (hitCount >= HP)
        {
            impulse.GenerateImpulse(0.2f * HP); // Multiplies by HP so larger meteors shake the screen more
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }
}
