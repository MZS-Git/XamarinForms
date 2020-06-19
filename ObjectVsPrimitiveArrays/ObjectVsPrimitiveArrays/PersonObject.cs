using System;
namespace ObjectVsPrimitiveArrays
{
    public class PersonObject
    {

        public string First_Name { get; set; }//auto implementation getter and setter

        private string last_Name; //Trending Approch to declare getter Setter.
        public string Last_Name
        {
            get {
                return last_Name;
            }

            set {
                last_Name = value;
            }

        }


        public PersonObject()
        {
            
        }
    }
}
