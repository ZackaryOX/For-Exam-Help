using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton 
{
    ////////////////////////////////////////////////////////////////////////////////
    //STEP 1/4 FOR SINGLETON:
    //make sure that theres an object of the class, it can be public if you want but
    //make sure it is STATIC
    ////////////////////////////////////////////////////////////////////////////////
    private static Singleton CurrentInstance;

        

    ////////////////////////////////////////////////////////////////////////////////
    //STEP 2/4 FOR SINGLETON:
    //make the constructor private so no objects can be made outside of the "Singleton" class
    ////////////////////////////////////////////////////////////////////////////////
    private Singleton()
    {

    }

    ////////////////////////////////////////////////////////////////////////////////
    //STEP 3/4 FOR SINGLETON:
    //have a PUBLIC STATIC FUNCTION that returns an instance, the first time its ran it will be null, and
    //it will create an object of the class and store it in the static variable made above
    //after that it shouldn't equal null so it will just return the static object of the class "Singleton"
    ////////////////////////////////////////////////////////////////////////////////
    public static Singleton GetInstance()
    {
        if(CurrentInstance == null)
        {
            CurrentInstance = new Singleton();
        }
        return CurrentInstance;
    }
    ////////////////////////////////////////////////////////////////////////////////
    //STEP 4 IS ON THE "ForSeph" DOCUMENT
    ////////////////////////////////////////////////////////////////////////////////
}
