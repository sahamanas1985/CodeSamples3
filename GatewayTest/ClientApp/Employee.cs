namespace ClientApp
{
    public class Employee
    {
        public string name { get; set; }
        public string role { get; set; }

        public Employee()
        {

        }
        public Employee(string Name, string Role)
        {
            name = Name; role = Role;
        }
    }
}
