using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum characterClasses
    { Wyk³adowca, Student }

    public enum characterNames
    {
        Dawid,
        Kamil,
        Wiktoria,
        DrInzLukawski,
        MgrInzPieta,
        MgrInzSydoryk,
    }

    public characterNames characterName;
    public characterClasses characterClass;
}