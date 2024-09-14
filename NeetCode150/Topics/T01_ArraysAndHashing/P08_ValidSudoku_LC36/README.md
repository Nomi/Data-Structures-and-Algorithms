# Valid Sudoku

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>☆<big> | <big>**🟨 Medium**</big> | <big></big> |


---

## Table of Contents

- [Prerequisites](#prerequisites)
- [Problem Description](#problem-description)
- [Patterns or Tricks](#patterns-or-tricks)
- [My Notes](#my-notes)
- [Resources](#resources)
- [Video Explanation (NeetCode)](#video-explanation-neetcode)
- [Solutions (NeetCode.io)](#solutions-neetcodeio)
    


## Prerequisites
- [Hash Usage](https://neetcode.io/courses/dsa-for-beginners/26) [from NeetCode's Course(s)]


## Problem Description
You are given a a `9 x 9` Sudoku board `board`. A Sudoku board is valid if the following rules are followed:

1. Each row must contain the digits `1-9` without duplicates.
2. Each column must contain the digits `1-9` without duplicates.
3. Each of the nine `3 x 3` sub-boxes of the grid must contain the digits `1-9` without duplicates.

Return `true` if the Sudoku board is valid, otherwise return `false`

Note: A board does not need to be full or be solvable to be valid.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/0be40c5d-2d18-42b8-261b-13ca50de4100/public)

```java
Input: board = 
[["1","2",".",".","3",".",".",".","."],
 ["4",".",".","5",".",".",".",".","."],
 [".","9","8",".",".",".",".",".","3"],
 ["5",".",".",".","6",".",".",".","4"],
 [".",".",".","8",".","3",".",".","5"],
 ["7",".",".",".","2",".",".",".","6"],
 [".",".",".",".",".",".","2",".","."],
 [".",".",".","4","1","9",".",".","8"],
 [".",".",".",".","8",".",".","7","9"]]

Output: true
```

**Example 2:**

```java
Input: board = 
[["1","2",".",".","3",".",".",".","."],
 ["4",".",".","5",".",".",".",".","."],
 [".","9","1",".",".",".",".",".","3"],
 ["5",".",".",".","6",".",".",".","4"],
 [".",".",".","8",".","3",".",".","5"],
 ["7",".",".",".","2",".",".",".","6"],
 [".",".",".",".",".",".","2",".","."],
 [".",".",".","4","1","9",".",".","8"],
 [".",".",".",".","8",".",".","7","9"]]

Output: false
```

Explanation: There are two 1's in the top-left 3x3 sub-box.

**Constraints:**
* `board.length == 9`
* `board[i].length == 9`
* `board[i][j]` is a digit `1-9` or `'.'`.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution as good or better than <code>O(n^2)</code> time and <code>O(n^2)</code> space, where <code>n</code> is the number of rows in the square grid.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    Which data structure would you prefer to use for checking duplicates?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    You can use a hash set for every row and column to check duplicates. But how can you efficiently check for the squares?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can find the index of each square by the equation <code>(row / 3) * 3 + (col / 3)</code>. Then we use hash set for <code>O(1)</code> lookups while inserting the number into its row, column and square it belongs to. We use separate hash maps for rows, columns, and squares.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/TjFXEUCMqI8/0.jpg)](https://www.youtube.com/watch?v=TjFXEUCMqI8)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=TjFXEUCMqI8)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/valid-sudoku)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Brute Force






```csharp
public class Solution {
    public bool IsValidSudoku(char[][] board) {
        for (int row = 0; row < 9; row++) {
            HashSet<char> seen = new HashSet<char>();
            for (int i = 0; i < 9; i++) {
                if (board[row][i] == '.') continue;
                if (seen.Contains(board[row][i])) return false;
                seen.Add(board[row][i]);
            }
        }
        
        for (int col = 0; col < 9; col++) {
            HashSet<char> seen = new HashSet<char>();
            for (int i = 0; i < 9; i++) {
                if (board[i][col] == '.') continue;
                if (seen.Contains(board[i][col])) return false;
                seen.Add(board[i][col]);
            }
        }
        
        for (int square = 0; square < 9; square++) {
            HashSet<char> seen = new HashSet<char>();
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    int row = (square / 3) * 3 + i;
                    int col = (square % 3) * 3 + j;
                    if (board[row][col] == '.') continue;
                    if (seen.Contains(board[row][col])) return false;
                    seen.Add(board[row][col]);
                }
            }
        }
        
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n ^ 2)$

---

### 2. Hash Set (One Pass)






```csharp
public class Solution {
    public bool IsValidSudoku(char[][] board) {
        Dictionary<int, HashSet<char>> cols = new Dictionary<int, HashSet<char>>();
        Dictionary<int, HashSet<char>> rows = new Dictionary<int, HashSet<char>>();
        Dictionary<string, HashSet<char>> squares = new Dictionary<string, HashSet<char>>();

        for (int r = 0; r < 9; r++) {
            for (int c = 0; c < 9; c++) {
                if (board[r][c] == '.') continue;

                string squareKey = (r / 3) + "," + (c / 3);

                if ((rows.ContainsKey(r) && rows[r].Contains(board[r][c])) ||
                    (cols.ContainsKey(c) && cols[c].Contains(board[r][c])) ||
                    (squares.ContainsKey(squareKey) && squares[squareKey].Contains(board[r][c]))) {
                    return false;
                }

                if (!rows.ContainsKey(r)) rows[r] = new HashSet<char>();
                if (!cols.ContainsKey(c)) cols[c] = new HashSet<char>();
                if (!squares.ContainsKey(squareKey)) squares[squareKey] = new HashSet<char>();

                rows[r].Add(board[r][c]);
                cols[c].Add(board[r][c]);
                squares[squareKey].Add(board[r][c]);
            }
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n ^ 2)$

---

### 3. Bitmask






```csharp
public class Solution {
    public bool IsValidSudoku(char[][] board) {
        int[] rows = new int[9];
        int[] cols = new int[9];
        int[] squares = new int[9];

        for (int r = 0; r < 9; r++) {
            for (int c = 0; c < 9; c++) {
                if (board[r][c] == '.') continue;

                int val = board[r][c] - '1';

                if ((rows[r] & (1 << val)) > 0 || (cols[c] & (1 << val)) > 0 || 
                    (squares[(r / 3) * 3 + (c / 3)] & (1 << val)) > 0) {
                    return false;
                }

                rows[r] |= (1 << val);
                cols[c] |= (1 << val);
                squares[(r / 3) * 3 + (c / 3)] |= (1 << val);
            }
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n ^ 2)$
* Space complexity: $O(n)$
