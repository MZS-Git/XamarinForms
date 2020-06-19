    using System;
    using System.Collections.Generic;

namespace ObjectVsPrimitiveArrays
{
    class Program
    {

        // ZR programming Concepts . Make your root strong through ZR programming concepts else you fall down in Industry...!
        static void Main(string[] args)
        {

            //way1 to declare and intilize array.
            int[] way1Array = new int[5]; //Standard way "First declare the array and then add values"
            way1Array[0] = 1;
            way1Array[1] = 2;
            way1Array[2] = 3;
            way1Array[3] = 4;
            way1Array[4] = 5;

            foreach (int elementsOfArray in way1Array)
            {
                Console.WriteLine(elementsOfArray);
            }

            //------------------------------------------------------------------------------------------------------------------//

            //way2 to declare and intilize array.
            int[] way2Array = { 6, 7, 8, 9, 10 }; //Intilize the elements of array at runtime.Compiler auto generate size of an array by reading elements.

            foreach (int elementsOfArray in way2Array)
            {
                Console.WriteLine(elementsOfArray);
            }
            //------------------------------------------------------------------------------------------------------------------//
            //way3 to declare and intilize array right way in  block style;
            //Trending Approch now-e-days.Must go for it for clean and neat coding practices
            int[] way3Array = new int[5] {//New Approch where we declare , intize the elements in block 
                11,12,13,14,15
            };

            foreach (int elementsOfArray in way3Array)
            {
                Console.WriteLine(elementsOfArray);
            }
            //------------------------------------------------------------------------------------------------------------------//
            //way4 to declare and intilize array right way in  block style without define size of array
            int[] way4Array = new int[] {//New Approch where declare , intize the elements in block
                16,17,18,19,20
            };

            foreach (int elementsOfArray in way4Array)
            {
                Console.WriteLine(elementsOfArray);
            }


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
    }
}
