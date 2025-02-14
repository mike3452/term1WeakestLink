using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public List<Target> targets;
    private int currentTargetIndex = 0;
    private Camera mainCamera;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Auto-select the highest HP target
        SelectHighestHPTarget();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CycleToNextTarget();
        }

      

        if (targets.Count > 0)
        {
            mainCamera.transform.LookAt(targets[currentTargetIndex].transform);
        }
    }

    void SelectHighestHPTarget()
    {
        if (targets.Count == 0) return;

        Target highestHPTarget = targets.OrderByDescending(t => t.HP).First();
        currentTargetIndex = targets.IndexOf(highestHPTarget);
        FaceTarget(highestHPTarget);
    }

    void CycleToNextTarget()
    {
        if (targets.Count == 0) return;

        currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
        FaceTarget(targets[currentTargetIndex]);
    }

    void FaceTarget(Target target)
    {
        mainCamera.transform.LookAt(target.transform);
    }
}