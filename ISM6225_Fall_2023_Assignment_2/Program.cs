﻿/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK

Author : Hareesh Prathipati
*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1};
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                IList<IList<int>> result = new List<IList<int>>();

                long next = (long)lower; // Use long to prevent overflow

                // Iterate through the nums array to find missing ranges.

                for (int i = 0; i < nums.Length; i++)
                {
                    // Check if the current number matches the next expected number.
                    if (nums[i] == next)
                    {
                        next++;
                    }
                    // Check if the current number is greater than the next expected number.
                    else if (nums[i] > next)
                    {
                        // Check if the missing range contains a single number or a range of numbers.
                        if (next == nums[i] - 1)
                        {
                            result.Add(new List<int> { (int)next, (int)next });
                        }
                        else
                        {
                            result.Add(new List<int> { (int)next, (int)nums[i] - 1 });
                        }
                        next = (long)nums[i] + 1;
                    }
                }
                // Handle the case where there are missing ranges at the end of the range.
                if (next <= upper)
                {
                    if (next == upper)
                    {
                        result.Add(new List<int> { (int)next });
                    }
                    else
                    {
                        result.Add(new List<int> { (int)next, (int)upper });
                    }
                }

                return result;

                //return new List<IList<int>>();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                // Check for empty input
                if (string.IsNullOrEmpty(s))
                {
                    return true;
                }

                // Create a stack to store open brackets
                Stack<char> stack = new Stack<char>();

                // Define a dictionary to map closing brackets to their corresponding opening brackets
                Dictionary<char, char> bracketPairs = new Dictionary<char, char>
                         {
                            { ')', '(' },
                            { '}', '{' },
                            { ']', '[' }
                         };

                foreach (char c in s)
                {
                    // If it's an open bracket, push it onto the stack
                    if (bracketPairs.ContainsValue(c))
                    {
                        stack.Push(c);
                    }
                    // If it's a close bracket
                    else if (bracketPairs.ContainsKey(c))
                    {
                        // If the stack is empty or the top of the stack doesn't match the current closing bracket, return false
                        if (stack.Count == 0 || stack.Pop() != bracketPairs[c])
                        {
                            return false;
                        }
                    }
                    // Invalid character
                    else
                    {
                        return false;
                    }
                }

                // If the stack is empty, all brackets were closed properly
                return stack.Count == 0;
                //return s.Length == 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                if (prices == null || prices.Length < 2)
                {
                    // If there are not enough days or no price data, cannot make a profit.
                    return 0;
                }

                int minPrice = prices[0];  // Initialize the minimum price with the price on the first day.
                int maxProfit = 0;         // Initialize the maximum profit to 0.

                for (int i = 1; i < prices.Length; i++)
                {
                    // Calculate the potential profit by selling at the current price.
                    int currentProfit = prices[i] - minPrice;

                    // Update the maximum profit if the current profit is greater.
                    if (currentProfit > maxProfit)
                    {
                        maxProfit = currentProfit;
                    }

                    // Update the minimum price if a lower price is encountered.
                    if (prices[i] < minPrice)
                    {
                        minPrice = prices[i];
                    }
                }

                return maxProfit;
                //return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                if (s == null || s.Length == 0)
                {
                    return false;
                }

                // Define a dictionary to store strobogrammatic pairs.
                Dictionary<char, char> strobogrammaticPairs = new Dictionary<char, char>
                    {
                        { '0', '0' },
                        { '1', '1' },
                        { '6', '9' },
                        { '8', '8' },
                        { '9', '6' }
                    };

                int left = 0;         // Index for the leftmost digit.
                int right = s.Length - 1;  // Index for the rightmost digit.

                while (left <= right)
                {
                    char leftDigit = s[left];
                    char rightDigit = s[right];

                    // If the pair is not strobogrammatic, return false.
                    if (!strobogrammaticPairs.ContainsKey(leftDigit) || strobogrammaticPairs[leftDigit] != rightDigit)
                    {
                        return false;
                    }

                    left++;
                    right--;
                }

                return true; // All pairs are strobogrammatic.
                //return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                if (nums == null || nums.Length <= 1)
                {
                    return 0; // No good pairs can be formed with less than two elements.
                }

                // Create a dictionary to store the frequency of each number.
                Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
                int count = 0; // Initialize the count of good pairs.

                // Count the frequency of each number in the array.
                foreach (int num in nums)
                {
                    if (frequencyMap.ContainsKey(num))
                    {
                        frequencyMap[num]++;
                    }
                    else
                    {
                        frequencyMap[num] = 1; // Initialize the frequency count for a new number.
                    }
                }

                // Calculate the number of good pairs based on the frequency of each number.
                foreach (var kvp in frequencyMap)
                {
                    int frequency = kvp.Value;
                    if (frequency > 1)
                    {
                        // Calculate the number of pairs that can be formed from frequency occurrences.
                        count += (frequency * (frequency - 1)) / 2;
                    }
                }

                return count;
                //return 0;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                if (nums == null || nums.Length == 0)
                {
                    throw new ArgumentException("Input array is empty.");
                }

                // Sort the array in descending order.
                Array.Sort(nums, (a, b) => b.CompareTo(a));

                int distinctMaxCount = 1; // Count of distinct maximum numbers.
                int prevMax = nums[0];    // Initialize with the first maximum.

                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != prevMax)
                    {
                        distinctMaxCount++;
                        prevMax = nums[i];

                        // If we have found the third distinct maximum, return it.
                        if (distinctMaxCount == 3)
                        {
                            return prevMax;
                        }
                    }
                }

                // If there are fewer than three distinct maximums, return the first maximum.
                return nums[0];
                //return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                IList<string> possibleStates = new List<string>();
                int length = currentState.Length;

                // Iterate through the input string, looking for consecutive "++" substrings.
                for (int i = 0; i < length - 1; i++)
                {
                    // Check for consecutive "++" substrings.
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Create a new state by replacing "++" with "--".
                        StringBuilder nextState = new StringBuilder(currentState);
                        nextState[i] = '-';
                        nextState[i + 1] = '-';

                        // Add the new state to the list of possible states.
                        possibleStates.Add(nextState.ToString());
                    }
                }

                return possibleStates;

               // return new List<string>() { };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            try
            {
            // Write your code here and you can modify the return value according to the requirements
            // Create a StringBuilder to build the new string without vowels.
        StringBuilder result = new StringBuilder();

                foreach (char c in s)
                {
                    // Check if the character is not a vowel (not in 'aeiouAEIOU').
                    if (!"aeiouAEIOU".Contains(c))
                    {
                        result.Append(c); // Append non-vowel characters to the result.
                    }
                }

                return result.ToString(); // Convert StringBuilder to a string and return it.
                                          //return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
