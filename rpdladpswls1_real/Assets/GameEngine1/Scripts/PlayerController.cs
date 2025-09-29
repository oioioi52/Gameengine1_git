using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f; 

    private Animator animator;
    // private Rigidbody2D rb; // Rigidbody2D 변수 제거
    private bool isMoving;
    private bool isJumping;

    void Start()
    {
        animator = GetComponent<Animator>();
        // rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 가져오는 코드 제거

        if (animator != null)
            Debug.Log("Animator 컴포넌트를 찾았습니다!");
        else
            Debug.LogError("Animator 컴포넌트가 없습니다!");
        
        // if (rb == null) // Rigidbody2D 검사 코드 제거
        //     Debug.LogError("Rigidbody2D가 필요합니다!");
    }

    void Update()
    {
        isMoving = false;

        // D키 (오른쪽)
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
            isMoving = true;
        }

        // A키 (왼쪽)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
            isMoving = true;
        }

        // 스페이스바 → 점프 애니메이션 재생 (물리적인 점프X)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animator != null)
            {
                animator.SetBool("isJumping", true);
                Debug.Log("점프!");
                // 점프 애니메이션이 끝나면 자동으로 isJumping을 false로 바꿔줘야 합니다.
                // 이 부분은 애니메이션 이벤트나 다른 방법으로 처리해야 합니다.
            }
        }
        
        // 애니메이션 파라미터 전달
        animator.SetBool("isMoving", isMoving);
    }
}