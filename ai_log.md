## AI log format
**Prompt:** Prompt goes here

**Response:** Response goes here

**How I used it:** Use case goes here

## #################################################################################################################################################>
# AI Log: ID521 Calculator

## 2 Nov 2026: Project setup
**Prompt:** I'm making a mathematical calculator program. A blank interface with multiple operations such as:MatricesBinaryCryptographyGeometry And VectorsNumber TheoryIn visual studio. How should I structure my program? No code, just foundation to get started. I also want to upload it as a repo to github to work on it from multiple computers.

**Response:** For a project like this, think of it less as "one calculator" and more as a collection of mathematical tools under a common interface.

Since you're still building it, the most important decision is to keep each mathematical area isolated. That makes the project easier to expand and much easier to manage in GitHub.

High-Level Structure
Calculator Application
│
├── UI Layer
│   ├── Main Menu
│   ├── Matrices Screen
│   ├── Binary Screen
│   ├── Cryptography Screen
│   ├── Geometry & Vectors Screen
│   └── Number Theory Screen
│
├── Business Logic Layer
│   ├── Matrix Functions
│   ├── Binary Functions
│   ├── Cryptography Functions
│   ├── Geometry Functions
│   └── Number Theory Functions
│
├── Shared Utilities
│   ├── Input Validation
│   ├── Error Handling
│   ├── Mathematical Constants
│   └── File Operations
│
└── Documentation

Visual Studio Project Structure

If you're using C# (most common for Visual Studio desktop apps), a good folder layout would be:

MathCalculator/
│
├── Forms/
│   ├── MainForm
│   ├── MatrixForm
│   ├── BinaryForm
│   ├── CryptoForm
│   ├── GeometryForm
│   └── NumberTheoryForm
│
├── Modules/
│   ├── Matrix/
│   ├── Binary/
│   ├── Cryptography/
│   ├── Geometry/
│   └── NumberTheory/
│
├── Models/
│   ├── Matrix
│   ├── Vector
│   └── Point
│
├── Utilities/
│   ├── Validation
│   ├── Conversion
│   └── Helpers
│
└── Program


The key idea:

Forms = what the user sees.
Modules = the actual mathematics.
Models = data structures.
Utilities = reusable helper functions.
Designing Each Mathematical Section
1. Matrices

Possible operations:

Addition
Subtraction
Multiplication
Transpose
Determinant
Inverse
Rank
Gaussian Elimination
Eigenvalues (later)


Create one matrix class and put all matrix operations there.

2. Binary

Possible operations:

Decimal ↔ Binary
Decimal ↔ Hexadecimal
Decimal ↔ Octal
Bitwise AND
Bitwise OR
Bitwise XOR
Bit Shifts
Two's Complement


This section is fairly self-contained and easy to finish early.

3. Cryptography

Start simple.

Caesar Cipher
Vigenère Cipher
Rail Fence Cipher
Affine Cipher
Frequency Analysis


Later you could add:

RSA Demonstration
Diffie-Hellman Demonstration
Hash Functions


I'd keep modern encryption demonstrations educational rather than trying to build secure encryption software.

4. Geometry & Vectors

Split into two groups.

Geometry
Area
Perimeter
Volume
Distance Formula
Midpoint Formula
Circle Calculations
Triangle Calculations

Vectors
Magnitude
Normalization
Dot Product
Cross Product
Angle Between Vectors
Vector Projection


Create a dedicated Vector model early. You'll use it repeatedly.

5. Number Theory

This becomes one of the most interesting sections.

Prime Testing
Prime Factorization
Factors
GCD
LCM
Modular Arithmetic
Euler's Totient
Extended Euclidean Algorithm
Chinese Remainder Theorem


Many cryptography tools will end up reusing number theory functions.

Navigation Design

Instead of putting every function on one screen:

Main Menu
    ↓
Matrices
    ↓
Determinant Calculator

Main Menu
    ↓
Number Theory
    ↓
Prime Factorization


This scales much better when the project grows.

GitHub Structure

Create the repository from day one.

Example:

MathCalculator
│
├── src
├── docs
├── screenshots
├── README.md
├── LICENSE
└── .gitignore

README

Include:

Project overview
Features completed
Features planned
Screenshots
Installation instructions

Example roadmap:

