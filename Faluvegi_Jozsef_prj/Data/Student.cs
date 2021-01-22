using System.Collections.Generic;
using System.ComponentModel;

public class Student : IDataErrorInfo
{

    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int UniversityId { get; set; }
    public University University { get; set; }
    public List<Grade> Grades { get; set; }

    string IDataErrorInfo.Error
    {
        get { return null; }
    }


    private static readonly string[] ValidatedProperties = { "FirstName", "LastName", "UniversityId" };

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
        if (propertyName == "FirstName")
            {
                // Validate property and return a string if there is an error
                if (string.IsNullOrEmpty(FirstName))
                    return "FirstName is Required"; 
                if (string.IsNullOrWhiteSpace(FirstName))
                    return "FirstName is Required";
            }
        if (propertyName == "LastName")
            {
                // Validate property and return a string if there is an error
                if (string.IsNullOrEmpty(LastName))
                    return "LastName is Required"; 
                if (string.IsNullOrWhiteSpace(LastName))
                    return "LastName is Required";
            }

        if (propertyName == "UniversityId")
            {
                // Validate property and return a string if there is an error
                if(UniversityId == 0)
                    return "University is Required";
            }


            // If there's no error, null gets returned
            return null;
    }
}