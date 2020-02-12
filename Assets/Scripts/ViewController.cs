using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewController : MonoBehaviour
{
    public GameObject[] allState;
    public Animator transition;
    public Texture2D cursorHover;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public TMP_Text title;

    public void changeState(GameObject nextView)
    {
        StartCoroutine(ImageTransition(nextView));
    }

    public void MouseEnter()
    {
        Cursor.SetCursor(cursorHover, hotSpot, cursorMode);
    }

    public void MouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    IEnumerator ImageTransition(GameObject nextState)
    {

        transition.SetTrigger("in");
        yield return new WaitForSeconds(0.6f);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        for (int i = 0; i < allState.Length; i++)
        {
            allState[i].SetActive(false);
        }
        nextState.SetActive(true);
    }

    public void changeTitle(TMP_Text Title)
    {
        title.text = Title.text;
    }
}
