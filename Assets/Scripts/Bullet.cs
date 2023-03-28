using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private ProjectilesManager _projectilesManager;

    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _projectilesManager = GameObject.FindWithTag("ProjectilesManager").GetComponent<ProjectilesManager>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        _projectilesManager.AddToPull(gameObject);
    }
    
    public void Impulse()
    {
        _rigidbody.velocity = transform.forward * speed;
    }
}
