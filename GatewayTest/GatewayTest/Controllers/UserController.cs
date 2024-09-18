using Microsoft.AspNetCore.Mvc;


namespace GatewayTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<Employee> Users = new List<Employee>();

        public UserController()
        {
            if(Users.Count == 0)
            {
                Users.Add(new Employee("Dilbert", "Engineer"));
                Users.Add(new Employee("Wally", "Manager"));
                Users.Add(new Employee("Alice", "Engineer"));
                Users.Add(new Employee("Asok", "Intern"));
            }                        
        }


        //[HttpGet("GetAllEmployees")]
        [HttpGet]
        public List<Employee> Get()
        {
            return Users;
        }

      
       // [HttpGet("GetEmployeeByName/{name}")]
        [HttpGet("{name}")]
        public Employee Get(string name)
        {
            var user = Users.Where(i => i.name.ToLower() == name.ToLower());

            if (user.Any()) return user.First();
            else return null;

        }

        [HttpPost("AddNewEmployee")]
        public string Post(Employee emp)
        {
            Users.Add(emp);
            return ("User added successfully!");
        }

        
    }


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
