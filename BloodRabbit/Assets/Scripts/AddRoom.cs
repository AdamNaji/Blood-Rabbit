﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    void Start()
    {

        templates.rooms.Add(this.gameObject);
    }
}
