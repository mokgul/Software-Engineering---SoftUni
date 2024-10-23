namespace P01_HospitalDatabase.Data.Common;

public static class ValidationConstants
{
    //Patient
    public const int MaxLengthFirstName = 50;
    public const int MaxLengthLastName = 50;
    public const int MaxLengthAddress = 250;
    public const int MaxLengthEmail = 80;

    //Visitation
    public const int MaxLengthComments = 250;

    //Diagnose
    public const int MaxLengthDiagnoseName = 50;

    //Medicament
    public const int MaxLengthMedicamentName = 50;

    //Doctor
    public const int MaxLengthDoctorName = 100;
    public const int MaxLengthSpecialty = 100;
}