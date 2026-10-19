using UnityEngine;
using UnityEngine.InputSystem; // Required for the new Input System

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Animator anim;

    public ParticleSystem actionParticle;

    private float moveInput;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        moveInput = 0f;
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            moveInput = -1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            moveInput = 1f;
        }

        transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime);

        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            anim.SetTrigger("ActionTrigger");

            if (actionParticle != null)
            {
                actionParticle.Play();
            }
        }
    }
}