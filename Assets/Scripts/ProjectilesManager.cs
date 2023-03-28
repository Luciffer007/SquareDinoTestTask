using System.Collections.Generic;
using UnityEngine;

public class ProjectilesManager : MonoBehaviour
{
    private Stack<GameObject> _projectilesPull;
    
    private void Awake()
    {
        _projectilesPull = new Stack<GameObject>();
    }

    public GameObject GetFromPull()
    {
        if (_projectilesPull.Count != 0)
        {
            GameObject projectile = _projectilesPull.Pop();
            projectile.transform.parent = null;
            return projectile;
        }

        return null;
    }
    
    public void AddToPull(GameObject projectile)
    {
        projectile.transform.parent = transform;
        projectile.transform.position = Vector3.zero;
        _projectilesPull.Push(projectile);
    }
}
