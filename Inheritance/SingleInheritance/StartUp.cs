using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Bark();
            dog.Eat();
            //01.SingleInheritance
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
            //02.Multiple Inheritance(task name is wrong tho... the proper way of calling this type of inheritance is transitive inheritance - in C# there is no such thing as multiple inheritance)
            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
            //03.Hierarchical Inheritance
        }
    }
}
