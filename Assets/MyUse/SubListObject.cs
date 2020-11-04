﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubListObject : MonoBehaviour
{
    public string objName;
    public int index;
    public bool isok;
    public GameObject myParentObj;//我的父级对象

    Button delButton;
    Toggle toggleFlag;
    void Start()
    {
        delButton = this.GetComponentInChildren<Button>();
        delButton.onClick.AddListener(DelButtonClick);
        toggleFlag = this.GetComponentInChildren<Toggle>();
        toggleFlag.onValueChanged.AddListener(ison=>FlagButtonClick());
    }   


    public void setSubObjectInfo(string name, int index,bool isok,GameObject myparnt)
    {
        this.objName = name;
        this.index = index;
        this.isok = isok;
        this.GetComponentInChildren<Toggle>().isOn = this.isok;
        this.GetComponentInChildren<Text>().text = this.objName;
        this.myParentObj = myparnt;
    }

    public void DelButtonClick()
    {
        myParentObj.GetComponent<ListObject>().subListObjects.Remove(this.GetComponent<SubListObject>());
        myParentObj.GetComponent<ListObject>().countSon -= 1;
        Destroy(this.gameObject);
        myParentObj.GetComponent<ListObject>().ButtonClickTreeShow();
    }

    public void FlagButtonClick()
    {
        this.isok = this.GetComponentInChildren<Toggle>().isOn;
        for (int i = 0 ; i < myParentObj.GetComponent<ListObject>().subListObjects.Count ; i++)
        {
            if (myParentObj.GetComponent<ListObject>().subListObjects[i].index == this.index)
            {
                myParentObj.GetComponent<ListObject>().subListObjects[i].isok = this.isok;
            }
        }
    }
}