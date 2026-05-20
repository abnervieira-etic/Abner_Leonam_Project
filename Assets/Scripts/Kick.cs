using System.Collections;
using Unity.Mathematics;
using UnityEngine;


public class Kick : MonoBehaviour
{
       public KeyCode kickKey = KeyCode.J;
    [SerializeField] GameObject feet;
    [SerializeField] Quaternion target;

    Quaternion initial;

    Quaternion currentTarget; 
    Animator animator;
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
        if (Input.GetKeyDown(kickKey))
        {
            StopAllCoroutines();
            StartCoroutine(KickDelay());
            
        }
    }

    IEnumerator KickDelay()
    {
        currentTarget = target;
        print("triggered");
        yield return new WaitForSeconds(0.5f);

        currentTarget = initial;
        
    }

}
