using System;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class ObjectWithName
    {
        public string Name { get; set; }

        public ObjectWithName(string name)
        {
            Name = name;
        }
    }

    public interface IBook
    {
        string Name { get; set; }
        event GradeAddedDelegate GradeAdded;
        void AddGrade(double grade);
        Statistics GetStatistics();
    }

    public abstract class Book : ObjectWithName, IBook
    {
        public Book(string name) : base(name) { }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
}