using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ConfirmTargetDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI confirmText;

    private Player _targetedPlayer;

    private UnityAction<Player> _confirmAction;
    private UnityAction _declineAction;

    public void SetText(string cardName, string playerName)
    {
        confirmText.text = "Utiliser " + cardName + " sur " + playerName + " ?";
    }

    public void SetTargetedPlayer(Player player)
    {
        _targetedPlayer = player;
    }

    public void SetButtons(UnityAction<Player> confirmAction, UnityAction declineAction)
    {
        _confirmAction = confirmAction;
        _declineAction = declineAction;
    }

    public void Confirm()
    {
        _confirmAction.Invoke(_targetedPlayer);
    }

    public void Decline()
    {
        _declineAction.Invoke();
    }
}