✅ Matrix Addition
✅ Matrix Multiplication
✅ Binary Conversion

🚧 Determinants
🚧 Vector Projection

📅 RSA Demonstration
📅 Eigenvalue Calculator


This makes your repo look professional.

Git Workflow for Multiple Computers

Since you want to work from different machines:

Machine A
Commit changes
Push to GitHub

Machine B
Pull latest version
Continue work
Commit
Push


Always:

Pull first.
Make changes.
Commit.
Push.

That avoids most merge conflicts.

Suggested Development Order

I'd build in this order:

Main menu UI
Binary conversions
Geometry formulas
Vector operations
Number theory tools
Matrix calculations
Cryptography
Advanced features

Why?

Binary and geometry are quick wins.
Vectors introduce custom mathematical objects.
Number theory builds reusable algorithms.
Matrices are more complex.
Cryptography can then reuse number theory functions.
One Design Decision That Will Save You Months

Avoid putting mathematical calculations directly inside button click events.

Bad mindset:

Button Click
    Calculate Determinant
    Display Result


Better mindset:

Button Click
    ↓
Determinant Function
    ↓
Result Returned
    ↓
Display Result


This separation makes your code easier to test, debug, and expand when your calculator grows from 5 tools to 50+ tools.

Honestly, if you structure it as UI → Modules → Models → Utilities from the start, you'll be able to keep adding new mathematical topics for years without needing to redesign the whole application.

**How I used it:** I used this information to set it up as a repo on github. I also used this to think about how I would start my project.
## #################################################################################################################################################>
**Prompt:** Should I store them as multiple functions on the .cs file, or should I use multiple .cs files for different operations?

**Response:** For a project of this size, definitely use multiple .cs files. Putting everything into one file will become painful very quickly once you have dozens of operations.

A good rule:

One responsibility = one file
One mathematical topic = one folder

For example:

MathCalculator
│
├── Modules
│   ├── Matrix
│   │   ├── MatrixOperations.cs
│   │   └── Matrix.cs
│   │
│   ├── Binary
│   │   └── BinaryOperations.cs
│   │
│   ├── Cryptography
│   │   ├── CaesarCipher.cs
│   │   └── VigenereCipher.cs
│   │
│   ├── Geometry
│   │   ├── GeometryOperations.cs
│   │   └── Vector.cs
│   │
│   └── NumberTheory
│       └── NumberTheoryOperations.cs

Early Stage

When you're first building it, having one file per category is fine:

MatrixOperations.cs
BinaryOperations.cs
GeometryOperations.cs
NumberTheoryOperations.cs


Each file can contain all the functions related to that topic.

For example:

BinaryOperations.cs

Decimal to binary
Binary to decimal
Hex to decimal
Bitwise operations

GeometryOperations.cs

Area calculations
Volume calculations
Distance formulas
As the Project Grows

When a file starts getting huge (say 300-500+ lines), split it.

Instead of:

MatrixOperations.cs


you might end up with:

MatrixAddition.cs
MatrixMultiplication.cs
MatrixDeterminant.cs
MatrixInverse.cs


or

Matrix.cs
MatrixCalculator.cs


depending on the design.

What I Would Do for a Student Project

Start with:

Forms/
Models/
Services/

Services
│
├── MatrixService.cs
├── BinaryService.cs
├── GeometryService.cs
├── CryptographyService.cs
└── NumberTheoryService.cs


The word Service is commonly used for classes that perform calculations.

Then your UI simply calls the appropriate service.

This keeps the math separate from the buttons and text boxes.

GitHub Tip

Since you're planning to work across multiple computers:

Create the repository immediately.
Commit after each completed feature.
Use meaningful commit messages:
Added binary conversion functions
Implemented vector magnitude calculations
Created matrix class
Added determinant calculation
Fixed prime factorization bug


Avoid commits like:

Update
Stuff
Changes


Six months from now you'll thank yourself.

My recommendation: Start with one .cs file per major category (MatrixService.cs, BinaryService.cs, etc.). That's simple enough for now, but scales well when the project becomes much larger.

**How I used it:** I used this to think about how I would structure and order files in my program folder.
## #################################################################################################################################################>
**Prompt:** Can I put them all under one project with one namespace instead?

