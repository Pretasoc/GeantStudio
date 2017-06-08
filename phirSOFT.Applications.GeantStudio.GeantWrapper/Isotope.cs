using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phirSOFT.Applications.GeantStudio.GeantWrapper
{
    /// <summary>
    /// Represents an isotope
    /// </summary>
    public class Isotope : ISupportInitialize
    {
        //stores the atomic number
        private int z;

        //stores the number of nucleons
        private int n;

        //stores the mass of a mole.
        private double a;

        private bool initializing = false;

        /// <summary>
        /// Gets or sets the name of the isotope.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the atomic number.
        /// </summary>
        public int Z {
            get => z;
            set
            {
                if (!initializing)
                    return;

                z = value > 0 ? value 
                    : throw new ArgumentOutOfRangeException(nameof(Z), value, "The atomic number has to be greater than zero.");
            }
        }

        /// <summary>
        /// Gets or sets the number of nucleos.
        /// </summary>
        public int N
        {
            get => n;
            set
            {
                if (!initializing)
                    return;

                n = value > 0 ? value
                    : throw new ArgumentOutOfRangeException(nameof(N), value, "The number of nucleons has to be greater than zero.");
            }
        }

        /// <summary>
        /// Gets or sets the mass of a mole.
        /// </summary>
        public double Mass
        {
            get => a;
            set
            {
                if (!initializing)
                    return;

                a = value >= 0 ? value
                    : throw new ArgumentOutOfRangeException(nameof(Name), value, "The mass of a amole has to be greater than zero.");
            }
        }

        public void BeginInit()
        {
            initializing = true;
        }

        public void EndInit()
        {
            initializing = false;

            if (N < Z)
                throw new InvalidOperationException("The number of nuncleons cannot be smaller than the atomic number.");
        }
    }
}
