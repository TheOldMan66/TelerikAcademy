using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Negative grade is not allowed.");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Negative minimal grade is not allowed.");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Maximal grade is smaller or equal to minimal grade.");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("Empty comments is not allowed.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
