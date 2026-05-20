using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class KickAnim : MonoBehaviour
{
    public KeyCode kickKey = KeyCode.J;
    [SerializeField] GameObject feet;
    [SerializeField] GameObject attackGM;
    [SerializeField] Quaternion target;
    [SerializeField] float kickDelay;

    Quaternion initial;

    Quaternion currentTarget; 
    [SerializeField] Animator animator;
    void Awake()
    {
        initial = transform.rotation;
        currentTarget = initial;
    }
    void Update()
    {
        var step = 4 * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, currentTarget, step*800);
        DoKick();
    }

    async void DoKick()
    {

        if (Input.GetKey(kickKey))
        {
            currentTarget = target;
        }

        if (Input.GetKeyUp(kickKey))
        {
            StartCoroutine(KickDelay());

            Attack();
        }
        
    }
    
    IEnumerator KickDelay()
    {
        currentTarget = target;
        yield return new WaitForSeconds(kickDelay);

        currentTarget = initial;
        
    }

    void Attack()
    {
        animator.SetTrigger("attack");
    }
}
