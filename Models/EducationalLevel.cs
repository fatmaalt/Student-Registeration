using System.Text.Json.Serialization;

namespace student_registration.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EducationalLevel
    {
        PhD = 1
    , postGraduate = 2
    , Graduate = 3
    , Diploma = 4
    }
}