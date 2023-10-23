/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK

*/

using System;
using System.Text;
using System.Collections.Generic;

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
            int[] maximum_numbers = { 3, 2, 1 };
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

        /*
        FindMissingRanges function takes in a sorted integer array (nums), a lower bound (lower), and an upper bound (upper).
        It returns a list of lists representing the missing ranges within the inclusive range [lower, upper].

        The function works by iterating through the array "nums" and finding the missing ranges between "lower" and the first element of "nums," 
        and between the last element of "nums" and "upper."

        If the input array "nums" is empty, it simply adds the entire range [lower, upper] as a missing range.

        Time complexity: O(n), where n is the length of the "nums" array.
        Space complexity: O(1), as the output list "missingRanges" does not grow with the input size.
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            int n = nums.Length;
            List<IList<int>> ans = new List<IList<int>>();

            try
            {
                // If the input array is empty, the entire range from lower to upper is a missing range.
                if (n == 0)
                {
                    ans.Add(new List<int> { lower, upper });
                    return ans;
                }
                // If the first number in the array is greater than the lower bound,
                // add a missing range from lower to one less than the first element in the array.
                if (nums[0] > lower)
                {
                    ans.Add(new List<int> { lower, nums[0] - 1 });
                }
                // Iterate through the array to find missing ranges between consecutive elements.
                for (int i = 1; i < n; i++)
                {
                    if (nums[i] - nums[i - 1] > 1)
                    {
                        // If the difference between the current and previous elements is greater than 1,
                        // there is a missing range between them. Add it to the result.
                        ans.Add(new List<int> { nums[i - 1] + 1, nums[i] - 1 });
                    }
                }
                // If the last number in the array is less than the upper bound,
                // add a missing range from one more than the last element in the array to the upper bound.
                if (nums[n - 1] < upper)
                {
                    ans.Add(new List<int> { nums[n - 1] + 1, upper });
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs, print an error message.
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            // Return the list of missing ranges.
            return ans;
        }
        /* Self Reflection Q01: The code presents a robust approach for addressing the task of 
           identifying and reporting missing ranges within a given numeric interval. 
           This functionality can prove particularly valuable in various applications, such as 
           data analysis or the parsing of log data, where detecting and documenting gaps or 
           missing values is essential. */

        // Helper function to add a range to the "missingRanges" list
        private static void AddRange(IList<IList<int>> missingRanges, long start, long end)
        {
            if (start > end)
            {
                return; // No missing elements in this range
            }

            if (start == end)
            {
                missingRanges.Add(new List<int> { (int)start }); // Single missing element
            }
            else
            {
                missingRanges.Add(new List<int> { (int)start, (int)end }); // Range of missing elements
            }
        }

        // Helper function to print the missing ranges
        private static void PrintMissingRanges(IList<IList<int>> missingRanges)
        {
            foreach (var range in missingRanges)
            {
                Console.Write("[");
                Console.Write(string.Join(",", range));
                Console.Write("]");
            }
            Console.WriteLine();
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
                Stack<char> stk = new Stack<char>();

                foreach (char c in stk)
                {
                    // Check if the character is an open bracket and push it onto the stack
                    if (c == '(' || c == '[' || c == '{')
                    {
                        stk.Push(c);
                    }
                    else
                    {
                        if (stk.Count == 0)
                        {
                            return false; // Unmatched closing bracket
                        }

                        char openBracket = stk.Pop();


                        // Check if the closing bracket matches the last open bracket
                        if (c == ')' && openBracket != '(')
                        {
                            return false; // Mismatched parentheses
                        }
                        else if (c == ']' && openBracket != '[')
                        {
                            return false; // Mismatched square brackets
                        }
                        else if (c == '}' && openBracket != '{')
                        {
                            return false; // Mismatched curly braces
                        }
                    }
                }

                return stk.Count == 0; // Check if there are any unmatched open brackets left in the stk
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return false; // In case of an exception, consider it as invalid parentheses
            }
        }

        /* Self Reflection: code checks the validity of a string containing brackets (such as parentheses,
           square brackets, and curly braces) using a stack data structure to identify unmatched 
           or mismatched brackets. It effectively handles scenarios where it encounters unpaired 
           closing brackets, detects mismatched pairs, and validates correctly matched brackets. 
           While the code incorporates a try-catch approach for error handling, which is useful 
           for exceptions, it might benefit from an error-handling mechanism specifically tailored
           to this task rather than relying on exceptions. To enhance readability and maintainability,
           it could be further optimized by employing a dictionary to map opening and closing brackets.
           This code is fundamental for tasks like syntax checking, ensuring balanced expressions, and 
           finds applications in parsing and evaluating mathematical expressions, programming language 
           syntax verification, and validation of configuration files. */

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
                // Check if the input array is null or has fewer than 2 elements.
                if (prices == null || prices.Length < 2)
                {
                    // If there are not enough days to make a profit, return 0.
                    return 0;
                }

                // Initialize variables to keep track of minimum price and maximum profit.
                int mp = prices[0];
                int maxp = 0;

                // Iterate through the array, updating mp and maxp as necessary.
                for (int i = 1; i < prices.Length; i++)
                {
                    int cp = prices[i];
                    maxp = Math.Max(maxp, cp - mp);
                    mp = Math.Min(mp, cp);
                }

                // Return the maximum profit achieved.
                return maxp;
            }
            catch (Exception)
            {
                // Catch any exceptions and rethrow them.
                throw;
            }
        }
        /*Self Reflection: The code effectively calculates the highest possible profit achievable through 
           stock trading, incorporating input validation and systematic updates of variables 
           to monitor the lowest price and maximum profit. It follows coding best practices by 
           using Math.Max and Math.Min for code simplicity. However, the try-catch block designed 
           for handling exceptions appears unnecessary, as the code does not generate anticipated 
           exceptions, rendering it redundant. This code is well-structured and suitable for 
           applications in financial analysis, algorithmic trading, or any scenario requiring 
           profit maximization when working with historical or real-time price data. */
                    
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

        public static bool IsStrobogrammatic(string stk)
        {
            try
            {
                // Define a dictionary to store the valid strobogrammatic pairs
                Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                {'0', '0'},
                {'1', '1'},
                {'6', '9'},
                {'8', '8'},
                {'9', '6'}
            };
                // Initialize two pointers, one at the left end and one at the right end of the string.
                int left = 0;
                int right = stk.Length - 1;
                // Continue checking until the left pointer is less than or equal to the right pointer.
                while (left <= right)
                {
                    // Check if the characters at the left and right positions are a valid strobogrammatic pair
                    if (!pairs.ContainsKey(stk[left]) || pairs[stk[left]] != stk[right])
                    {
                        return false;
                    }

                    // Move the pointers inward
                    left++;
                    right--;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; // In case of an exception, catch and rethrow it.
            }
        }

        /* Self Reflection: The code is effective in verifying strobogrammatic strings and includes error handling
           using a try-catch block for exceptions, even though strobogrammatic checks typically 
           don't involve exceptions. The code is well-structured and is suitable for tasks 
           involving string validation, such as in software applications where checking for 
           strobogrammatic strings is necessary, such as in numerical and text displays. */

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
                // Create a dictionary to store the count of each number
                Dictionary<int, int> countMap = new Dictionary<int, int>();
                int gP = 0;

                foreach (int n in nums)
                {
                    // If the number exists in the dictionary, increment the count
                    if (countMap.ContainsKey(n))
                    {
                        gP += countMap[n]; // Increment goodPairs by the count of the same number
                        countMap[n]++; // Increment the count for the number in the dictionary
                    }
                    else
                    {
                        countMap[n] = 1; // Initialize the count for a new number in the dictionary
                    }
                }

                return gP; // Return the count of good pairs
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self Reflection: The provided solution effectively calculates the count of identical pairs within an 
           array of integers, taking into account the presence of repeated values as potential 
           pairs. It utilizes a dictionary to efficiently store and manage the count of each 
           number, making it easy to perform quick lookups and update counts. The use of clear 
           variable initialization and a well-named variable, 'goodPairs,' demonstrates adherence 
           to good programming practices. However, the inclusion of a try-catch block seems 
           redundant, as the solution is unlikely to generate expected exceptions. In summary, 
           this solution is well-structured and finds application in scenarios involving the 
           counting of duplicate elements, such as data analysis or the optimization of processes
           reliant on the identification of repeated values as pairs. */

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
        The second distinct maximum is 2 (both 2'stk are counted together since they have the same value).
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
                // Initialize three variables to keep track of the top three maximum values.
                long first = long.MinValue;
                long second = long.MinValue;
                long third = long.MinValue;

                foreach (int num in nums)
                {
                    // Compare the current number to the first, second, and third maximum values.
                    if (num > first)
                    {
                        // If the current number is greater than the first maximum, update the top three values accordingly.
                        third = second;
                        second = first;
                        first = num;
                    }
                    else if (num < first && num > second)
                    {
                        // If the current number is between the first and second maximum, update the second and third values.
                        third = second;
                        second = num;
                    }
                    else if (num < second && num > third)
                    {
                        // If the current number is between the second and third maximum, update the third value.
                        third = num;
                    }
                }

                if (third == long.MinValue)
                {
                    // If there is no third maximum, return the first maximum.
                    return (int)first;
                }
                // Return the third maximum value as an integer.
                return (int)third;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self Reflection: The provided solution effectively determines the third maximum value within an array
           of integers. It employs three variables to track the top three maximum values, adjusting 
           them as the array is traversed. The code demonstrates sound practices through well-named
           variables and logically structured conditions for comparisons. Nevertheless, the 
           inclusion of a try-catch block seems redundant since the code is improbable to generate
           anticipated exceptions. In summary, this solution is well-organized and suitable for 
           scenarios where the task involves finding the third highest value within a dataset. */

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
                // Initialize a list to store possible next states.
                List<string> pstatets = new List<string>();

                // Iterate through the current state to find valid moves.
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // Check for the presence of "++" in the current state.
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Create a new state by flipping the "++" to "--."
                        char[] newState = currentState.ToCharArray();
                        newState[i] = '-';
                        newState[i + 1] = '-';
                        pstatets.Add(new string(newState));
                    }
                }

                return pstatets; // Return the list of possible next states.
            }
            catch (Exception)
            {
                throw; // Include a catch block for exceptions, although they are not expected in this context.
            }
        }
        /* Self reflection:  The provided solution efficiently determines and creates possible next states based 
           on a given input state, primarily focused on replacing "++" with "--." The code is 
           well-organized and uses clear variable names. However, the inclusion of a try-catch 
           block seems unnecessary since it is unlikely to generate anticipated exceptions. 
           This solution is suitable for scenarios that require the identification of potential 
           moves or transitions between different states, which can be found in various contexts,
           including game development, puzzle solving, or state space exploration in search algorithms. */

        /*

        Question 8:

        Given a string stk, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: stk = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: stk = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string stk)
        {
            try
            {
                // Create a StringBuilder to build the resulting string
                StringBuilder result = new StringBuilder();

                foreach (char ch in stk)
                {
                    // Check if the character is not a vowel, and if so, append it to the result
                    if (ch != 'a' && ch != 'e' && ch != 'i' && ch != 'o' && ch != 'u')
                    {
                        result.Append(ch); // Append non-vowel characters to the result
                    }
                }

                return result.ToString(); // Append non-vowel characters to the result
            }
            catch (Exception)
            {
                throw; // Include a catch block for exceptions, although they are unlikely in this context.
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

                // Add a comma unless it' stk the last inner list
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
        /* Self reflection: This solution effectively removes vowels from a provided string by using a StringBuilder to assemble 
           the resulting string. It employs clear variable naming and a concise loop for character 
           examination, adhering to best programming practices. However, the inclusion of a try-catch 
           block appears unnecessary since the code is unlikely to encounter expected exceptions. 
           This well-structured code is well-suited for tasks involving text manipulation, specifically 
           for eliminating specific characters like vowels. It proves valuable in applications requiring 
           text processing, such as natural language processing and text transformation tasks. */
    }
}