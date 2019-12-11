using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

////////////////////////////////////////////////////////////////////////////////BEGIN STATE STEP 1/3
//STEP 1 FOR STATE PATTERN:
//Make a PUBLIC Enum. If you dont know what an enum is, its basically a container of ints (in order from 0 to however many you make), 
//each one gets their own custom name and its treated like an object, to access them type "StateEnums" followed by a "." and you
//should be able to access them. 

public enum StateEnums
{
    WALKSTATE, 
    ENDSTATE,
    BEGINSTATE
}
////////////////////////////////////////////////////////////////////////////////END STATE STEP 1/3
public class ForSeph : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////BEGIN STATE STEP 2/3
    //STEP 2 FOR STATE PATTERN:
    //Create an object of the enum you just created, this is where it may become tricky to understand. When you create an object
    //of the enum it stores only one type of the different values you stored inside when you initially created the enum. 
    //This will be your state, later on we will create a switch statement that compares this value(remember, an enum stores
    //a bunch of different values, by using our object that only stores one of these values we can compare them) 

    StateEnums CurrentState = StateEnums.BEGINSTATE;
    ////////////////////////////////////////////////////////////////////////////////END STATE STEP 2/3


    ////////////////////////////////////////////////////////////////////////////////BEGIN DLL STEP 1/2
    //STEP 1 FOR DLL:
    //Make sure you drag the DLL file into unity(into the files, ie where scripts are at the bottom of unity)
    //then you can access it, make sure the strings name is the same as the files name.


    //Now create a const string, set this equal to the name of the file name(no extention) in quoatation marks,
    const string DLL_Import = "TestDLL";

    //To import the function from the DLL(you will need to do this for EACH function you want to bring over
    //from the DLL) use the "[]" brackets and inside of them type "DllImport(name of your const string from above)"
    //this may erro initially, make sure write "using System.Runtime.InteropServices;" or for press ALT and ENTER
    //while your cursor is next to the "DllImport" (this method will only work if you wrote "DllImport" correctly, its
    //case sensitive(CAPTIAL AND NON CAPITALS MATCH)
    [DllImport(DLL_Import)]
    //after this type the function you wish to copy, make sure the tags before it are "public", "static", and "extern"
    //followed by the return type of the function(should be the same as in C++, in our case its "int").
    public static extern int TestFunc();
    ////////////////////////////////////////////////////////////////////////////////END DLL STEP 1/2
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ////////////////////////////////////////////////////////////////////////////////BEGIN SINGLETON STEP 4/4
        //STEP 4 FOR SINGLETON PATTERN:
        //Create an object of the class "Singleton" and set it equal to the function we made in the other class 
        //To access the singleton functions that we made, type the class "Singleton" name in followed by "." to access
        //the "GetInstance()" function. 
        Singleton temobj1 = Singleton.GetInstance();
        ////////////////////////////////////////////////////////////////////////////////END SINGLETON STEP 4/4
     


        ////////////////////////////////////////////////////////////////////////////////BEGIN STATE STEP 3/3
        //STEP 3 FOR STATE:
        //Create a switch statement, a switch statement basically tests a variable's value that you send through.
        //To use a switch statement you must first write "switch" followed by "(variable to test)" and to end it off
        //use "{}" inside of that you will want to write the case it is set up like by typing "case" followed by the
        //value that it must be equal to in order to run the case and then a ":", after that type the code you want to 
        //happen when the value is equal to, to finish it off type "break" followed by ";".
        //So in our case we will want to test the state's value, we can reference the values we want our "CurrentState"
        //to equal by typing the enum's name "StateEnums" followed by "." and the value you want. 
        //each state should have a way of going back to the default state, you will want to make conditions for the states
        //to change, you wont ever want a state to get stuck.
        switch (CurrentState)
        {
            case StateEnums.BEGINSTATE:
                //stuff for begin state
                if(Input.GetKey(KeyCode.W))
                {
                    CurrentState = StateEnums.WALKSTATE;
                }
                break;
            case StateEnums.ENDSTATE:
                //stuff for end state
                break;
            case StateEnums.WALKSTATE:
                //stuff for walk state
                if (!Input.GetKey(KeyCode.W))
                {
                    CurrentState = StateEnums.BEGINSTATE;
                }
                break;
        }
        ////////////////////////////////////////////////////////////////////////////////END STATE STEP 3/3



        Debug.Log(CurrentState);
        ////////////////////////////////////////////////////////////////////////////////BEGIN DLL STEP 2/2
        //STEP 
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(TestFunc());
        }
        ////////////////////////////////////////////////////////////////////////////////END DLL STEP 2/2
    }
}