**Response:** Yes, absolutely. For a student project, I'd actually recommend one project and one namespace to start with.

For example:

MathCalculator
│
├── MainForm.cs
├── MatrixService.cs
├── BinaryService.cs
├── GeometryService.cs
├── CryptographyService.cs
└── NumberTheoryService.cs


All inside:

namespace MathCalculator


Conceptually:

MathCalculator
├── MatrixService
│    ├── Determinant()
│    ├── Inverse()
│    └── Multiply()
│
├── BinaryService
│    ├── DecimalToBinary()
│    └── BinaryToDecimal()
│
├── NumberTheoryService
│    ├── GCD()
│    ├── LCM()
│    └── IsPrime()
│
└── MainForm

Why this is a good idea

Benefits:

Simpler to set up.
Easier to navigate while learning.
No project references to manage.
Everything builds together.
GitHub repository stays clean.

For a calculator containing matrix, binary, geometry, cryptography, and number theory tools, a single Visual Studio project is more than sufficient.

When would you use multiple projects?

Only if you were building something much larger, such as:

Solution
│
├── MathCalculator.UI
├── MathCalculator.Core
├── MathCalculator.Tests
└── MathCalculator.Data


This is common in professional software but is probably overkill right now.

What I'd do if I were starting today
MathCalculator (Solution)
└── MathCalculator (Project)
     │
     ├── Forms
     ├── Models
     ├── Services
     └── Utilities


Keep a single namespace:

MathCalculator


or, if you want a little more organization:

MathCalculator.Services
MathCalculator.Models
MathCalculator.Forms


while still staying inside the same project.

This gives you room to grow without adding complexity too early. If in six months you end up with hundreds of functions, Visual Studio can easily help you split classes into additional files without needing to redesign the whole solution. For where you are now, one project, multiple .cs files, and a single namespace hierarchy is the sweet spot.

**How I used it:** I used this to help me create program files for my project folder. Using this, I created program.cs, binary.cs, cryptography.cs, geometry.cs, matrices.cs, ntheory.cs, parser.cs, program.cs, vectors.cs
## #################################################################################################################################################>
**Prompt:** Can you show me examples of how to create a parser for a mathematical calculator in C sharp?

**Response:** Absolutely. If you're making a calculator that can evaluate expressions like:

2 + 3 * 4
(5 + 2) * 10
10 / (2 + 3)


then you generally need a parser. There are several levels of complexity.

1. Simple Token Parser (Beginner)

Split the expression into tokens and process them.

Example:

string expression = "5 + 3";

string[] parts = expression.Split(' ');

double num1 = double.Parse(parts[0]);
string op = parts[1];
double num2 = double.Parse(parts[2]);

double answer = 0;

switch (op)
{
    case "+":
        answer = num1 + num2;
        break;

    case "-":
        answer = num1 - num2;
        break;

    case "*":
        answer = num1 * num2;
        break;

    case "/":
        answer = num1 / num2;
        break;
}

Console.WriteLine(answer);


✅ Easy

❌ Doesn't support:

5 + 3 * 2
(4 + 5)

2. Recursive Descent Parser

This is how many real calculators work.

Grammar:

Expression
    = Term
    + Term
    - Term

Term
    = Factor
    * Factor
    / Factor

Factor
    = Number
    ( Expression )


This naturally handles order of operations.

Example:

2 + 3 * 4


becomes:

Expression
├─ 2
└─ +
   └─ Term
      ├─ 3
      └─ *
         └─ 4


Result:

2 + (3 * 4)
= 14

Basic Recursive Descent Example
class Parser
{
    private string text;
    private int pos;

    public Parser(string text)
    {
        this.text = text.Replace(" ", "");
        pos = 0;
    }

    public double Parse()
    {
        return ParseExpression();
    }

    private double ParseExpression()
    {
        double value = ParseTerm();

        while (pos < text.Length)
        {
            if (text[pos] == '+')
            {
                pos++;
                value += ParseTerm();
            }
            else if (text[pos] == '-')
            {
                pos++;
                value -= ParseTerm();
            }
            else
            {
                break;
            }
        }

        return value;
    }

