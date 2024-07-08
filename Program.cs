using System;
using System.Collections.Generic;

class Ali
{
    public static void Main()
    {
        Console.WriteLine("This program compares multiple objects in ascending order with the use of Generics.");

        START1:
        Console.WriteLine("\n-------------------------------------------------------\n");

        Console.WriteLine("How many objects do you want to compare?");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("\n-------------------------------------------------------\n");

        if (n < 2)
        {
            Console.WriteLine("Wrong Input! There should be at least 2 objects to be compared.");
            goto START1;
        }
        else
        {
            START2:
            Console.WriteLine("Do you want to compare multiple strings or numbers? (strings/numbers)");
            string obj = Console.ReadLine().ToLower();

            if (obj == "strings")
            {
                List<string> strings = new List<string>();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Enter string {0}: ", i + 1);
                    strings.Add(Console.ReadLine());
                }

                var comparator = new Comparator<string>(strings);
                comparator.Comparison();
            }
            else if (obj == "numbers")
            {
                List<float> numbers = new List<float>();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Enter number {0}: ", i + 1);
                    numbers.Add(float.Parse(Console.ReadLine()));
                }

                var comparator = new Comparator<float>(numbers);
                comparator.Comparison();
            }
            else
            {
                Console.WriteLine("Wrong Input! Please Try Again!");
                Console.WriteLine("\n-------------------------------------------------------\n");
                goto START2;
            }
        }
    }
}

public class Comparator<T> where T : IComparable<T>
{
    private List<T> items;

    public Comparator(List<T> items)
    {
        this.items = items;
    }

    public void Comparison()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("No items to compare.");
            return;
        }

        T min = items[0];
        T max = items[0];

        foreach (T item in items)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        items.Sort();

        Console.WriteLine("The objects in ascending order are: {0}", string.Join(" < ", items));
    }
}