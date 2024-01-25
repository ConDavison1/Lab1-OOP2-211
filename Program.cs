namespace ConsoleApp1
{
    public class Person
    {
        public int personId;
        public  string firstName;
        public  string lastName;
        public  string favoriteColour;
        public int age;
        public bool isWorking;
        //displaying persons fav colour
        public void DisplayInfo()
        {
            Console.WriteLine($"{personId}: {firstName} {lastName}'s favorite colour is {favoriteColour}");
        }
        //changing colour
        public void ChangeColour(string newColor)
        {
            favoriteColour = newColor;
        }
        //Calculating future age in 10 years
        public int FutureAge()
        {
            return age + 10;
        }
        //Formatting The Output Order
        public override string ToString()
        {
            return $"PersonId: {personId}\nFirstName: {firstName}\nLastName: {lastName}\nFavoriteColour: {favoriteColour}\nAge: {age}\nIsWorking: {isWorking}";
        }
    }

    public class Relation
    {
        //Using enum to create constants stored as a list
        public enum RelationshipType
        {
            Sister,
            Brother,
            Mother,
            Father
        }

        public RelationshipType Relationship { get; set; }
        //ShowRelationahip is displaying relationship between two persons
        public void ShowRelationship(Person person1, Person person2)
        {
            string relationshipString = GetRelationshipString();
            Console.WriteLine($"Relationship between {person1.firstName} and {person2.firstName} is: {relationshipString}");
        }
        //switch case for getting these relationships to either brotherhood or siterhood
        private string GetRelationshipString()
        {
            switch (Relationship)
            {
                case RelationshipType.Sister:
                    return "Sisterhood";
                case RelationshipType.Brother:
                    return "Brotherhood";

                default:
                    return "Unknown";
            }
        }
    }
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // Inputing Each persons information, ID Firstname Lastname Colour Age and Working or not
            Person person1 = new Person { personId = 1, firstName = "Ian", lastName = "Brooks", favoriteColour = "Red", age = 30, isWorking = true };
            Person person2 = new Person { personId = 2, firstName = "Gina", lastName = "James", favoriteColour = "Green", age = 18, isWorking = false };
            Person person3 = new Person { personId = 3, firstName = "Mike", lastName = "Briscoe", favoriteColour = "Blue", age = 45, isWorking = true };
            Person person4 = new Person { personId = 4, firstName = "Mary", lastName = "Beals", favoriteColour = "Yellow", age = 28, isWorking = true };

            // Adding person 1-4 int a list 
            List<Person> peopleList = new List<Person> { person1, person2, person3, person4 };

            // person2 = Gina
            person2.DisplayInfo();

            // person3 = Mike
            Console.WriteLine(person3.ToString());

            // Ian's fav colour = white
            person1.ChangeColour("White");
            Console.WriteLine($"1: {person1.firstName} {person1.lastName}'s favorite colour is: {person1.favoriteColour}");

            // Calculating Marys age in 10 yrs
            Console.WriteLine($"{person4.firstName} {person4.lastName}'s Age in 10 years is: {person4.FutureAge()}");
            // Create two Relation objects and show relationships
            new Relation { Relationship = Relation.RelationshipType.Sister }.ShowRelationship(person2, person4);
            new Relation { Relationship = Relation.RelationshipType.Brother }.ShowRelationship(person1, person3);


            // Calculating avg age and displaying youngest and oldest
            Console.WriteLine($"Average age is: {peopleList.Average(person => person.age)}");
            Console.WriteLine($"The youngest person is: {peopleList.OrderBy(person => person.age).First().firstName}");
            Console.WriteLine($"The oldest person is: {peopleList.OrderByDescending(person => person.age).First().firstName}");

            // Display Person's names starting with 'M'
            var startsWithM = peopleList
                .Where(person => person.firstName.StartsWith("M", StringComparison.OrdinalIgnoreCase))
                .OrderBy(person => person.favoriteColour)
                .ThenBy(person => person.firstName)
                .Select(person => person.ToString());
            //assited by AI

            Console.WriteLine($"{string.Join("\n", startsWithM)}");

            // Finding person's that blue is there favorite colour
            var FavBlue = peopleList.Find(person => person.favoriteColour == "Blue");
            if (FavBlue != null)
            {
                Console.WriteLine(FavBlue.ToString());
            }

        }
    }
}
