using UnityEngine;

public class EntityController1 : MonoBehaviour
{
    public Animator anim;
    [Header("Walk Settings")]
    private bool isWalking;

    [Header("Attack Settings")]
    public float attackTime;
    private bool isAttacking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking == true)
        {
        }
        if (isAttacking == true)
        {

        }
    }
}
