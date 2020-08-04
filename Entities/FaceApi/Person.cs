namespace Macroscop_FaceDB_Importer.Entities.FaceApi
{
    public class Person
    {
        public string first_name;
        public string patronymic;
        public string second_name;

        public Person(string first_name = "", string patronymic = "", string second_name = "")
        {
            this.first_name = first_name;
            this.patronymic = patronymic;
            this.second_name = second_name;
        }
    }
}
