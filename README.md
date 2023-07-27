# O(1)-Sum-Odd-Sequence

We need to sum all odd numbers in the sequence from 0 to N.
Let's represent them as sets of numbers:
/*
                           7
                           6
               5         5 5
               4         4 4
      3      3 3       3 3 3
      2      2 2       2 2 2
1   1 1    1 1 1     1 1 1 1
*/

Now, let's combine these sets of numbers to form a square:


                     7 5 4 3
           5 4 3     5 4 3 3
    3 2    3 2 2     3 2 2 2
1   1 1    1 1 1     1 1 1 1

The number of layers in this square will be equivalent to the number of numbers in the sequence from 1 to N.
The area of the square is the product of its sides.
In this case, the area of the square will be the sum of all odd numbers from 1 to N.

For the sequence from 1 to 7, the sum of all odd numbers will be 4^2 = 16 or 1 + 3 + 5 + 7 = 16.

But what if the numbers are large? Adding each number in the sequence from 1 to 9999 is time-consuming and difficult. However, knowing the number of layers, we can calculate the sum of all odd numbers in a few operations. Each odd number differs from the previous one by exactly 2. To find the sum, we divide the odd number N by two and add one: we get the number of layers in the square. Then we find the square of this sum. In this way, we obtain the sum of all odd numbers in the sequence.
