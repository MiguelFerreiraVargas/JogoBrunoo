using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidade do player
    private Possessable currentTarget; // Guarda o alvo que pode ser possuído

    void Update()
    {
        // Movimento do player
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(moveX, moveY);
        transform.Translate(move * speed * Time.deltaTime);

        // Apertar F para possuir
        if (Input.GetKeyDown(KeyCode.F) && currentTarget != null)
        {
            currentTarget.Possess();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Possessable"))
        {
            currentTarget = other.GetComponent<Possessable>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Possessable"))
        {
            if (currentTarget != null && currentTarget.gameObject == other.gameObject)
            {
                currentTarget = null;
            }
        }
    }
}
