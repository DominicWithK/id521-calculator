## AI log: example

## Date
**Prompt:**

**Response:**

**How I used it:**

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
## 2 Nov 2026: Project setup
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
## 2 Nov 2026: Project setup
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