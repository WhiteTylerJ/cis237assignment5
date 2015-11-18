//Author: Tyler White
//CIS 237
//Assignment 5
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gets accesss to the collection of tables
            BeveragesTWhite beveragesTWhite = new BeveragesTWhite();

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        //Print the Entire List of Items
                        Console.WriteLine("Please wait...");
                        Console.WriteLine();
                        foreach (Beverage bev in beveragesTWhite.Beverages)
                        {
                            Console.WriteLine(bev.id + " " + bev.name + " " + bev.pack + " " + bev.price);
                        }
                        break;

                    case 2:
                        //Search for an item by id
                        string itemID = userInterface.GetSearchQuery();
                        Console.WriteLine("Please wait...");
                        try
                        {
                            Beverage bevToFind = beveragesTWhite.Beverages.Where(bev => bev.id == itemID).First();
                            Console.WriteLine();
                            Console.WriteLine(bevToFind.id + " " + bevToFind.name + " " + bevToFind.pack + " " + bevToFind.price);
                        }catch (Exception e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("***********************");
                            Console.WriteLine("ERROR: CANNOT FIND ITEM");
                            Console.WriteLine("***********************");
                        } 
                        break;

                    case 3:
                        //Update an item
                        string updateItemID = userInterface.GetUpdateQuery();
                        Console.WriteLine("Please wait...");
                        try
                        {
                            Beverage bevToFindToUpdate = beveragesTWhite.Beverages.Find(updateItemID);
                            Console.WriteLine("Updating " + bevToFindToUpdate.name);
                            Console.WriteLine();

                            Console.Write("Enter the new id: ");
                            string newID = Console.ReadLine();

                            Console.Write("Enter the new name: ");
                            string newName = Console.ReadLine();

                            Console.Write("Enter the new pack size: ");
                            string newPack = Console.ReadLine();

                            Console.Write("Enter the new price: ");
                            string newPrice = Console.ReadLine();

                            //update beverage
                            bevToFindToUpdate.id = newID;
                            bevToFindToUpdate.name = newName;
                            bevToFindToUpdate.pack = newPack;
                            bevToFindToUpdate.price = Decimal.Parse(newPrice);

                            Console.WriteLine("Updated Successfully");
                            //save changes
                            beveragesTWhite.SaveChanges();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("***********************");
                            Console.WriteLine("ERROR: CANNOT FIND ITEM");
                            Console.WriteLine("***********************");
                        }
                        break;

                    case 4:
                        //Add an new item to the list
                        string[] newInfo = userInterface.GetNewItemInformation();

                        Beverage newBev = new Beverage();
                        newBev.id = newInfo[0];
                        newBev.name = newInfo[1];
                        newBev.pack = newInfo[2];
                        newBev.price = Decimal.Parse(newInfo[3]);

                        //Add the new beverage to the table
                        //beveragesTWhite.Beverages.Add(newBev);
                        //Save changes
                        //beveragesTWhite.SaveChanges();

                        Console.WriteLine();
                        Console.Write(newBev.id + " " + newBev.name + " " + newBev.pack + " " + newBev.price);
                        Console.Write(" was added to the database.");
                        Console.WriteLine();

                        break;
                    case 5:
                        //Delete an item
                        string itemToDelete = userInterface.GetDeleteQuery();
                        Console.WriteLine("Please wait...");
                        try
                        {
                            Beverage bevToFind = beveragesTWhite.Beverages.Where(bev => bev.id == itemToDelete).First();
                            beveragesTWhite.Beverages.Remove(bevToFind);
                            Console.WriteLine("Item successfully removed.");

                            //save changes
                            beveragesTWhite.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("***********************");
                            Console.WriteLine("ERROR: CANNOT FIND ITEM");
                            Console.WriteLine("***********************");
                        }
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
