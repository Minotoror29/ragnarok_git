using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private CardDisplay _cardDisplay;

    private PlayerControls _playerControls;

    private bool _mouseDown = false;
    private Vector2 _mousePosition;

    public void Initialize(CardDisplay cardDisplay)
    {
        _cardDisplay = cardDisplay;

        _playerControls = new PlayerControls();
        _playerControls.InGame.Enable();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _mouseDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _mouseDown = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (_mousePosition.x > 0.6f)
        {
            _cardDisplay.PlayCard();
        }
        else if (_mousePosition.x < 0.4f)
        {
            _cardDisplay.DiscardCard();
        }
    }

    private void Update()
    {
        _mousePosition = Camera.main.ScreenToViewportPoint(_playerControls.InGame.MousePosition.ReadValue<Vector2>());

        if (_mouseDown)
        {
            if (_mousePosition.x > 0.6f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -15f);
            } else if (_mousePosition.x < 0.4f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 15f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }
}
