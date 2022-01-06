using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTestBehaviourScript : MonoBehaviour
{
    private Color32 _startColor;
    private SwitchCondition _switchCondition;
    private bool _stateOn;

    // Start is called before the first frame update
    void Start()
    {
        _startColor = GetComponent<SpriteRenderer>().color;
        _switchCondition = GetComponent<SwitchCondition>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("A"))
        //{
        //    Debug.Log(gameObject.name + ": "+ )
        //}

        if(_switchCondition.On && !_stateOn)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            _stateOn = true;
        }
        if (!_switchCondition.On && _stateOn)
        {
            GetComponent<SpriteRenderer>().color = _startColor;
            _stateOn = false;
        }
    }
}
