# ⭐ | N Queens

|   | Difficulty | Tricky |
|---|------------|--------|
| <big>⭐<big> | <big>**🟥 Hard**</big> | <big></big> |


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
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]


## Problem Description
The **n-queens** puzzle is the problem of placing `n` queens on an `n x n` chessboard so that no two queens can attack each other.

A **queen** in a chessboard can attack horizontally, vertically, and diagonally.

Given an integer `n`, return all distinct solutions to the **n-queens puzzle**.

Each solution contains a unique board layout where the queen pieces are placed. `'Q'` indicates a queen and `'.'` indicates an empty space.

You may return the answer in **any order**.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/cdf2b34d-7905-4388-db0b-9a120ebf4a00/public)

```java
Input: n = 4

Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
```

Explanation: There are two different solutions to the 4-queens puzzle.

**Example 2:**

```java
Input: n = 1

Output: [["Q"]]
```

**Constraints:**
* `1 <= n <= 8`

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(n!)</code> time and <code>O(n^2)</code> space, where <code>n</code> is the size of the given square board.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    A queen can move in <code>8</code> directions, and no two queens can be in the same row or column. This means we can place one queen per row or column. We iterate column-wise and try to place a queen in each column while ensuring no other queen exists in the same row, left diagonal, or left bottom diagonal. Can you think of a recursive algorithm to find all possible combinations?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use backtracking to traverse through the columns with index <code>c</code> while maintaining a board that represents the current state in the recursive path. We reach the base condition when <code>c == n</code> and we add a copy of the board to the result. How would you implement this?
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We initialize an empty board and recursively go through each column. For each column, we check each cell to see if we can place a queen there. We use a function to check if the cell is suitable by iterating along the left directions and verifying if the same row, left diagonal, or left bottom diagonal are free. If it is possible, we place the queen on the board, move along the recursive path, and then backtrack by removing the queen to continue to the next cell in the column.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/Ph95IHmRp5M/0.jpg)](https://www.youtube.com/watch?v=Ph95IHmRp5M)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=Ph95IHmRp5M)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/n-queens)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Backtracking






```csharp
public class Solution {
    public List<List<string>> SolveNQueens(int n) {
        var res = new List<List<string>>();
        var board = new char[n][];
        for (int i = 0; i < n; i++) {
            board[i] = new string('.', n).ToCharArray();
        }
        Backtrack(0, board, res);
        return res;
    }

    private void Backtrack(int r, char[][] board, List<List<string>> res) {
        if (r == board.Length) {
            var copy = new List<string>();
            foreach (var row in board) {
                copy.Add(new string(row));
            }
            res.Add(copy);
            return;
        }
        for (int c = 0; c < board.Length; c++) {
            if (IsSafe(r, c, board)) {
                board[r][c] = 'Q';
                Backtrack(r + 1, board, res);
                board[r][c] = '.';
            }
        }
    }

    private bool IsSafe(int r, int c, char[][] board) {
        for (int i = r - 1; i >= 0; i--) {
            if (board[i][c] == 'Q') return false;
        }
        for (int i = r - 1, j = c - 1; i >= 0 && j >= 0; i--, j--) {
            if (board[i][j] == 'Q') return false;
        }
        for (int i = r - 1, j = c + 1; i >= 0 && j < board.Length; i--, j++) {
            if (board[i][j] == 'Q') return false;
        }
        return true;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n!)$
* Space complexity: $O(n ^ 2)$

---

### 2. Backtracking (Hash Set)






```csharp
public class Solution {
    HashSet<int> col = new HashSet<int>();
    HashSet<int> posDiag = new HashSet<int>();
    HashSet<int> negDiag = new HashSet<int>();
    List<List<string>> res = new List<List<string>>();
    
    public List<List<string>> SolveNQueens(int n) {
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++) {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }

        Backtrack(0, n, board);
        return res;
    }

    private void Backtrack(int r, int n, char[][] board) {
        if (r == n) {
            List<string> copy = new List<string>();
            foreach (char[] row in board) {
                copy.Add(new string(row));
            }
            res.Add(copy);
            return;
        }

        for (int c = 0; c < n; c++) {
            if (col.Contains(c) || posDiag.Contains(r + c) ||
                negDiag.Contains(r - c)) {
                continue;
            }

            col.Add(c);
            posDiag.Add(r + c);
            negDiag.Add(r - c);
            board[r][c] = 'Q';

            Backtrack(r + 1, n, board);

            col.Remove(c);
            posDiag.Remove(r + c);
            negDiag.Remove(r - c);
            board[r][c] = '.';
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n!)$
* Space complexity: $O(n ^ 2)$

---

### 3. Backtracking (Visited Array)






```csharp
public class Solution {
    bool[] col, posDiag, negDiag;
    List<List<string>> res;
    char[][] board;

    public List<List<string>> SolveNQueens(int n) {
        col = new bool[n];
        posDiag = new bool[2 * n];
        negDiag = new bool[2 * n];
        res = new List<List<string>>();
        board = new char[n][];
        for (int i = 0; i < n; i++) {
            board[i] = new string('.', n).ToCharArray();
        }
        Backtrack(0, n);
        return res;
    }

    private void Backtrack(int r, int n) {
        if (r == n) {
            var copy = new List<string>();
            foreach (var row in board) {
                copy.Add(new string(row));
            }
            res.Add(copy);
            return;
        }
        for (int c = 0; c < n; c++) {
            if (col[c] || posDiag[r + c] || negDiag[r - c + n]) {
                continue;
            } 
            col[c] = true;
            posDiag[r + c] = true;
            negDiag[r - c + n] = true;
            board[r][c] = 'Q';

            Backtrack(r + 1, n);

            col[c] = false;
            posDiag[r + c] = false;
            negDiag[r - c + n] = false;
            board[r][c] = '.';
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n!)$
* Space complexity: $O(n ^ 2)$

---

### 4. Backtracking (Bit Mask)






```csharp
public class Solution {
    int col = 0, posDiag = 0, negDiag = 0;
    List<List<string>> res;
    char[][] board;

    public List<List<string>> SolveNQueens(int n) {
        res = new List<List<string>>();
        board = new char[n][];
        for (int i = 0; i < n; i++) {
            board[i] = new string('.', n).ToCharArray();
        }
        Backtrack(0, n);
        return res;
    }

    private void Backtrack(int r, int n) {
        if (r == n) {
            var copy = new List<string>();
            foreach (var row in board) {
                copy.Add(new string(row));
            }
            res.Add(copy);
            return;
        }
        for (int c = 0; c < n; c++) {
            if ((col & (1 << c)) > 0 || (posDiag & (1 << (r + c))) > 0
                 || (negDiag & (1 << (r - c + n))) > 0) {
                continue;
            }
            col ^= (1 << c);
            posDiag ^= (1 << (r + c));
            negDiag ^= (1 << (r - c + n));
            board[r][c] = 'Q';

            Backtrack(r + 1, n);

            col ^= (1 << c);
            posDiag ^= (1 << (r + c));
            negDiag ^= (1 << (r - c + n));
            board[r][c] = '.';
        }
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(n!)$
* Space complexity: $O(n ^ 2)$
