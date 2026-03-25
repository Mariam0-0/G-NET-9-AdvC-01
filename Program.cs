using System.ComponentModel;
using System.Numerics;
using System.Reflection.Emit;

namespace G_NET_9_AdvC_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question 01
            //==================================================
            //Q1: What is a generic class? Why use generics?
            //==================================================

            // Generics allow you to define type-safe classes, interfaces, methods, and delegates
            // without committing to a specific data type until the code is used.

            // Generics are used to avoid the problems of duplicating code or the boxing/unboxing of using an object
            // so using generics was the solution to it with better performance, code reusability and type safety
            #endregion

            #region Question 02
            //==================================================
            //Q2: Write a generic class Container<T> with Add and Get methods.
            //==================================================

            //internal class Container<T>
            //{
            //    private List<T> list = new List<T>();

            //    public void Add(T item)
            //    {
            //        list.Add(item);
            //    }

            //    public T Get(int index) 
            //    { 
            //        return list[index];
            //    }
            //}
            #endregion

            #region Question 03
            //==================================================
            //Q3:What are multiple type parameters? Write Pair<TKey, TValue>.
            //==================================================

            // multiple type parameters are for when we want the generic class to deal with 2 or more different data types

            //internal class Pair<TKey, TValue> 
            //{
            //    public TKey Key { get; set; }
            //    public TValue Value { get; set; }

            //    public Pair(TKey key, TValue value)
            //    {
            //        Key = key;
            //        Value = value;
            //    }
            //}
            #endregion

            #region Question 04
            //==================================================
            //Q4: What is a generic method? Write Swap<T> method.
            //==================================================

            // A generic method declares its own type parameter(s).
            // It can exist in both generic and non-generic classes. The compiler often infers the type argument.

            //public static void Swap<T>(ref T x, ref T y)
            //{
            //    T temp = x;
            //    x = y;
            //    y = temp;
            //}
            #endregion

            #region Question 05
            //==================================================
            //Q5: Write a generic method FindMax<T> that finds maximum value
            //==================================================

            //public static T FindMax<T>(T x, T y) where T : IComparable<T>
            //{
            //    T max;
            //    if(x.CompareTo(y) < 0)
            //        max = y;
            //    else
            //        max = x;

            //    return max;
            //}

            #endregion

            #region Question 06
            //==================================================
            //Q6: What is a generic interface? Write IRepository<T>.
            //==================================================

            // Generic interfaces define contracts with type parameters. Classes implementing them specify the actual types.

            //public interface IRepository<T> 
            //{
            //    T? GetById(int id);
            //    IEnumerable<T> GetAll();
            //    void Add(T entity);
            //    void Update(T entity);
            //    void Delete(int id);
            //}
            #endregion

            #region Question 07
            //==================================================
            //Q7: What is the 'struct' constraint? Write an example.
            //==================================================


            //Constraints restrict which types can be used as type arguments.
            //This enables you to call specific methods on the type parameter.

            // 'struct' constraint only allows T that is a value type (int, double, etc.)

            // this class only allows value type variable like numbers
            //public class PointProcessor<T> where T : struct
            //{
            //    private T x;
            //    private T y;

            //    public PointProcessor(T x, T y)
            //    {
            //        this.x = x;
            //        this.y = y;
            //    }

            //    public T GetX() => x;
            //    public T GetY() => y;

            //    public string GetCoordinates() => $"({x}, {y})";
            //}

            //var intPoint = new PointProcessor<int>(10, 20);

            //var doublePoint = new PointProcessor<double>(3.14, 2.71);

            //// this will throw an error (will not compile)
            //var stringPoint = new PointProcessor<string>("a", "b"); // error: string is a reference type
            #endregion

            #region Question 08
            //==================================================
            //Q8: What is the 'class' constraint? Write an example.
            //==================================================

            // 'class' constraint only allows reference types as T

            //public class Cache<T> where T : class
            //{
            //    private T? _cachedItem;

            //    public T? Get() => _cachedItem;

            //    public void Set(T item)
            //    {
            //        _cachedItem = item;
            //    }

            //    public void Clear()
            //    {
            //        _cachedItem = null; 
            //    }

            //    public bool IsSame(T other)
            //    {
            //        return ReferenceEquals(_cachedItem, other);
            //    }
            //}

            //var cache = new Cache<string>();  // works fine
            //var invalidcache = new Cache<int>(); // ERROR
            #endregion

            #region Question 09
            //==================================================
            //Q9: What is the 'new()' constraint? Write an example.
            //==================================================

            // where T : new() requires T to have a public parameterless constructor.
            // This allows you to create instances of T inside the generic code.

            //public class Factory<T> where T : new()
            //{
            //    public T Create()
            //    {
            //        return new T(); // can create instance because of new() constraint
            //    }
            //}

            //public class Person
            //{
            //    public string Name { get; set; }
            //}

            //var personFactory = new Factory<Person>();
            //var person = personFactory.Create();
            //person.Name = "Mariam";
            #endregion

            #region Question 10
            //==================================================
            //Q10:  What is the interface constraint? Write an example.
            //==================================================

            // where T : IInterface requires T to implement a specific interface. This enables calling interface methods on type parameter.

            //public class Printer<T> where T : IPrintable
            //{
            //    public void Print(T item)
            //    {
            //        item.Print();
            //    }
            //}

            //public interface IPrintable
            //{
            //    void Print();
            //}

            //public class Document : IPrintable
            //{
            //    public void Print() => Console.WriteLine("Printing document...");
            //}

            //public class Photo : IPrintable
            //{
            //    public void Print() => Console.WriteLine("Printing photo...");
            //}

            //var printer = new Printer<Document>();

            //var photoPrinter = new Printer<Photo>();

            //// this would not compile:
            //public class NotPrintable { }
            //var badPrinter = new Printer<NotPrintable>(); // Compile ERROR

            #endregion

            #region Question 11
            //==================================================
            //Q11: What is the base class constraint? Write an example.
            //==================================================

            // the base class constraint is where T must inherit from BaseClass
            // meaning that T has to be a class that inherites the base class, like in this example
            // we can use AnimalProcessor with objects that inherits from Animal class

            //public class AnimalProcessor<T> where T : Animal
            //{
            //    public void Process(T animal)
            //    {
            //        animal.MakeSound();
            //        animal.Eat();
            //    }
            //}

            //public class Animal
            //{
            //    public virtual void MakeSound() => Console.WriteLine("Some sound");
            //    public virtual void Eat() => Console.WriteLine("Eating...");
            //}

            //public class Dog : Animal
            //{
            //    public override void MakeSound() => Console.WriteLine("Woof!");
            //    public override void Eat() => Console.WriteLine("Eating dog food...");
            //}

            //public class Cat : Animal
            //{
            //    public override void MakeSound() => Console.WriteLine("Meow!");
            //    public override void Eat() => Console.WriteLine("Eating cat food...");
            //}

            //var dogProcessor = new AnimalProcessor<Dog>();
            //dogProcessor.Process(new Dog()); 

            //var catProcessor = new AnimalProcessor<Cat>();
            //catProcessor.Process(new Cat()); 


            //public class Car { }
            //var carProcessor = new Processor<Car>(); // Compile error
            #endregion

            #region Question 12
            //==================================================
            //Q12: How do you apply multiple constraints? Write an example.
            //==================================================

            // you have to write them in order of what is the primary constraints and the rest will be secondary constraints 

            // in this example the 'class' constraint is the primary meaning that it has to be written first
            // and the class must apply all constraints to avoid compile errors

            //public class Manager<T> where T : class, IEmployee, new()
            //{
            //    public T CreateEmployee(string name)
            //    {
            //        var employee = new T();           
            //        employee.Name = name;              
            //        employee.HireDate = DateTime.Now;
            //        return employee;                   
            //    }

            //    public void PrintInfo(T employee)
            //    {
            //        Console.WriteLine($"{employee.Name} - Hired: {employee.HireDate:d}");
            //    }
            //}
            //public interface IEmployee
            //{
            //    string Name { get; set; }
            //    DateTime HireDate { get; set; }
            //}

            //public class Developer : IEmployee
            //{
            //    public string Name { get; set; }
            //    public DateTime HireDate { get; set; }

            //}
            #endregion

            #region Question 13
            //==================================================
            //Q13: What does the 'default' keyword do in generics?
            //==================================================

            // default(T) or default returns the default value for type T: null for reference types, 0/false for value types.
            // so if a method return 'default' it will return 0 for int, false for bool, null fro string, etc.
            #endregion

            #region Question 14
            //==================================================
            //Q14: Write a SafeList<T> that returns default when the index is invalid.
            //==================================================

            #endregion

            #region Question 15
            //==================================================
            //Q15: What is covariance? Explain the 'out' keyword.
            //==================================================

            #endregion

            #region Question 16
            //==================================================
            //Q16: What is contravariance? Explain the 'in' keyword.
            //==================================================

            #endregion

            #region Question 17
            //==================================================
            //Q17: What is the difference between covariance and contravariance?
            //==================================================

            #endregion

            #region Question 18
            //==================================================
            //Q18: How do static members work in generic types?
            //==================================================

            #endregion

            #region Question 19
            //==================================================
            //Q19: How can you inherit from a generic class?
            //==================================================

            #endregion

            #region Question 20
            //==================================================
            //Q20: Complete Exercise - Create a generic Cache<TKey, TValue>with Add, Get, Remove, Contains, and expiration support.
            //==================================================

            #endregion

        }
    }
}
