using System;
using System.Collections.Generic;

using Balancer.Extensions;

namespace Balancer.Model.Planets
{
    public class PlanetGenerator
    {
        private Random random = new Random();

        public PlanetGenerator(List<PlanetType> planetTypes)
        {
            this.planetTypes = planetTypes;
        }

        private List<PlanetType> planetTypes;
        public List<PlanetType> PlanetTypes
        {
            get
            {
                return this.planetTypes;
            }
        }

        public IEnumerable<Planet> Generate(Int32 planetAmount)
        {
            if (planetAmount > 0)
            {
                for (int planetCounter = 0; planetCounter < planetAmount; planetCounter++)
                {
                    var planetType = this.PlanetTypes.GetRandomEntry();

                    yield return GeneratePlanet(planetType);
                }
            }

            yield break;
        }

        public Planet GeneratePlanet(PlanetType planetType)
        {
            return new Planet()
            {
                Type = planetType,
                BaseColor = planetType.BaseColors.GetRandomEntry(),
                LandColor = planetType.LandColors.GetRandomEntry(),
                LandSprite = planetType.LandSprites.GetRandomEntry(),
                CloudColor = planetType.CloudColors.GetRandomEntry(),
                CloudSprite = planetType.CloudSprites.GetRandomEntry(),
                Resources = GenerateResources(planetType)
            };
        }

        private PlanetResources GenerateResources(PlanetType planetType)
        {
            PlanetResources generatedResources = new PlanetResources()
            {
                Oxygen = GenerateResource(planetType.Resources.Oxygen),
                Food = GenerateResource(planetType.Resources.Food),
                Fuel = GenerateResource(planetType.Resources.Fuel)
            };

            return generatedResources;
        }

        private PlanetResource GenerateResource(PlanetResource origResource)
        {
            PlanetResource generatedResource = new PlanetResource();
            generatedResource.RangeMin = origResource.RangeMin;
            generatedResource.RangeMax = origResource.RangeMax + origResource.Dispersion;

            float value = random.NextFloatRange(generatedResource.RangeMin, generatedResource.RangeMax);

            if (value < 0)
            {
                value = 0;
            }

            generatedResource.Value = value;

            generatedResource.DispersionRangeMin = value - origResource.Dispersion;

            if (generatedResource.DispersionRangeMin < 0)
            {
                generatedResource.DispersionRangeMin = 0;
            }

            generatedResource.DispersionRangeMax = value + origResource.Dispersion;

            return generatedResource;
        }
    }
}
