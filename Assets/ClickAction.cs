using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    public Texture2D cursorHover;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject currentState, nextState;
    public Animator transition;

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorHover, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    private void OnMouseDown()
    {
        StartCoroutine(ImageTransition());
    }

    IEnumerator ImageTransition()
    {
        
        transition.SetTrigger("in");
        yield return new WaitForSeconds(0.6f);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        currentState.SetActive(false);
        nextState.SetActive(true);
    }
}