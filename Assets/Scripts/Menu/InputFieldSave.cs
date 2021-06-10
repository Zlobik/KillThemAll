using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldSave : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private string _saveName;

    private void Start()
    {
        if (PlayerPrefs.HasKey(_saveName))
            _inputField.text = PlayerPrefs.GetFloat(_saveName).ToString();
    }

    public void OnEndEdit()
    {
        string str = _inputField.text;
        float value = float.Parse(str);
        float result;

        if (float.TryParse(str, out result) && value > 0)
        {
            PlayerPrefs.SetFloat(_saveName, value);
            PlayerPrefs.Save();
            Debug.Log($"{_inputField} saved {value}");
        }
    }
}
