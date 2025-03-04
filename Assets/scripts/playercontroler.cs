using UnityEngine;

public class GexController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float runMultiplier = 1.5f;

    private Rigidbody2D rb;
    private Animator anim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Движение
        float speed = moveX * moveSpeed * (isRunning ? runMultiplier : 1f);
        rb.linearVelocity= new Vector2(speed, rb.linearVelocity.y);

        // Анимации
        anim.SetFloat("Speed", Mathf.Abs(speed));
        anim.SetBool("isRunning", isRunning);

        // Поворот персонажа
        if (moveX > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        // Атака
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        //take 
        if (Input.GetKeyDown(KeyCode.E))
        {
            Take();
        
        }
            
    }

    void Attack()
    {   
        // Запуск анимации атаки
        anim.SetTrigger("Attack");
    }

    void Take() {
        // anim take
        anim.SetTrigger("Take");
    }
}