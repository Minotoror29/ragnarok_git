using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    [SerializeField] private LayerMask selectableLayer;

    private ISelectable _currentSelection;

    private TableTurnState _currentState;

    public void Enable(TableTurnState state)
    {
        _playerControls = new PlayerControls();
        _playerControls.InGame.Enable();
        _playerControls.InGame.LeftClick.performed += ctx => Select();

        _currentState = state;
    }

    public void UpdateLogic()
    {
        CreateRay();
    }

    private void CreateRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(_playerControls.InGame.MousePosition.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayer))
        {
            ISelectable selection = hit.transform.GetComponent<ISelectable>();
            if (selection != null)
            {
                _currentSelection = selection;
                Debug.DrawRay(Camera.main.transform.position, hit.point - Camera.main.transform.position, Color.green);
            }
        } else
        {
            _currentSelection = null;
        }
    }

    private void Select()
    {
        if (_currentSelection == null) return;

        _currentSelection.Select(_currentState);
    }

    public void Disable()
    {
        _playerControls.InGame.Disable();
        _playerControls.InGame.LeftClick.performed -= ctx => Select();

        _currentState = null;
    }
}
