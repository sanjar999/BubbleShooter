using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadSceneManager : MonoBehaviour
{

    private List<Action> _list = new List<Action>();

    //Adds call of scene to list of called scenes 
    public void AddSceneTolist(Action action)
    {
        _list.Add(action);
        StartCoroutine(LoadLastScene());
    }
    //Call the last scene in list
    IEnumerator LoadLastScene()
    {
        yield return new WaitForSeconds(.1f);
        _list[_list.Count - 1].Invoke();
        _list.Clear();
    }
}