namespace RecipeBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateIgnoreChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroceryType",
                c => new
                    {
                        groceryCode = c.String(nullable: false, maxLength: 2),
                        groceryName = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.groceryCode);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ingredientID = c.Int(nullable: false, identity: true),
                        groceryCode = c.String(maxLength: 2),
                        ingredientName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ingredientID)
                .ForeignKey("dbo.GroceryType", t => t.groceryCode)
                .Index(t => t.groceryCode);
            
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        recipeID = c.Int(nullable: false),
                        ingredientID = c.Int(nullable: false),
                        amount = c.Decimal(precision: 18, scale: 2),
                        amountUnits = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => new { t.recipeID, t.ingredientID })
                .ForeignKey("dbo.Ingredients", t => t.ingredientID, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.recipeID, cascadeDelete: true)
                .Index(t => t.recipeID)
                .Index(t => t.ingredientID);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        recipeID = c.Int(nullable: false, identity: true),
                        recipeName = c.String(nullable: false, maxLength: 150),
                        recipeDescription = c.String(maxLength: 500),
                        userID = c.Int(),
                    })
                .PrimaryKey(t => t.recipeID)
                .ForeignKey("dbo.User", t => t.userID)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.RecipeMenu",
                c => new
                    {
                        recipeMenuID = c.Int(nullable: false, identity: true),
                        recipeID = c.Int(),
                        menuID = c.Int(),
                    })
                .PrimaryKey(t => t.recipeMenuID)
                .ForeignKey("dbo.MenuType", t => t.menuID)
                .ForeignKey("dbo.Recipe", t => t.recipeID)
                .Index(t => t.recipeID)
                .Index(t => t.menuID);
            
            CreateTable(
                "dbo.MenuType",
                c => new
                    {
                        menuID = c.Int(nullable: false, identity: true),
                        menuDescription = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.menuID);
            
            CreateTable(
                "dbo.RecipeNotes",
                c => new
                    {
                        recipeID = c.Int(nullable: false),
                        userID = c.Int(nullable: false),
                        noteBody = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => new { t.recipeID, t.userID })
                .ForeignKey("dbo.Recipe", t => t.recipeID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.userID, cascadeDelete: true)
                .Index(t => t.recipeID)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        screenName = c.String(nullable: false, maxLength: 25),
                        userEmail = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.userID);
            
            CreateTable(
                "dbo.RecipeReview",
                c => new
                    {
                        reviewID = c.Int(nullable: false, identity: true),
                        userID = c.Int(nullable: false),
                        recipeID = c.Int(nullable: false),
                        reviewBody = c.String(maxLength: 500),
                        rating = c.Int(),
                    })
                .PrimaryKey(t => t.reviewID)
                .ForeignKey("dbo.Recipe", t => t.recipeID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID)
                .Index(t => t.recipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredients", "recipeID", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "userID", "dbo.User");
            DropForeignKey("dbo.RecipeNotes", "userID", "dbo.User");
            DropForeignKey("dbo.RecipeReview", "userID", "dbo.User");
            DropForeignKey("dbo.RecipeReview", "recipeID", "dbo.Recipe");
            DropForeignKey("dbo.RecipeNotes", "recipeID", "dbo.Recipe");
            DropForeignKey("dbo.RecipeMenu", "recipeID", "dbo.Recipe");
            DropForeignKey("dbo.RecipeMenu", "menuID", "dbo.MenuType");
            DropForeignKey("dbo.RecipeIngredients", "ingredientID", "dbo.Ingredients");
            DropForeignKey("dbo.Ingredients", "groceryCode", "dbo.GroceryType");
            DropIndex("dbo.RecipeReview", new[] { "recipeID" });
            DropIndex("dbo.RecipeReview", new[] { "userID" });
            DropIndex("dbo.RecipeNotes", new[] { "userID" });
            DropIndex("dbo.RecipeNotes", new[] { "recipeID" });
            DropIndex("dbo.RecipeMenu", new[] { "menuID" });
            DropIndex("dbo.RecipeMenu", new[] { "recipeID" });
            DropIndex("dbo.Recipe", new[] { "userID" });
            DropIndex("dbo.RecipeIngredients", new[] { "ingredientID" });
            DropIndex("dbo.RecipeIngredients", new[] { "recipeID" });
            DropIndex("dbo.Ingredients", new[] { "groceryCode" });
            DropTable("dbo.RecipeReview");
            DropTable("dbo.User");
            DropTable("dbo.RecipeNotes");
            DropTable("dbo.MenuType");
            DropTable("dbo.RecipeMenu");
            DropTable("dbo.Recipe");
            DropTable("dbo.RecipeIngredients");
            DropTable("dbo.Ingredients");
            DropTable("dbo.GroceryType");
        }
    }
}
