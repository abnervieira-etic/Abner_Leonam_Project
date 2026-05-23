using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    private float timer;
    private const float interval = 10f;
    public GameObject activeModifier;
    public static ModifierManager instance;
    void Awake()
    {
      instance = this;  
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            // ele so vai ativa se o anterior foi atingido
            if (activeModifier == null || !activeModifier.activeInHierarchy)
            {
                timer = 0f;
                activeModifier = OBJpooler.Instance.PullObject(OBJpooler.Instance.spawnPos);
            }
        }
    }
}
