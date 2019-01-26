/*
Hannah Chang
p1.cs
WQ CPSC 3200
CREATED: 01/09/19 - REVISIONS: 01/10/19, 01/12/19, 01/13/19
Visual Studio Code: p1.cs, closeprime.cs

Program Overview: In this driver, the program iterates through the entire array.
There are two cases that we are testing and trying to show:
Case 1: Ping until the object becomes inactive, then revive or reset (revive/reset
is determined by random number generator because we are using switch statements).
Case 2: Ping once and if the object is active, then revive or reset (revive/reset
is determined by random number generator because we are using switch statements).
If the object is inactive then it goes back to the switch statement in testMyCases()
as long as the object is not permanently deactivated. Once an object is permanently 
deactivated, then the index of the array increments and a new object is introduced.

Note: Everytime Ping is called, Query is also called right after so that the user
can moniter the state and see when it is changed. The program does not end until all
 objects in the array are permanently deactivated.
*/

using System;

namespace p1
{
    class Driver
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            const int SIZE = 10;
            ClosePrime[] myPrime = new ClosePrime[SIZE];
            initialize(myPrime, SIZE);
            testMyCases(myPrime, SIZE);
        }

        static void testMyCases(ClosePrime [] myArr, int size)
        {
            Random rndNum = new Random();

            int caseNum;
            for (int i = 0; i < size && (myArr[i].query()); i++)
            {
                Console.WriteLine("I've created a new hidden number for you, let's play!");

                while(!myArr[i].getPermDeactivated())
                {
                    caseNum = rndNum.Next(1, 3);
                    switch (caseNum)
                    {
                        case 1:
                            caseOne(myArr, size, i);
                            break;
                    
                        case 2:
                            caseTwo(myArr, size, i);
                            break;
                    }    
                }
                Console.WriteLine();
            }
        }
        static void caseTwo(ClosePrime [] myArr, int size, int index)
        {
            int pingNum, caseNum;
            Random rndNum = new Random();
            
            pingNum = rndNum.Next(1,100);
            testPing(myArr, index, pingNum);
            testQuery(myArr, index);

            if (myArr[index].query())
            {
                caseNum = rndNum.Next(1,3);
                switch (caseNum)
                {
                    case 1:
                        testRevive(myArr, index);
                        testQuery(myArr, index);
                        break;
                        
                    case 2:
                        testReset(myArr, index);
                        testQuery(myArr, index);
                        break;
                }
            }
        }
        static void caseOne(ClosePrime [] myArr, int size, int index)
        {
            int pingNum;
            Random rndNum = new Random();
            while(myArr[index].query())   
            {    
                pingNum = rndNum.Next(1,100);
            
                testPing(myArr, index, pingNum);
                testQuery(myArr, index);
            }

            pingNum = rndNum.Next(1,100); 
            testPing(myArr, index, pingNum);
            testQuery(myArr, index);

            testRevive(myArr, index);
            testQuery(myArr, index);
        }
        static void testReset(ClosePrime [] myArr, int i)
        {
            Console.WriteLine("Now Resetting...");
            myArr[i].reset();
        }
        static void testRevive(ClosePrime [] myArr, int i)
        {
            Console.WriteLine("Now Reviving...");
            myArr[i].revive();
        }
        static void testQuery(ClosePrime [] myArr, int index)
        {
            Console.Write("Query results... Object is active: ");
            Console.WriteLine(myArr[index].query());
        }
        static void testPing(ClosePrime [] myArr, int index, int pingNum)
        {   
            Console.Write("Now Pinging value " + pingNum + "...");
            Console.Write(pingNum + " is X prime numbers away from ");
            Console.WriteLine(myArr[index].ping(pingNum));
        }
        static void initialize(ClosePrime [] myArr, int S)
        {
            for (int i = 0; i < S; i++)
            {
                myArr[i] = new ClosePrime();
            }      
        }       
    }
}