    private double ParseTerm()
    {
        double value = ParseFactor();

        while (pos < text.Length)
        {
            if (text[pos] == '*')
            {
                pos++;
                value *= ParseFactor();
            }
            else if (text[pos] == '/')
            {
                pos++;
                value /= ParseFactor();
            }
            else
            {
                break;
            }
        }

        return value;
    }

    private double ParseFactor()
    {
        if (text[pos] == '(')
        {
            pos++;

            double value = ParseExpression();

            pos++; // Skip ')'

            return value;
        }

        return ParseNumber();
    }

    private double ParseNumber()
    {
        int start = pos;

        while (pos < text.Length &&
               (char.IsDigit(text[pos]) || text[pos] == '.'))
        {
            pos++;
        }

        return double.Parse(text.Substring(start, pos - start));
    }
}


Usage:

Parser parser = new Parser("(5 + 3) * 2");

Console.WriteLine(parser.Parse());


Output:

16

3. Tokenizer + Parser (Most Professional)

Rather than reading characters directly, first convert them into tokens.

Input:

(5+3)*2


Tokenizer output:

LeftParen
Number(5)
Plus
Number(3)
RightParen
Multiply
Number(2)


Token class:

class Token
{
    public string Type;
    public string Value;

    public Token(string type, string value)
    {
        Type = type;
        Value = value;
    }
}


Then your parser works on tokens instead of raw text.

Benefits:

✅ Easier to debug

✅ Easier to add functions

sqrt(25)
sin(90)
cos(45)


✅ Easier to add variables

x + y * 2


✅ Used in compilers and interpreters

4. Build an Abstract Syntax Tree (AST)

Most advanced approach.

Expression:

5 + 3 * 4


Creates:

      +
     / \
    5   *
       / \
      3   4


Classes:

abstract class Node
{
    public abstract double Evaluate();
}

class NumberNode : Node
{
    public double Value;

    public NumberNode(double value)
    {
        Value = value;
    }

    public override double Evaluate()
    {
        return Value;
    }
}

class AddNode : Node
{
    public Node Left;
    public Node Right;

    public override double Evaluate()
    {
        return Left.Evaluate() + Right.Evaluate();
    }
}


Then:

Node tree = parser.Parse();

Console.WriteLine(tree.Evaluate());


This is how many programming language interpreters are structured.

For a school project

I'd recommend Recursive Descent Parsing. It's:

Much simpler than an AST
Handles brackets properly
Handles operator precedence properly
Looks impressive in an assignment
Doesn't require advanced data structures

A common progression is:

Tokenizer
    ↓
Recursive Descent Parser
    ↓
Result


which is very close to how real language parsers work. Since you've been working on C# console projects, building a tokenizer plus a recursive descent parser would be a great way to learn techniques that later apply to interpreters, scripting engines, and even compilers.

**How I used it:** I used this to help me set up the command parser. I also had to create solutions to allow exponents, negative numbers and ensure brackets were solved first.
## #################################################################################################################################################>
**Prompt:** How do you make lists and how to use them?

**Response:**In C#, a List<T> is like an array that can grow and shrink automatically. It's much more flexible than a normal array.

First, make sure you have:

using System.Collections.Generic;

Creating a List

A list of integers:

List<int> numbers = new List<int>();


Or with values already inside:

List<int> numbers = new List<int>()
{
    10,
    20,
    30
};


A list of strings:

List<string> names = new List<string>();

Adding Items
names.Add("Alice");
names.Add("Bob");
names.Add("Charlie");


Now the list contains:

Alice
Bob
Charlie

Accessing Items

Lists use indexes just like arrays:

Console.WriteLine(names[0]);


Output:

Alice

Console.WriteLine(names[2]);


Output:

Charlie

Changing Items
names[1] = "Bill";


The list becomes:

Alice
Bill
Charlie

Getting the Number of Items
Console.WriteLine(names.Count);


Output:

3


Notice it's Count, not Length like an array.

Looping Through a List
For Loop
for (int i = 0; i < names.Count; i++)
{
    Console.WriteLine(names[i]);
}

Foreach Loop
foreach (string name in names)
{
    Console.WriteLine(name);
}


This is often cleaner when you don't need the index.

Removing Items

Remove by value:

names.Remove("Bill");


Remove by index:

names.RemoveAt(0);

Checking if an Item Exists
if (names.Contains("Charlie"))
{
    Console.WriteLine("Found!");
}

