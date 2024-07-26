using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
        visualGameObject.SetActive(false);
    }

    private void Player_OnSelectedCounterChanged(object sender,Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter ==clearCounter)
        {
            Show();
        }

        else
        {
            Hide();

        }
       // e.selectedCounter
    }

    private void Show()
    {

        visualGameObject.SetActive(true);

    }

    private void Hide()
    {
        visualGameObject.SetActive(false);


    }
}