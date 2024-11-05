# Word Search

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
- [Tree Maze](https://neetcode.io/courses/dsa-for-beginners/22) [from NeetCode's Course(s)]
- [Matrix DFS](https://neetcode.io/courses/dsa-for-beginners/29) [from NeetCode's Course(s)]


## Problem Description
Given a 2-D grid of characters `board` and a string `word`, return `true` if the word is present in the grid, otherwise return `false`.

For the word to be present it must be possible to form it with a path in the board with horizontally or vertically neighboring cells. The same cell may not be used more than once in a word.

**Example 1:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/7c1fcf82-71c8-4750-3ddd-4ab6a666a500/public)

```java
Input: 
board = [
  ["A","B","C","D"],
  ["S","A","A","T"],
  ["A","C","A","E"]
],
word = "CAT"

Output: true
```

**Example 2:**

![](https://imagedelivery.net/CLfkmk9Wzy8_9HRyug4EVA/79721392-44b6-4de7-c571-d3d1640ac100/public)

```java
Input: 
board = [
  ["A","B","C","D"],
  ["S","A","A","T"],
  ["A","C","A","E"]
],
word = "BAT"

Output: false
```

**Constraints:**
* `1 <= board.length, board[i].length <= 5`
* `1 <= word.length <= 10`
* `board` and `word` consists of only lowercase and uppercase English letters.

<br>
<br>
<details class="hint-accordion">  
    <summary>Recommended Time & Space Complexity</summary>
    <p>
    You should aim for a solution with <code>O(m * (4^n))</code> time and <code>O(n)</code> space, where <code>m</code> is the number of cells in the given <code>board</code> and <code>n</code> is the size of the given <code>word</code>.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 1</summary>
    <p>
    As we can start at any cell on the board, we can explore all paths from that cell. Can you think of an algorithm to do so? Also, you should consider a way to avoid visiting a cell that has already been visited in the current path.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 2</summary>
    <p>
    We can use a hash set to avoid revisiting a cell in the current path by inserting the <code>(row, col)</code> of the visiting cell into the hash set and exploring all paths (four directions, as we can move to four neighboring cells) from that cell. Can you think of the base condition for this recursive path? Maybe you should consider the board boundaries, and also, we can extend a path if the character at the cell matches the character in the word.
    </p>
</details>

<br>
<details class="hint-accordion">  
    <summary>Hint 3</summary>
    <p>
    We can use backtracking, starting from each cell on the board with coordinates <code>(row, col)</code> and index <code>i</code> for the given word. We return false if <code>(row, col)</code> is out of bounds or if <code>board[row][col] != word[i]</code>. When <code>i</code> reaches the end of the word, we return true, indicating a valid path. At each step, we add <code>(row, col)</code> to a hash set to avoid revisiting cells. After exploring the four possible directions, we backtrack and remove <code>(row, col)</code> from the hash set.
    </p>
</details>

## Patterns or Tricks
<!-- This section is for any patterns or tricks noticed/spotted when solving the question which we can use as an indication of using the same approach(es) used here when facing another problems somewhat like this. -->

## My Notes


## Resources


## Video Explanation (NeetCode)
[![NeetCode's Video Explanation](https://img.youtube.com/vi/pfiQ_PS1g8E/0.jpg)](https://www.youtube.com/watch?v=pfiQ_PS1g8E)

[NeetCode's YouTube Video Explanation (link)](https://www.youtube.com/watch?v=pfiQ_PS1g8E)


## Solutions (NeetCode.io)
For all the ways to solve (and various different programming languages), refer to:
- [The problem's NeetCode.io page](https://neetcode.io/problems/search-for-word)
- [NeetCode GitHub Repository](https://github.com/neetcode-gh/leetcode)

### 1. Backtracking (Hash Set)






```csharp
public class Solution {
    private int ROWS, COLS;
    private HashSet<(int, int)> path = new HashSet<(int, int)>();

    public bool Exist(char[][] board, string word) {
        ROWS = board.Length;
        COLS = board[0].Length;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (DFS(board, word, r, c, 0)) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool DFS(char[][] board, string word, int r, int c, int i) {
        if (i == word.Length) {
            return true;
        }

        if (r < 0 || c < 0 || r >= ROWS || c >= COLS || 
            board[r][c] != word[i] || path.Contains((r, c))) {
            return false;
        }

        path.Add((r, c));
        bool res = DFS(board, word, r + 1, c, i + 1) || 
                   DFS(board, word, r - 1, c, i + 1) ||
                   DFS(board, word, r, c + 1, i + 1) || 
                   DFS(board, word, r, c - 1, i + 1);
        path.Remove((r, c));

        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * 4 ^ n)$
* Space complexity: $O(n)$

> Where $m$ is the number of cells in the $board$ and $n$ is the length of the $word$.

---

### 2. Backtracking (Visited Array)






```csharp
public class Solution {
    private int ROWS, COLS;
    private bool[,] visited;

    public bool Exist(char[][] board, string word) {
        ROWS = board.Length;
        COLS = board[0].Length;
        visited = new bool[ROWS, COLS];

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (DFS(board, word, r, c, 0)) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool DFS(char[][] board, string word, int r, int c, int i) {
        if (i == word.Length) {
            return true;
        }

        if (r < 0 || c < 0 || r >= ROWS || c >= COLS || 
            board[r][c] != word[i] || visited[r, c]) {
            return false;
        }

        visited[r, c] = true;
        bool res = DFS(board, word, r + 1, c, i + 1) || 
                   DFS(board, word, r - 1, c, i + 1) ||
                   DFS(board, word, r, c + 1, i + 1) || 
                   DFS(board, word, r, c - 1, i + 1);
        visited[r, c] = false;

        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * 4 ^ n)$
* Space complexity: $O(n)$

> Where $m$ is the number of cells in the $board$ and $n$ is the length of the $word$.

---

### 3. Backtracking (Optimal)






```csharp
public class Solution {
    private int ROWS, COLS;

    public bool Exist(char[][] board, string word) {
        ROWS = board.Length;
        COLS = board[0].Length;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (Dfs(board, word, r, c, 0)) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool Dfs(char[][] board, string word, int r, int c, int i) {
        if (i == word.Length) {
            return true;
        }
        if (r < 0 || c < 0 || r >= ROWS || c >= COLS || 
        board[r][c] != word[i] || board[r][c] == '#') {
            return false;
        }

        board[r][c] = '#';
        bool res = Dfs(board, word, r + 1, c, i + 1) ||
                   Dfs(board, word, r - 1, c, i + 1) ||
                   Dfs(board, word, r, c + 1, i + 1) ||
                   Dfs(board, word, r, c - 1, i + 1);
        board[r][c] = word[i];
        return res;
    }
}
```




#### Time & Space Complexity

* Time complexity: $O(m * 4 ^ n)$
* Space complexity: $O(n)$

> Where $m$ is the number of cells in the $board$ and $n$ is the length of the $word$.