Lists of Objects

Since you've been working with Contestant objects, this is especially useful:

List<Contestant> contestants = new List<Contestant>();


Add contestants:

contestants.Add(new Contestant("John", "Smith"));
contestants.Add(new Contestant("Jane", "Brown"));


Access them:

Console.WriteLine(contestants[0].firstname);
Console.WriteLine(contestants[0].lastname);

Converting an Array to a List

If you already have:

int[] numbers = { 1, 2, 3, 4 };


You can do:

List<int> numberList = numbers.ToList();


Requires:

using System.Linq;

When should you use a List instead of an Array?

Use an array when the size never changes:

Contestant[] contestants = new Contestant[23];


Use a List when items may be added or removed:

List<Contestant> finalists = new List<Contestant>();


For example, in your Wheel of Fortune project, a List<Contestant> would be perfect for storing finalists because you can keep adding qualifying contestants without worrying about the size beforehand:

List<Contestant> finalists = new List<Contestant>();

if (contestants[i].score > 5000)
{
    finalists.Add(contestants[i]);
}


Then later:

foreach (Contestant contestant in finalists)
{
    Console.WriteLine($"{contestant.firstname} {contestant.lastname}");
}

**How I used it:** I used this to understand lists, so that I could use them when creating my parser.
## #################################################################################################################################################>
**Prompt:** How do you make it so that if the user inputs something that would cause an error, it does something else instead of crashing the calculator?

**Response:** The easiest way is to use exception handling with try and catch.

For example:

try
{
    double answer = parser.Parse();
    Console.WriteLine(answer);
}
catch
{
    Console.WriteLine("Invalid expression.");
}


If the parser crashes because of bad input, the program won't stop. Instead, it'll print your message.

For a calculator, though, it's usually better to prevent errors before they happen.

For example, suppose the user enters:

5 + *


Your parser might reach the * and expect a number afterward.

Instead of letting it crash with an index error, you can check:

if (pos >= text.Length)
{
    throw new Exception("Expected a number.");
}


Then catch it later:

try
{
    Console.WriteLine(parser.Parse());
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}


Output:

Error: Expected a number.

Common calculator errors
Missing bracket

Input:

