using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 backViewOffset = new Vector3(0, 5, -10);
    public Vector3 frontViewOffset = new Vector3(0, 3, 5);
    public float smoothSpeed = 0.125f;
    public float moveSpeed = 5f; // velocidade de movimento manual da câmara

    private bool isFrontView = false;

    void LateUpdate()
    {
        // Alternar entre vista frontal e traseira
        if (Input.GetKeyDown(KeyCode.V))
            isFrontView = !isFrontView;

        // Escolher o offset da vista atual
        Vector3 currentOffset = isFrontView ? frontViewOffset : backViewOffset;
        Vector3 desiredPosition = player.position + player.transform.TransformDirection(currentOffset);

        //movimento da câmara leve
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Fazer a câmara olhar para o carro
        transform.LookAt(player);

        // Movimento manual da câmara 
        float moveX = Input.GetAxis("Horizontal"); // ← →
        float moveY = 0f;

        //  controlam altura
        if (Input.GetKey(KeyCode.O))
            moveY = 3f;
        else if (Input.GetKey(KeyCode.P))
            moveY = -3f;

        // Usa Translate para mover a câmara no espaço local
        transform.Translate(new Vector3(moveX, moveY, 0f) * moveSpeed * Time.deltaTime);
    }
}