using System.Collections;
using System.Collections.Generic;
//sum of 2 nums

//Console.WriteLine("Enter 1st number");
//int num1 = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter 2nd number");
//int num2 = int.Parse(Console.ReadLine());

//Console.WriteLine($"Sum of nums = {num1 + num2}");


//vowels in a string

//Console.WriteLine("Enter the String : ");
//string str = Console.ReadLine();

//int vowelcount = 0;

//foreach (char c in str)
//{
//    if ("aeiou".Contains(c))
//    {
//        vowelcount++;
//    }
//}
//Console.WriteLine(vowelcount);


//Console.WriteLine("Enter the String : ");
//string str = Console.ReadLine();
//int vowelcount = 0;

//for (int i = 0; i < str.Length; i++)
//{
//    char c = str[i];
//    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
//    {
//        vowelcount++;
//        Console.WriteLine(c);
//    }
//}
//Console.WriteLine(vowelcount);





//using Microsoft.VisualBasic;


// print a list
//List<string> names = new List<string> { "fara", "izzah", "faizy", "zaru" };
//foreach (string name in names)
//{
//    Console.WriteLine(name);
//}

//List<string> names = new List<string> { "fara", "izzah", "faizy", "zaru" };
//for (int i = 0; i < names.Count; i++)
//{
//    Console.WriteLine(names[i]);
//}



//Array - type safe but not resizable

//Non generic -- auto resize but not type safe
//Arraylist,Hash table


//Hashtable
//Hashtable ht =new Hashtable();
//ht.Add("Id",1010);
//ht.Add("Ename","fara");
//ht.Add("job","developer");
//ht.Add("Phone",123456789);
//ht.Add("Location","Kerala");

//Console.WriteLine(ht["Phone"]);
//Console.WriteLine("Id".GetHashCode());//that s why avlues are dont get in the same sequence which we gave

//foreach(Object key in ht.Keys)
//    Console.WriteLine(key +":"+ht[key]);


//Generic -- tyoe safe and auto resizing
//List
//List<string> str =new List<string>();

//public class Customer
//{
//    public string Name { get; set; }
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//}
//List<Customer> cus = new List<Customer>();




//List<int> li = new List<int>();
//li.Add(10);
//li.Add(20);
//li.Add(30);

//for(int i = 0; i < li.Count; i++)
//{
//    Console.WriteLine(li[i]);
//}

//li.Insert(3, 35);
//li.RemoveAt(3);
//    foreach(int i in li)
//    Console.WriteLine(i);
