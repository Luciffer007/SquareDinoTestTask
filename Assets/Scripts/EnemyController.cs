using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    public bool IsAlive { get; private set; }

    private Animator _animator;

    private void Awake()
    {
        IsAlive = true;
        
        _animator = GetComponent<Animator>();
    }
    
    public void Hit()
    {
        if (!IsAlive)
        {
            return;
        }
        
        _animator.enabled = false;
        IsAlive = false;
    }
}
