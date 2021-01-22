using System.Collections.Generic;
using System.ComponentModel;

public class University : IDataErrorInfo
{
    public int UniversityId { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public string Location { get; set; }

    public List<Student> Students { get; set; }

    string IDataErrorInfo.Error
    {
        get { return null; }
    }

    private static readonly string[] ValidatedProperties = { "Name", "Specialization", "Location" };

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
        if (propertyName == "Name")
        {
            // Validate property and return a string if there is an error
            if (string.IsNullOrEmpty(Name))
                return "Name is Required";
            if (string.IsNullOrWhiteSpace(Name))
                return "Name is Required";
        }
        if (propertyName == "Specialization")
        {
            // Validate property and return a string if there is an error
            if (string.IsNullOrEmpty(Specialization))
                return "Specialization is Required";
            if (string.IsNullOrWhiteSpace(Specialization))
                return "Specialization is Required";
        }
        if (propertyName == "Location")
        {
            // Validate property and return a string if there is an error
            if (string.IsNullOrEmpty(Location))
                return "Location is Required";
            if (string.IsNullOrWhiteSpace(Location))
                return "Location is Required";
        }
        // If there's no error, null gets returned
        return null;
    }
}