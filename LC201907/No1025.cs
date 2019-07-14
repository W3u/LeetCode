/*
 1025. Divisor Game
Easy

Alice and Bob take turns playing a game, with Alice starting first.

Initially, there is a number N on the chalkboard.  On each player's turn, that player makes a move consisting of:

Choosing any x with 0 < x < N and N % x == 0.
Replacing the number N on the chalkboard with N - x.
Also, if a player cannot make a move, they lose the game.

Return True if and only if Alice wins the game, assuming both players play optimally.

 

Example 1:

Input: 2
Output: true
Explanation: Alice chooses 1, and Bob has no more moves.
Example 2:

Input: 3
Output: false
Explanation: Alice chooses 1, Bob chooses 1, and Alice has no more moves.
 

Note:

1 <= N <= 1000
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC201907
{
    class No1025
    {
        //bool[] results_Recur = new bool[1001];
        public bool DivisorGame_Recursion(int N)
        {
            if (N == 1)
                return false;

            for (int i = 1; i < N; i++)
            {
                if (N % i == 0 && DivisorGame_Recursion(N - i) == false)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DivisorGame_DP(int N)
        {
            if (N == 1)
                return false;

            bool[] results = new bool[N + 1];
            int input = 2;
            while (input <= N)
            {
                for (int i = 1; i < input; i++)
                {
                    if (input % i == 0 && results[input - i] == false)
                    {
                        results[input] = true;
                        break;
                    }
                }
                input++;
            }
            return results[N];
        }

    }
}
