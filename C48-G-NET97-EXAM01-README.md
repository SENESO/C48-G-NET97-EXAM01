# Examination System

C# console application implementing an examination system with OOP design.

## How It Works

1. Creates a `Subject` (e.g., "C# Programming")
2. Builds an exam via `Subject.CreateExam()`
3. Asks the user whether to start the exam
4. Runs the exam with a `Stopwatch` measuring elapsed time

## Class Model

- **Question** (base) → `McqQuestion`, `TrueFalseQuestion`
- **Exam** (base) → `FinalExam`, `PracticalExam`
- **Answer** — Represents a question answer
- **Subject** — Owns and creates the exam

## How to Run

```bash
dotnet run
```

## Tech Stack

- C# / .NET
- Console Application
