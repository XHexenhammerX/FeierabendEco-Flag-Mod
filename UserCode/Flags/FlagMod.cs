namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;
    using Eco.Gameplay.Settlements;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;
    using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;


    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
	[RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
	[RequireComponent(typeof(PropertyAuthComponent))]
    
    public partial class COFFlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Cradle of Filth Flag"); } }
        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.ModsPostInitialize();
        }
 /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Cradle of Filth Flag")]
    [Ecopedia("Housing Objects", "Flags", subPageName: "COFFlag Item")]
    [Weight(10)]
    public partial class COFFlagItem : WorldObjectItem<COFFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A piece of plantfiber with something on it. can be used for decorating."); } }
		public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down;
        static COFFlagItem()
        {
            WorldObject.AddOccupancy<COFFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }
public partial class COFFlagRecipe : RecipeFamily
    {
        public COFFlagRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "COFFlag",  //noloc
                displayName: Localizer.DoStr("COFFlag"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("Wood", 10 ), //noloc
                    new IngredientElement(typeof(PlantFibersItem), 5), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<COFFlagItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 3; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(10, typeof(CarpentrySkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(COFFlagRecipe), start: 4, skillType: typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Hewn Bench"
            
            this.Initialize(displayText: Localizer.DoStr("COFFlag"), recipeType: typeof(COFFlagRecipe));
           

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(WorkbenchObject), recipe: this);
        }
		//nextFlag
		
		[Serialized]
		[RequireComponent(typeof(OnOffComponent))]
		[RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
		[RequireComponent(typeof(PropertyAuthComponent))]
		
		public partial class ECOFlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("ECO Flag"); } }
        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.ModsPostInitialize();
        }
 /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("ECO Flag")]
    [Ecopedia("Housing Objects", "Flags", subPageName: "ECOFlag Item")]
    [Weight(10)]
    public partial class ECOFlagItem : WorldObjectItem<ECOFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A piece of plantfiber with something on it. can be used for decorating."); } }
		public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down;
        static ECOFlagItem()
        {
            WorldObject.AddOccupancy<ECOFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }
public partial class ECOFlagRecipe : RecipeFamily
    {
        public ECOFlagRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "ECOFlag",  //noloc
                displayName: Localizer.DoStr("ECOFlag"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("Wood", 10 ), //noloc
                    new IngredientElement(typeof(PlantFibersItem), 5), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<ECOFlagItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 3; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(10, typeof(CarpentrySkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(COFFlagRecipe), start: 4, skillType: typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Hewn Bench"
            
            this.Initialize(displayText: Localizer.DoStr("ECOFlag"), recipeType: typeof(ECOFlagRecipe));
            

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(WorkbenchObject), recipe: this);
        }


        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();



        
    }
}}