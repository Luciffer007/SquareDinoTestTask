using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private ProjectilesManager _projectilesManager;

    private Rigidbody _rigidbody;
    
    void Start()
    {
        _projectilesManager = GameObject.Find("ProjectilesManager").GetComponent<ProjectilesManager>();
    }

    public void Impulse()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        _projectilesManager.AddToPull(gameObject);
    }
}
