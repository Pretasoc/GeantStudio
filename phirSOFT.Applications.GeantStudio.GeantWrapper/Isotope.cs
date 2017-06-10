using phirSOFT.Applications.GeantStudio.GeantWrapper.Annotations;
using System;

namespace phirSOFT.Applications.GeantStudio.GeantWrapper
{
    /// <summary>
    /// Represents an isotope
    /// </summary>
    [PublicAPI]
    public class Isotope : SupportInitializeBase
    {
        //stores the atomic number
        private int _z;

        //stores the number of nucleons
        private int _n;

        //stores the mass of a mole.
        private double _a;

        /// <summary>
        /// Gets or sets the name of the isotope.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the atomic number.
        /// </summary>
        public int Z {
            get => _z;
            set => Set(ref _z, value,
                  z => z > 0
                    ? true
                    : throw new ArgumentOutOfRangeException(nameof(Z), z,
                        "The atomic number has to be greater than zero."));

        }

        /// <summary>
        /// Gets or sets the number of nucleos.
        /// </summary>
        public int N
        {
            get => _n;
            set => Set(ref _n, value,
                z => z > 0
                    ? true
                    : throw new ArgumentOutOfRangeException(nameof(Z), z,
                        "The number of nucleons has to be greater than zero."));        
        }

        /// <summary>
        /// Gets or sets the mass of a mole.
        /// </summary>
        public double Mass
        {
            get => _a;
            set => Set(ref _a, value,
                z => z > 0
                    ? true
                    : throw new ArgumentOutOfRangeException(nameof(Z), z,
                        "The mass of a amole has to be greater than zero."));
        }
    }
}
