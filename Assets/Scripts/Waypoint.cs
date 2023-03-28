using System.Linq;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private EnemyController[] enemies;

    public bool IsCleared
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
}
