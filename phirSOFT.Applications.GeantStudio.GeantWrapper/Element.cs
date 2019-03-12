using phirSOFT.Applications.GeantStudio.GeantWrapper.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Nito.ConnectedProperties;

namespace phirSOFT.Applications.GeantStudio.GeantWrapper
{
    [ContentProperty("Isotopes")]
    [PublicAPI]
    public class Element : SupportInitializeBase
    {
        private double _effectiveA;
        private double _effectiveZ;
        private const string RelativeAbundanceKey = "RelativeAbundance";

        public Element()
        {
        
        }

        public string Label { get; set; }

        public string Symbol { get; set; }

        public double EffectiveZ
        {
            get => _effectiveZ;
            set => Set(ref _effectiveZ, value);
        }

        public double EffectiveA
        {
            get => _effectiveA;
            set => Set(ref _effectiveA, value);
        }

        public List<Isotope> Isotopes { get; } = new List<Isotope>();


        public static double GetRelativeAbundance(Isotope target)
        {
            try
            {
                return ConnectedProperty.Get(target, RelativeAbundanceKey);
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void SetRelativeAbundance(Isotope target, double value)
        {
            ConnectedProperty.Set(target, RelativeAbundanceKey, value);
        }
    }
}
