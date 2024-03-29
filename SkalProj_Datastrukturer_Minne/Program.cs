﻿using System;
using System.Collections;
using System.Diagnostics;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            List<string> theList = new List<string>();
            Console.WriteLine("Type +/- to add or remove phrase, 0 to quite");
            bool wannaType = true;
            //Answer question 2 and 3
            //Capacity of list starts with 4 when the first element added in
            //if the number of elements in the list exceeds this capacity
            //the list will expand, doubling its size, exponentially
            //Answer question 4
            //The capacity doesn't increase at the same rate as element are added because
            //it is unnecessary and expensive. When list capacity increases, it will copy 
            //all elements to a new arrary and increase the internal array. It is not 
            //performance optimized, especially for large lists. 
            //Answer question 5
            //The capacity of list didn't decrease when elements are removed from the list. 
            //Answer question 6
            //It is better to use array instead of list when we know exactly how many elements
            //will be store and no dynmaic changes of capacity needed.

            while (wannaType)
            {
                string input = Console.ReadLine() ?? "";
                ArgumentException.ThrowIfNullOrEmpty(input);
                char nav = input[0];//add or remove or quite            
                switch (nav)
                {
                    //left 
                    case '0':
                        wannaType = false;
                        break;
                    //add input to the list
                    case '+':
                        if (input.Length > 2)
                        {
                            string value = input.Substring(1);
                            theList.Add(value);
                            Console.WriteLine("Current list capacity: " + theList.Capacity);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input,add somethng after +");
                        }

                        break;
                    //remove input from the list
                    case '-':
                        if (input.Length > 2)
                        {
                            string value1 = input.Substring(1);
                            Console.WriteLine(theList.Remove(value1));
                            Console.WriteLine("Current list size: " + theList.Count);
                            Console.WriteLine("Current list capacity: " + theList.Capacity);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input,add somethng after -");
                        }

                        break;
                    default:
                        Console.WriteLine("Write +/- with words or 0");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue icaQueue = new();
            Console.WriteLine("Type 1 to add some one to the queue, 2 to remove and 0 to leave");
            bool wannaType = true;
            while (wannaType)
            {
                string input = Console.ReadLine() ?? "";
                ArgumentException.ThrowIfNullOrEmpty(input);
                char nav = input[0];
                switch (nav)
                {
                    case '0':
                        wannaType = false;
                        break;
                    case '1':
                        //Enqueue
                        string pQueue = Console.ReadLine() ?? "";
                        if (!string.IsNullOrEmpty(pQueue))
                        {
                            icaQueue.Enqueue(input);
                            Console.WriteLine("Current Quese Size:" + icaQueue.Count);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                        break;
                    case '2':
                        //Dequeue
                        icaQueue.Dequeue();
                        Console.WriteLine("Current Quese Size:" + icaQueue.Count);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            }

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            //F: Why it is not smart to use a stack instead for Queue
            //S: Queue is "FiFO", just like how queue works in real life. 
            //And since Stcak follow a FILO(Fist In Last Out) order, the last element will be the first one removed.
            //In the case of ica, it is unreasonable to use a stack.

            //reverse the string
            Console.WriteLine("Type in the phrase which you want to reverse!");
            string input = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Write Something");
            }
            else
            {
                //use stack to reverse
                Stack stack = new Stack();
                foreach (char c in input)
                {
                    stack.Push(c);
                }
                string output = "";
                //use foreach to traverse the stack or use while(stack.Count > 0)
                foreach (var item in stack)
                {
                    output += item;

                }
                Console.WriteLine(output);
            }

        }

        static void CheckParanthesis()
        {
          
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            //Use stack to implement this kind of first in and last out logic.
            bool wannaType = true;
            Console.WriteLine("Press 1 to Check parenthesis,press 0 to quit");
            string input = Console.ReadLine() ?? "";
            ArgumentException.ThrowIfNullOrEmpty(input);
            char choice = input[0];
            while (wannaType)
            {
                switch (choice)
                {
                    case '1':
                        CheckForClosure();
                        break;
                    case '0':
                        wannaType = false;
                        break;
                    default:
                        Console.WriteLine("Invaid input");
                        break;
                }
            }
        }
        static void CheckForClosure()
        {
            Dictionary<char, char> values = new Dictionary<char, char>{
                        { ')','(' },
                        { '}','{' },
                        { ']','[' }
            };
            //read string from user input
            string input = Console.ReadLine() ?? "";
            ArgumentException.ThrowIfNullOrEmpty(input);
            Stack stack = new();
            for (int i = 0; i < input.Length; i++)
            {
                char tecken = input[i];
                switch (tecken)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(tecken);
                        break;
                    case ')':
                    case ']':
                    case '}':
                        //TODO, the stack may be enmpty, if the first charater in string is a back parenthes 
                        if (stack.Count == 0) break;
                        if (stack.Peek()!.Equals(values[tecken]))
                        {
                            //if the tecken is a last parentheis that has been added, remove it
                            stack.Pop();
                        }
                        break;
                    default:
                        break;
                }

            }
            if (stack.Count == 0)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }



        static int IterativeEven(int n)
        {
            int result = 2;
            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }
            return result;
        }

        static int RecursiveEven(int n)
        {
            if (n == 1)
            {
                return 2;
            }
            return RecursiveEven(n - 1) + 2;
        }

    }
}

