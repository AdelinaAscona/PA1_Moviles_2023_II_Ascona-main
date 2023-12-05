using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    public GameObject panel; // Referencia al panel

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf); // Activa o desactiva el panel
    }
}
