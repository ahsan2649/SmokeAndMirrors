using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool _on;
    private bool _turnable;
    private string _buttonKey = "Fire1";

    public List<GameObject> Switchables;
    public GameObject Button;

    private HoldButton _switchButton;

    private Color32 _offColour = Color.red;
    private Color32 _onColour = Color.green;


    // Start is called before the first frame update
    void Start()
    {
        _switchButton = Button.gameObject.GetComponent<HoldButton>();

        //this code adds the switch to the switchCondition and has to be taken out if 1 switch on is enough to have a light on:
        foreach (GameObject switchable in Switchables)
        {
            switchable.GetComponent<SwitchCondition>().AddToTarget(1);
        }

        Button.SetActive(false);

        SetVisualKeyForState();
    }

    private void SetVisualKeyForState()
    {
        if (_on)
        {
            GetComponent<SpriteRenderer>().color = _onColour;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = _offColour;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_turnable)
        {
            if (_switchButton.CheckInput(_buttonKey))
            {
                _on = !_on;
                //foreach switchable, notify 1 switch on/off
                foreach (GameObject switchable in Switchables)
                {
                    if (_on)
                        switchable.GetComponent<SwitchCondition>().AddOneTowardsTarget();
                    else
                        switchable.GetComponent<SwitchCondition>().RemoveOneTowardsTarget();
                }
                SetVisualKeyForState();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        //show button to use
        Button.SetActive(true);
        //check for input
        _turnable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        //stop show button to use
        Button.SetActive(false);
        //stop check for input
        _turnable = false;
    }
}