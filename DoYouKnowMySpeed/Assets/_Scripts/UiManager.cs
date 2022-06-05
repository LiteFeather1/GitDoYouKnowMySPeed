using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private InformationAboutSpeed[] _info;
    private List<TMP_InputField> _fields = new List<TMP_InputField>();
    private int _currenField;

    void Start()
    {
        for (int i = 0; i < _info.Length; i++)
        {
            for (int x = 0; x < _info[i].SpeedsInput.Length; x++)
            {
                _fields.Add(_info[i].SpeedsInput[x]);
            }
        }

        _fields[_currenField].ActivateInputField();
        _fields[_currenField].image.color = Color.gray;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && _currenField < _fields.Count)
        {
            _currenField++;
            _fields[_currenField].ActivateInputField();
            _fields[_currenField -1].image.color = Color.white;
            _fields[_currenField].image.color = Color.gray;
        }
    }

    public void ButtonCheck()
    {
        for (int i = 0; i < _info.Length; i++)
        {
            for (int x = 0; x < _info[i].SpeedsInput.Length; x++)
            {
                if (_info[i].SpeedsInput[x].text == _info[i].Speeds[x].ToString())
                {
                    _info[i].SpeedsInput[x].image.color = Color.green;
                }
                else
                {
                    _info[i].SpeedsInput[x].image.color = Color.red;
                }
            }
        }
    }
    public void ButtonReset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}

[System.Serializable]
public struct InformationAboutSpeed
{
    [SerializeField] private string _veiculo;
    [SerializeField] private int[] _speeds;
    [SerializeField] private TMP_InputField[] _speedsInput;

    public TMP_InputField[] SpeedsInput { get => _speedsInput; }
    public int[] Speeds { get => _speeds; }
}
