using System;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace DDemo.Data
{
    public sealed class DemoDb : DataConnection
    {
        public ITable<Person> People => GetTable<Person>();
    }

    [Table(Name="people")]
    public sealed class Person
    {
        [Column(Name = "id"), PrimaryKey, Identity]
        public int ID { get; set; }
        
        [Column(Name = "first_name")]
        public string FirstName { get; set; }
        
        [Column(Name = "last_name")]
        public string LastName { get; set; }
        
        [Column(Name = "birthdate")]
        public DateTime BirthDate { get; set; }
    }
}