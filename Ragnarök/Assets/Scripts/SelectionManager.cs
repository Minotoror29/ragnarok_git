using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private LayerMask selectableLayer;

    private void Update()
    {
        UpdateLogic();
    }

    public void UpdateLogic()
    {
        CreateRay();
    }

    private void CreateRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, selectableLayer))
        {
            Debug.DrawRay(Camera.main.transform.position, hit.point - Camera.main.transform.position, Color.green);
        }
    }
}
