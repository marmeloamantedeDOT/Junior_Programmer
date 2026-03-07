using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float jumpForce = 30f;
    public float boostMultiplier = 2f;
    public float scaleStep = 0.2f;  // quanto o tamanho muda
    public Color[] colors;

    private Rigidbody rb;
    private Renderer rend;
    private int colorIndex = 0;
    private bool isGrounded = true;
    float h, v;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // Movimento
        Vector3 move = transform.forward * v * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // Rotação (só se estiver a mover) 
        if (Mathf.Abs(v) > 0.01f)
        {
            float direction = v > 0 ? 1f : -1f;
            Quaternion deltaRot = Quaternion.Euler(0f, h * turnSpeed * Time.fixedDeltaTime * direction, 0f);
            rb.MoveRotation(rb.rotation * deltaRot);
        }

        // Nitro (pressionar N)
        if (Input.GetKey(KeyCode.N))
            speed = 2f; // dobro da velocidade
        else
            speed = 1f;

        // Salto (pressionar Espaço)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
        }

        // Mudar cor (pressionar C)
        if (Input.GetKeyDown(KeyCode.C) && colors.Length > 0)
        {
            colorIndex = (colorIndex + 1) % colors.Length;
            rend.material.color = colors[colorIndex];
        }

        //Mudar tamanho (pressionar com +/-)
        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            transform.localScale += new Vector3(scaleStep, scaleStep, scaleStep);
        }
        if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            transform.localScale -= new Vector3(scaleStep, scaleStep, scaleStep);

            // Impede o carro de ficar invisvel
            if (transform.localScale.x < 0.2f)
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }

    // Deteta se o carro tocou no chão
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}

