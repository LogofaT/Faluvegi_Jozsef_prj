using System.ComponentModel;

public class Grade : IDataErrorInfo
{
    public int GradeId { get; set; }
    public int StudentId { get; set; }
    public string CourseName { get; set; }
    public double FinalResult { get; set; }
    public bool Passed { get; set; }

    public Student Student { get; set; }

    string IDataErrorInfo.Error
    {
        get { return null; }
    }

    private static readonly string[] ValidatedProperties = { "StudentId", "CourseName", "FinalResult" };

    public bool IsValid
    {
        get
        {
            foreach (string property in ValidatedProperties)
            {
                if (GetValidationError(property) != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public string this[string propertyName]
    {
        get { return GetValidationError(propertyName); }
    }

    private string GetValidationError(string propertyName)
    {
        if (propertyName == "CourseName")
        {
            // Validate property and return a string if there is an error
            if (string.IsNullOrEmpty(CourseName))
                return "CourseName is Required";
            if (string.IsNullOrWhiteSpace(CourseName))
                return "CourseName is Required";
        }

        if (propertyName == "StudentId")
        {
            // Validate property and return a string if there is an error
            if (StudentId == 0)
                return "Student is Required";
        }
        
        if (propertyName == "FinalResult")
        {
            // Validate property and return a string if there is an error
            if (FinalResult < 1.00 || FinalResult > 10.00)
                return "FinalResult is Required and must be between 1.00 and 10.00";
        }
        // If there's no error, null gets returned
        return null;
    }
}