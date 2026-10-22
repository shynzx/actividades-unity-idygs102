using UnityEngine;

public class ImpulsoPelota : MonoBehaviour
{
    public float fuerza = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * fuerza, 
                ForceMode.Impulse);
        }
    }
}