(5 + 3


Check:

if (pos >= text.Length || text[pos] != ')')
{
    throw new Exception("Missing closing bracket.");
}

Invalid character

Input:

5 + A


Check:

if (!char.IsDigit(text[pos]) &&
    text[pos] != '(')
{
    throw new Exception($"Unexpected character: {text[pos]}");
}

Division by zero

Input:

10 / 0


Check in ParseTerm:

double divisor = ParseFactor();

if (divisor == 0)
{
    throw new Exception("Cannot divide by zero.");
}

value /= divisor;

Empty input

Input:

Check before parsing:

string expression = Console.ReadLine();

if (string.IsNullOrWhiteSpace(expression))
{
    Console.WriteLine("Please enter an expression.");
    return;
}

A pattern that's common in calculators
while (true)
{
    Console.Write("Expression: ");
    string expression = Console.ReadLine();

    try
    {
        Parser parser = new Parser(expression);

        Console.WriteLine($"= {parser.Parse()}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


This way the calculator never crashes. If the user enters:

5 + *


or

10 / 0


or

((4 + 2)


it shows an error and immediately asks for another expression instead of terminating the program.

As you build the parser, try to throw meaningful exceptions wherever you detect bad input and have one catch block in Main that displays the error. That's how many real parsers handle syntax errors.

**How I used it:** I applied this to my parser, this makes it so that a mathematical equation that would crash C sharp code would print an error to the user rather than crashing the console.
## #################################################################################################################################################>
**Prompt:** How can I get my calculator to sort through brackets first?

**Response:** The most common approach is to repeatedly solve the innermost brackets first, replace them with their answer, then continue until no brackets remain.

For example:

2 * (3 + (4 * 5))


First solve:

(4 * 5)


Result:

20


Replace it:

2 * (3 + 20)


Now solve:

(3 + 20)


Result:

23


Replace it:

2 * 23


Finally:

46

Finding the innermost brackets

A simple way is to keep track of the last opening bracket:

int open = input.LastIndexOf('(');


Then find the matching closing bracket after it:

int close = input.IndexOf(')', open);


Example:

2*(3+(4*5))


Indexes:

01234567890
2*(3+(4*5))
      ^


LastIndexOf('(') finds the bracket before 4*5.

Get what's inside
string inside = input.Substring(open + 1,
                                close - open - 1);


Result:

4*5

Evaluate it

Suppose your calculator method is:

double result = Evaluate(inside);


Result:

20

Replace the brackets

You already asked about this line:

input = input.Substring(0, open)
      + result
      + input.Substring(close + 1);


It turns:

2*(3+(4*5))


into:

2*(3+20)

Repeat until no brackets exist
while (input.Contains("("))
{
    int open = input.LastIndexOf('(');
    int close = input.IndexOf(')', open);

    string inside =
        input.Substring(open + 1,
                       close - open - 1);

    double result = Evaluate(inside);

    input = input.Substring(0, open)
          + result
          + input.Substring(close + 1);
}


After the loop finishes:

2*(3+(4*5))


becomes:

2*23


Then you can run your normal multiplication/division/addition/subtraction parser on the remaining expression.

Error checking

You'll also want to catch invalid brackets:

if (input.Count(c => c == '(') !=
    input.Count(c => c == ')'))
{
    Console.WriteLine("Brackets do not match.");
}


Or during parsing:

if (close == -1)
{
    throw new Exception("Missing closing bracket.");
}


For a school calculator, the pattern is usually:

1. Solve brackets
2. Solve exponents
3. Solve multiplication/division
4. Solve addition/subtraction


The while (input.Contains("(")) loop handles the B in BEDMAS by ensuring every bracketed expression is evaluated before anything outside it.

**How I used it:** I used this as help to learn and create a solution to solving brackets first in my parser's calculations.
## #################################################################################################################################################>
**Prompt:** How to calculate exponents using C sharp? '^' doesn't work.

**Response:** In C#, the ^ operator is not exponentiation.

It's actually the bitwise XOR operator:

Console.WriteLine(2 ^ 3);


Output:

1


because:

2 = 0010
3 = 0011
XOR = 0001


For powers, use Math.Pow():

double result = Math.Pow(2, 3);


Output:

8


More examples:

Math.Pow(5, 2); // 25
Math.Pow(10, 3); // 1000
Math.Pow(4, 0.5); // 2


If you're writing your own calculator parser and want users to type:

2^3


you need to detect the ^ yourself and call Math.Pow().

Example:

double left = 2;
double right = 3;

double answer = Math.Pow(left, right);


A simple parser section might look like:

if (op == "^")
{
    result = Math.Pow(num1, num2);
}


or in a switch:

switch (op)
{
    case "+":
        result = num1 + num2;
        break;

    case "-":
        result = num1 - num2;
        break;

    case "*":
        result = num1 * num2;
        break;

    case "/":
        result = num1 / num2;
        break;

    case "^":
        result = Math.Pow(num1, num2);
        break;
}


For BEDMAS, you'll usually want to evaluate all ^ operators before multiplication and division, since exponents have higher precedence:

2 + 3 * 2^3


should become:

2 + 3 * 8


then:

2 + 24


then:

26


So in your calculator, a common order is:

1. Brackets ()
2. Exponents ^
3. Multiplication/Division * /
4. Addition/Subtraction + -


which sounds like exactly what you're building.

**How I used it:** I used this to help create a solution to solving exponents in my parser.
## #################################################################################################################################################>
**Prompt:** Can can I create a simple casear encryption method with C#?

**Response:** Absolutely. A Caesar cipher can be written with just a few lines of code.

Here's a beginner-friendly method:

static string CaesarEncrypt(string text, int shift)
{
    string encrypted = "";

    foreach (char letter in text)
    {
        encrypted += (char)(letter + shift);
    }

    return encrypted;
}


Usage:

string secret = CaesarEncrypt("HELLO", 3);

Console.WriteLine(secret);


Output:

KHOOR

To decrypt it

Just subtract the same shift:

static string CaesarDecrypt(string text, int shift)
{
    string decrypted = "";

    foreach (char letter in text)
    {
        decrypted += (char)(letter - shift);
    }

    return decrypted;
}


Usage:

string encrypted = CaesarEncrypt("HELLO", 3);
string decrypted = CaesarDecrypt(encrypted, 3);

Console.WriteLine(decrypted);


Output:

HELLO

One problem

The simple version above doesn't wrap around the alphabet. For example:

Z + 3 = ]


instead of becoming C.

If your assignment expects a proper Caesar cipher, use this version:

static string CaesarEncrypt(string text, int shift)
{
    string result = "";

    foreach (char c in text)
    {
        if (char.IsLetter(c))
        {
            char offset = char.IsUpper(c) ? 'A' : 'a';
            result += (char)(((c - offset + shift) % 26) + offset);
        }
        else
        {
            result += c;
        }
    }

    return result;
}


This correctly turns:

XYZ


into:

ABC


which is how a true Caesar cipher works. For a beginner C# class, this version is usually the one teachers are looking for.

**How I used it:** I used this to create methods for my caesar encryption and decryption. I found out that decryption was just a reverse in shift, so I didn't need to write a new method for decrypting.
## #################################################################################################################################################>
**Prompt:** How can I make a check for '1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25' to make sure a valid multiplier is given

**Response:** The cleanest way is to store the valid multipliers in an array and check whether the user's value exists in it.

int[] validMultipliers = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };

int a = int.Parse(Console.ReadLine());

bool valid = false;

for (int i = 0; i < validMultipliers.Length; i++)
{
    if (a == validMultipliers[i])
    {
        valid = true;
        break;
    }
}

if (!valid)
{
    Console.WriteLine("Invalid multiplier.");
}


Or, if you're allowed to use the Array class:

int[] validMultipliers = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };

if (!Array.Exists(validMultipliers, x => x == a))
{
    Console.WriteLine("Invalid multiplier.");
}

Even Better

The real rule for an Affine cipher is that a must be coprime with 26. Instead of hardcoding the list, you can check mathematically:

static int GCD(int a, int b)
{
    while (b != 0)
    {
        int temp = b;
        b = a % b;
        a = temp;
    }

    return a;
}

if (GCD(multiplier, 26) != 1)
{
    Console.WriteLine("Invalid multiplier.");
}


This automatically accepts: 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25

and rejects: 2, 4, 6, 8, 10, 12, ...

For a school assignment, I'd probably use the array version because it's easy to understand and directly shows the allowed values.

**How I used it:** I used this to help create a solution in making sure a valid multiplier is given when using affine encrypt/decrypt.
## #################################################################################################################################################>
**Prompt:** Can you show me the formula for encrypting and decrypting affine?

**Response:** Sure! The Affine Cipher uses two keys:

a = multiplier
b = shift

The letter positions are:

A=0, B=1, C=2, ..., Z=25

Encryption Formula
E(x)=(ax+b) mod 26E(x) = (ax + b) \bmod 26

Where:

xx = plaintext letter position
aa = multiplier
bb = shift
E(x)E(x) = encrypted letter position

Example with:

a = 5
b = 8
H = 7


Calculation:

(5×7+8) mod 26(5 \times 7 + 8) \bmod 26 43 mod 26=1743 \bmod 26 = 17
17 = R


So:

H → R

Decryption Formula
D(y)=a−1(y−b) mod 26D(y) = a^{-1}(y - b) \bmod 26

Where:

yy = encrypted letter position
a−1a^{-1} = modular inverse of aa

For example, if:

a = 5


then:

a⁻¹ = 21


because:

5×21≡1(mod26)5 \times 21 \equiv 1 \pmod{26}

Decrypting R:

R = 17

21×(17−8) mod 2621 \times (17 - 8) \bmod 26 21×9 mod 2621 \times 9 \bmod 26 189 mod 26=7189 \bmod 26 = 7
7 = H


So:

R → H

Corresponding C# Code

Encryption:

int encrypted = (multiplier * position + shift) % 26;


Decryption:

int decrypted = (inverse * (position - shift + 26)) % 26;


The + 26 prevents the result from becoming negative before the % 26.

Modular Inverses for Affine Cipher
a   inverse
1   1
3   9
5   21
7   15
9   3
11  19
15  7
17  23
19  11
21  5
23  17
25  25


These are exactly the multipliers you're already validating in your code.

**How I used it:** I used this to create my methods for encrypting and decrypting affine by using the formulas given.
## #################################################################################################################################################>