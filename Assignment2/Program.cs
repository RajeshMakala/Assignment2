using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Assignment_2_Summer_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 1, 3, 5 ,6};
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 5 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ma);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        //Given two integer arrays nums1 and nums2, return an array of their intersection.
        //Each element in the result must be unique and you may return the result in any order.
        //Example 1:
        //Input: nums1 = [1,2,2,1], nums2 = [2,2]
        //Output: [2]
        //Example 2:
        //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        //Output: [9,4]
        //
        /// </summary>

        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                // defining hash sets ppulate the input arrays
                HashSet<int> set1 = new HashSet<int>();
                HashSet<int> set2 = new HashSet<int>();

                // populating set1
                for (int i = 0; i < nums1.Length; i++)
                {
                    set1.Add(nums1[i]);
                }

                // populating set2
                for (int i = 0; i < nums2.Length; i++)
                {
                    set2.Add(nums2[i]);
                }

                // intersecting of set1 and set2
                set1.IntersectWith(set2);

                string output = "";

                //populating output string that looks like an array
                if (set1.Count() > 0)
                {
                    output = "[";

                    foreach (var item in set1)
                    {
                        output = output + item.ToString() + ",";
                    }

                    output = output.Remove(output.Length - 1);
                    output = output + "]"; 

                }
                Console.WriteLine(output);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
        /// <summary>
        //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
        //Note: You must write an algorithm with O(log n) runtime complexity.
        //Example 1:
        //Input: nums = [1, 3, 5, 6], target = 5
        //Output: 2
        //Example 2:
        //Input: nums = [1, 3, 5, 6], target = 2
        //Output: 1
        //Example 3:
        //Input: nums = [1, 3, 5, 6], target = 7
        //Output: 4
        //Example 4:
        //Input: nums = [1, 3, 5, 6], target = 0
        //Output: 0
        /// </summary>

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int low = 0;
                int high = nums.Length - 1;
                while (low <= high)
                {
                    int mid = low + (high - low) / 2;
                    if (nums[mid] == target)
                        return mid;
                    else if (nums[mid] > target)
                    {
                        high = mid - 1;
                    }
                    else if (nums[mid] < target)
                    {
                        low = mid + 1;
                    }
                }
                return low;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question 3
        /// <summary>
        //Given an array of integers arr, a lucky integer is an integer which has a frequency in the array equal to its value.
        //Return a lucky integer in the array. If there are multiple lucky integers return the largest of them. If there is no lucky integer return -1.
        //Example 1:
        //Input: arr = [2, 2, 3, 4]
        //Output: 2
        //Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        /// </summary>

        private static int LuckyNumber(int[] nums)
        {
            try
            {
                //defining a dictionary to populate the array values as Key and no of repetetions as value.
                Dictionary<int, int> d = new Dictionary<int, int>();

                //populating the dictionary with integer value as Key and number of repetetions as value.
                foreach (int num in nums)
                {
                    if (!d.ContainsKey(num))
                    {
                        d.Add(num, 1);
                    }
                    else
                    {
                        d[num] += 1;
                    }
                }


                int largest = -1;

                //loping through dictionary for finding largest value at which Key = value.
                foreach (KeyValuePair<int, int> kvp in d)
                {
                    if (kvp.Value == kvp.Key && kvp.Value > largest)
                    {
                        largest = kvp.Value;
                    }
                }


                return largest;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        //You are given an integer n.An array nums of length n + 1 is generated in the following way:
        //•	nums[0] = 0
        //•	nums[1] = 1
        //•	nums[2 * i] = nums[i]  when 2 <= 2 * i <= n
        //•	nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
        // Return the maximum integer in the array nums.

        //Example 1:
        //Input: n = 7
        //Output: 3
        //Explanation: According to the given rules:
        //nums[0] = 0
        //nums[1] = 1
        //nums[(1 * 2) = 2] = nums[1] = 1
        //nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
        //nums[(2 * 2) = 4] = nums[2] = 1
        //nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
        //nums[(3 * 2) = 6] = nums[3] = 2
        //nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
        //Hence, nums = [0, 1, 1, 2, 1, 3, 2, 3], and the maximum is 3.

        /// </summary>
        private static int GenerateNums(int n)
        {
            try
            {
                //if the input value is less than or equall to zero, method return zero as max integer.
                if (n <= 0)
                {
                    return 0;
                }
                    
                //Initiating an array with length  = (n+1) 
                var num = new int[n + 1];

                //As provided, defining num[0] and num[1] values.
                num[0] = 0;
                num[1] = 1;
                var max = 1;

                //interating through for loop to create values to input into array.
                for (var i = 2; i < n + 1; i++)
                {
                    // if the index position is even
                    if (i % 2 == 0)
                        num[2 * (i / 2)] = num[i / 2];
                    // if the index position is odd
                    else
                        num[(2 * (i / 2)) + 1] = num[i / 2] + num[i / 2 + 1];

                    //updating the max values after calculating every new value in the array
                    max = Math.Max(max, num[i]);
                }

                return max;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 5
        /// <summary>
        //You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi.Return the destination city, that is, the city without any path outgoing to another city.
        //It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        //Example 1:
        //Input: paths = [["London", "New York"], ["New York","Lima"], ["Lima","Sao Paulo"]]
        //Output: "Sao Paulo" 
        //Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city.Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".
        /// </summary>
        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                //defining list to add all destination cities 
                List<string> list = new List<string>();

                //for each path, adding the destinations cities into list.
                foreach (var element in paths)
                {
                    list.Add(element[1]);
                }

                //looping through all the paths and removing the cities that are listed as both origins and distinations.
                foreach (var path in paths)
                {
                    if (list.Contains(path[0]))
                    {
                        list.Remove(path[0]);
                    }
                }

                //returning the last item from list from will result the final destination.
                return (list.Last());

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 6:
        /// <summary>
        //Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        //Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.Length.
        //You may not use the same element twice, there will be only one solution for a given array
        //Example 1:
        //Input: numbers = [2,7,11,15], target = 9
        //Output: [1,2]
        //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        /// </summary>
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                //defining left and right indexes to navigate through input array.
                int left = 0;
                int right = nums.Length - 1;

                // Checking if constraints are satisfied on the input data
                if (nums.Length >= 2 && nums.Length <= 3 * 104)
                {
                    while (left < right)
                    {
                        //checking additional constraints on the input data
                        if (nums[left] >= -1000 && nums[left] <= 1000 && nums[right] >= -1000 && nums[right] <= 1000)
                        {
                            //if the sum is less than target, left index will be incremented
                            if ((nums[left] + nums[right]) < target)
                                left++;
                            //if target value is higher than the sum of values, index of right value is decremented.
                            else if ((nums[left] + nums[right]) > target)
                                right--;
                            //if sum of integers is equall to target, breaking the loop
                            else if ((nums[left] + nums[right]) == target)
                                break;
                        }
                        else
                            throw new Exception();
                    }

                    //printing the output
                    Console.WriteLine("{0},{1}", left + 1, right + 1);
                    Console.ReadLine();
                }
                else
                    throw new Exception();


            }
            catch (Exception)
            {
                //exception is triggered in case of constraint voilations on input data
                Console.WriteLine(" Input Constraint violated:Exception occurred in targetSum function\n");

                //throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {
                List<int[]> list = new List<int[]>();
                List<int[,]> result = new List<int[,]>();
                for (int i = 0; i < items.GetLength(0); i++)
                {
                    //adding the elements to list
                    list.Add(new int[] { items[i, 0], items[i, 1] });
                }
                //sorting the elements
                list.Sort((p, q) => { return (p[0] < q[0]) ? -1 : ((p[0] == q[0]) ? ((p[1] <= q[1]) ? 1 : -1) : 1); });
                int a = list[0][0];
                int count = 1;
                int sum = list[0][1];
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i][0] == a && count < 5)
                    {
                        sum += list[i][1];
                        count += 1;
                    }
                    else if (list[i][0] != a)
                    {

                        result.Add(new int[,] { { a, sum / 5 } });
                        Console.Write("[[" + a + "," + sum / 5 + "]" + ",");
                        a = list[i][0];
                        count = 1;
                        sum = list[i][1];
                    }
                }
                result.Add(new int[,] { { a, sum / 5 } });
                Console.Write("[" + a + "," + sum / 5 + "]]");
                Console.Write("\n");

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        //Given an array, rotate the array to the right by k steps, where k is non-negative.
        //Print the Final array after rotation.
        //Example 1:
        //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
        //Output: [5,6,7,1,2,3,4]
        //Explanation:
        //rotate 1 steps to the right: [7,1,2,3,4,5,6]
        //rotate 2 steps to the right: [6,7,1,2,3,4,5]
        //rotate 3 steps to the right: [5,6,7,1,2,3,4]
        //Example 2:
        //Input: nums = [-1,-100,3,99], k = 2
        //Output: [3,99,-1,-100]
        //Explanation: 
        //rotate 1 steps to the right: [99,-1,-100,3]
        //rotate 2 steps to the right: [3,99,-1,-100]
        /// </summary>

        private static void RotateArray(int[] arr, int n)
        {
            try
            {
                var loopindex = 0;
                var currentindex = 0;
                var current = arr[currentindex];
                //checking constraints
                if (arr.Length >= 1 && arr.Length <= 105 && n >= 0 && n <= 105)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        //checking constraints
                        if (arr[i] >= -231 && arr[i] <= 230)
                        {
                            currentindex = (currentindex + n) % arr.Length;

                            // replacing current index with next index using temp variable
                            var temp = arr[currentindex];
                            arr[currentindex] = current;
                            current = temp;

                            if (currentindex == loopindex)
                            {
                                currentindex = (++loopindex) % arr.Length;
                                current = arr[currentindex];
                            }
                        }
                        else
                            throw new Exception();
                    }
                    Console.WriteLine(String.Join(",", arr));

                }
                else
                    throw new Exception();


            }
            catch (Exception)
            {

                Console.WriteLine("Constraints violated:Exception occurred in RotateArray function\n");
                //throw;

            }
        }

        //Question 9
        /// <summary>
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum
        //Example 1:
        //Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        //Example 2:
        //Input: nums = [1]
        //Output: 1
        // Example 3:
        // Input: nums = [5,4,-1,7,8]
        //Output: 23
        /// </summary>

        private static int MaximumSum(int[] arr)
        {
            try
            {
                if (arr == null || arr.Length == 0)
                    return 0;

                var minPrefixSum = 0;
                var length = arr.Length;
                var largestSum = Int32.MinValue;
                var prefixSum = 0;
                var foundOne = false;

                for (int i = 0; i < length; i++)
                {
                    var current = arr[i];
                    prefixSum += current;

                    var diff = prefixSum - minPrefixSum;
                    if (diff > largestSum)
                    {
                        largestSum = diff;
                    }

                    if (prefixSum < minPrefixSum)
                    {
                        minPrefixSum = prefixSum;
                    }
                }

                return Convert.ToInt32(largestSum);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        //You are given an integer array cost where cost[i] is the cost of ith step on a staircase.Once you pay the cost, you can either climb one or two steps.
        //You can either start from the step with index 0, or the step with index 1.
        //Return the minimum cost to reach the top of the floor.
        //Example 1:
        //Input: cost = [10, 15, 20]
        //Output: 15
        //Explanation: Cheapest is: start on cost[1], pay that cost, and go to the top.

        /// </summary>

        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                int n = costs.Length;
                if (n == 0)
                    return 0;
                else if (n == 1)
                    return costs[0];
                else if (n <= 1000)
                {
                    for (int i = 2; i < n; i++)
                    {
                        //handling constraints
                        if (costs[i] >= 0 && costs[i] <= 999)
                            //calculating the minimum cost
                            costs[i] = Math.Min(costs[i - 1], costs[i - 2]) + costs[i];
                        else
                            throw new Exception();
                    }
                    return Math.Min(costs[n - 2], costs[n - 1]);
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Constraints violated:Exception occurred in MinCostToClimb function\n");
                return 0;
                throw;
            }
        }
    }
}