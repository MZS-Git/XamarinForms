using System;
using System.Collections.Generic;

namespace ObjectTypeArrays{

class Program{

static void Main(string[] args){

// ZR programming Concepts . Make your root strong through ZR programming concepts else you fall down in Industry...!
           
        //OLD Traditions Approch
        List<PersonObject> personObjectList = new List<PersonObject>();//List  of PersonObject type.
                                                                        //First declare Array then create Object of class to access properties then intialize the array through object

        PersonObject obj1 = new PersonObject();
        obj1.First_Name = "Old Tradition";
        obj1.Last_Name = "First create Object and then access object properties";
        personObjectList.Add(obj1);
        Console.WriteLine("\nApproch: " + obj1.First_Name + "\nProcedure: " + obj1.Last_Name);

        //New Trending Approch
        List<PersonObject> personObjectListTrendingList = new List<PersonObject>() {
            new PersonObject{
                First_Name = "Trending Approch",
                Last_Name = "After Declaration , Intialize the list through block. Complex to see But helpful in code cleaness." +
                "But to iterate these elements Loop is required."
            }
        };

        foreach (PersonObject element in personObjectListTrendingList)
        {
            Console.WriteLine("\nApproch: " + element.First_Name + "\nProcedure: " + element.Last_Name);
        }


        //Traditional Approch of Object Array
        List<PersonObject> personObjectTraditionalList = new List<PersonObject>();
        personObjectTraditionalList.Add(new PersonObject()
        {
            First_Name = "Traditional Approch",
            Last_Name = "Here we directly insert the object reference in List, " +
                        "rather then storing object reference in seprate varible and then add to list"
        });


        foreach (PersonObject element in personObjectTraditionalList)
        {
            Console.WriteLine("\nApproch: " + element.First_Name + "\nProcedure: " + element.Last_Name);
        }
    }
}//class
}//namespace
