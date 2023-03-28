using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private ProjectilesManager projectilesManager;
    
    [SerializeField]
    private Waypoint[] waypoints;

    [SerializeField] 
    private GameObject bullet;

    [SerializeField] 
    private Transform bulletStartPoint;

    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    private Animator _animator;
    
    private NavMeshAgent _navMeshAgent;
    
    private TouchControls _touchControls;

    private int _currentWaypoint;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        _touchControls = new TouchControls();
        _touchControls.Touch.TouchPress.performed += Fire;
        
        Disable();
    }

    public void Enable()
    {
        enabled = true;
    }
    
    public void Disable()
    {
        enabled = false;
    }
    
    private void OnEnable()
    {
        _touchControls.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
    }

    private void FixedUpdate()
    {
        if (!(Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position) < 0.1))
        {
            return;
        }
        
        if (!waypoints[_currentWaypoint].IsCleared)
        {
            _animator.SetBool(IsRunning, false);
            return;
        }
            
        _currentWaypoint++;
        
        if (_currentWaypoint >= waypoints.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
            
        _animator.SetBool(IsRunning, true);
        _navMeshAgent.SetDestination(waypoints[_currentWaypoint].transform.position);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        // Construct a ray from the current touch coordinates
        Ray ray = Camera.main.ScreenPointToRay(_touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        Physics.Raycast(ray, out RaycastHit hitInfo);

        GameObject bulletObject = projectilesManager.GetFromPull();
        if (bulletObject == null)
        {
            bulletObject = Instantiate(bullet, bulletStartPoint.position, bulletStartPoint.rotation);
        }
        else
        {
            bulletObject.transform.position = bulletStartPoint.position;
            bulletObject.SetActive(true);
        }
        
        bulletObject.transform.LookAt(hitInfo.point);
        bulletObject.GetComponent<Bullet>().Impulse();
    }
}
