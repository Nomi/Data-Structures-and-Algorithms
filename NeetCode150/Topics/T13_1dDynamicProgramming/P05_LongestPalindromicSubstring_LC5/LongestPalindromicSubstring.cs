using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T13_1dDynamicProgramming.P05_LongestPalindromicSubstring_LC5;

public class Solution {
    public string LongestPalindrome(string s) {
        //Read more in my DP notes (were created in `Climbing Stairs` but might move them later to a Markdown file.)
        //WATCH NEETCODE VIDEO!! (I haven't yet, but I might.)
        //Check my soln.
        //Check neetcodeio soln to see how to do it with minor changes (e.g. array instead of dict).

        return dpLongestPalindrome(s);
    }

    string dpLongestPalindrome(string s)
    {
        (int l, int r) max = (0,0); //Thought of setting to 0, 0 from neetcodeio soln.
        //Read more in my DP notes (the section for Palindromes) (notes were created in `Climbing Stairs` but might move them later to a Markdown file.)
        if(s.Length<=1)
            return s[0 .. s.Length]; //already handled by loop? (this is more efficient tho)
        // string res = new(s[0]); //new for char to string
        Dictionary<(int l, int r), bool> isPalindrome = new(); //Used dict to see if I can save space (instead of whole array), though array might have been easier to implement
        
        ///AAAHHH I HAD l>0 instead of l>=0 earlier:
        for(int i = 0; i<s.Length; i++)
        {
            //LONGEST ODD LENGTH PALINDROMIC SUBSTRING: (because we expand equally with one char at center, the windows only calculate the odd palindromes)
            int l = i;
            for(int r=l; r<s.Length && l>=0; r++, l--) //r=l(=i) because we start from the case of only 1 character
            {
                Console.WriteLine($"ODD: {s[l .. (r+1)]} : {l},{r}");

                if(s[l]!=s[r]) //Can't be a palindrome ever if the last and first of the string aren't the same.
                {
                    isPalindrome[(l,r)] = false;
                    continue;
                }                
                
                //Now, we need to check if the string between these equal characters is a palindrome (only then will the final string be a palindrome)
                //AHHH I WAS DOING l,r FOR MEMO STUFF WHICH IS DUMB!
                if(r-l+1<=3 || (isPalindrome.ContainsKey((l+1,r-1)) && isPalindrome[(l+1,r-1)]))
                {
                    //j-i<=3 == means we only have 3, 2 or 1 characters in the substring/interval.
                    //Therefore, it would be a palindrome in that case (because 1 char is always palindrome && 2 EQUAL chars are palindrome && 2 EQUAL CHARS SURROUNDING ANY CHAR IS A PALINDROME)
                    //Then, using these as basecases, then use the fact that `a{palindrome}a` (a could be any letter) is a palindrome.
                    //Since we already checked for equality above, for intervals bigger than 2, we only need to check if they have palindrome in middle.
                    isPalindrome[(l,r)] = true;
                    if((max.r-max.l+1)<(r-l+1))//+1 cuz its length though here since its on both sides we could cancel it out. Just keeping it there as a general reminder.
                        max = (l,r);
                }
            }

            //LONGEST EVEN LENGTH PALINDROMIC SUBSTRING:
            l = i;
            for(int r=l+1; r<s.Length && l>=0; r++, l--) //r=l(=i) because we start from the case of only 1 character
            {
                //!!! ONLY DIFFERENCE IS `r=l+1` instead of `r=l` 
                //(previously we had 1 char in middle all the time because we started from 1 char (so we were stuck to only calculating for odd lengths), but this time we expand from a 2char window and since we expand both sides by 1 each time, this remains even length window and as such we only cover all the even length windows with it)
                
                Console.WriteLine($"EVEN: {s[l .. (r+1)]} : {l},{r}");
                if(s[l]!=s[r])
                {
                    isPalindrome[(l,r)] = false;
                    continue;
                }                
                
                //AHHH I WAS DOING l,r FOR MEMO STUFF WHICH IS DUMB!
                if(r-l+1<=3 || (isPalindrome.ContainsKey((l+1,r-1)) && isPalindrome[(l+1,r-1)]))
                {
                    
                    isPalindrome[(l,r)] = true;
                    if((max.r-max.l+1)<(r-l+1))//+1 cuz its length though here since its on both sides we could cancel it out. Just keeping it there as a general reminder.
                        max = (l,r);
                }
                // if(l==0&&r==3) Console.WriteLine($"{r-l+1<=3} || ({isPalindrome.ContainsKey((l,r))} && {isPalindrome[(l,r)]})");
            }
        }
        Console.WriteLine(max);
        return s[max.l .. (max.r+1)];
    }
}
