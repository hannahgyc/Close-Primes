/*
Hannah Chang 
closePrime.cs

Design Decisions and Function Notes:  
bool getPermDeactivated()   -   This is a getter for the programmer. Returns deactivateForever
                        (bool). Valid States: active = true (deactivateForever is false),
                        and active = false (deactivateForever is true or false).
int ping(int)   -   If the object is inactive, then return 0.
void reset()    -   Calls setActive(), re-initializes closePrime instances: count = 0,
                        deactivateForever = false. Valid states: can be active or inactive.
void revive()   -   If the state of the object is active, then the object is permanentlyDeactivated.
                        Otherwise, we call setActive(), and re-initialize closePrime instance: count = 0.     
void checkLimit()   -   if count is greater than or equal to countLimit AND the object is active,
                        then we call deactivate(). 
bool checkPrime(int)    -   Only called by ping(). Valid states: active. If value is 2, then return true.
                        If value is even (val%2 == 0), then return false. Otherwise, iterate 
                        the while((val%i)!= 0) until the value can divide itself or until the value
                        has another divisor. Return true if it is prime (i>=val), otherwise return false.
void deactivate()   -   Only called by checkLimit. Sets isActive to false. Valid States: isActive = true 
                        and isActive = false.
void permanentlyDeactivate()    -   Only called by revive() and only if isActive is true. If the object is 
                        active then call the deactivate() function and set foreverDeactivate = true. 
void setCountLimit()    -   Only called by the Constructor. Sets countLimit equal to a random number
                        generated by calling randomNum(). This only occurs to active objects. This number
                        is tied to the object and is generated through a random number multiplied by the
                        hidden number.              

*/

using System;

namespace p1
{
    public class ClosePrime
    {
        private int hiddenNum;
        private bool isActive;
        private int count;
        private int countLimit;
        private bool deactivateForever;
        public ClosePrime()
        {
            reset();
            setHiddenNum();
            setCountLimit();
        }
        public bool query()
        {
            checkLimit();
            return isActive;
        }
        public bool getPermDeactivated()
        {
            return deactivateForever;
        }
        public int ping(int pingVal)
        {   
            if (!query()) 
                return 0;
           
            count++;

            if (pingVal <= 0) // Invalid input
                return 0;
           
            int closestPrime = pingVal;
            
             for (int i = 0; i <= hiddenNum; i++)
            {   closestPrime++;
                for (int j = 0; !checkPrime(closestPrime); j++)
                {
                    closestPrime++;
                }       
            }
            return closestPrime;
        }
        public void reset()
        {
            setActive();
            count = 0;
            deactivateForever = false;
        }
        public void revive()
        {
            if (isActive)
                permanentlyDeactivate();
            else
            {
                setActive();
                count = 0;
            }
        }

        private void checkLimit()
        {
            if (count >= countLimit)
                deactivate();
        } 
        private bool checkPrime(int val) 
        {
            if (val == 2)
                return true;
                
            if (val%2 == 0)
                return false;            

            int i = 3;
            while((val % i) != 0)
            {
                i = i + 2;
            }

            if (i >= val) // IS PRIME
                return true;

            else 
                return false;
        }
        private void deactivate()
        {
            isActive = false;
        }
        private void permanentlyDeactivate()
        {
            if (isActive)
                deactivate();

            deactivateForever = true;
        }
        private int randomNumber(int min, int max)
        {
            Random random = new Random(); 
            return random.Next(min, max);
        } 
        private void setActive()
        {
            isActive = true;
        }
        private void setCountLimit()
        {
            Random random = new Random();
            countLimit = (random.Next(2,11) * hiddenNum);
        }
        private void setHiddenNum()
        {
            Random random = new Random();
            hiddenNum = random.Next(1,11);
        }
    }
}