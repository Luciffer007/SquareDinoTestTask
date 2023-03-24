using System.Linq;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private EnemyController[] enemies;

    public bool isCleared
    {
        get
        {
            if (enemies == null || enemies.All(enemy => !enemy.IsAlive))
            {
                return true;
            }

            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
