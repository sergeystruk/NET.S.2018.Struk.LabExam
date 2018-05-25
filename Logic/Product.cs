using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Product : IEquatable<Product>
    {
        private decimal coast;
        //Field for tests and demonstration of work
        //Simple way to generate different Ids
        private IGenerator generator = new SimpleGenerator();

        public string Name {get; private set;}
        public decimal Coast
        {
            get
            {
                return coast;
            }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        //Properties for tests and demonstration of work
        public int Id { get; private set; }
        public IGenerator Generator
        {
            get { return generator; }
            set
            {
                if(ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                generator = value;
            }
        }
        
        public Product(string name, decimal coast)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Coast = coast;
            Id = generator.Generate();
        }

        public bool Equals(Product other)
        {
            return Name.ToUpper() == other.Name.ToUpper();
        }
    }
}
