using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeFromRuszGlowaPart2
{
    public partial class Form1 : Form
    {
        Location currentLocation;

        Room diningRoom;
        RoomWithDoor livingRoom, kitchen;

        Outside garden;
        OutsideWithDoor frontYard, backYard;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            currentLocation = diningRoom; // od czegos trzeba zaczac ;]
            MoveToANewLocation(currentLocation);
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {
            description.Text = currentLocation.Desciption;
        }



        private void GoThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);

        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);

        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Salon", "Antyczny dywan", "Dębowe drzwi z klamką");
            diningRoom = new Room("Jadalnia", "Kryształowy żyrandol");
            kitchen = new RoomWithDoor("Kuchnia", "Nierdzewne stalowe sztudźce", "Rozsuwne drzwi");

            backYard = new OutsideWithDoor(true, "Podworko za domem", "Rozsuwne drzwi");
            frontYard = new OutsideWithDoor(false, "Podwroko przed domem", "Dębowe drzwi z klamką");
            garden = new Outside(false, "Ogród");

            livingRoom.Exits = new Location[] { frontYard, diningRoom };
            diningRoom.Exits = new Location[] { kitchen, livingRoom };
            kitchen.Exits = new Location[] { diningRoom, backYard };
            backYard.Exits = new Location[] { kitchen, garden };
            garden.Exits = new Location[] { backYard, frontYard };
            frontYard.Exits = new Location[] { garden, livingRoom };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;

        }

        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;

            exits.Items.Clear();

            for (int i = 0; i < currentLocation.Exits.Length; i++)
                exits.Items.Add(currentLocation.Exits[i].Name);
            exits.SelectedIndex = 0;

            description.Text = currentLocation.Desciption;

            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;

        }   
    }
}
