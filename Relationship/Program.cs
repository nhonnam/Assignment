using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var boardingHouse = new BoardingHouse();
			var room1 = new Room(101);
			var room2 = new Room(102);
			var room3 = new Room(103);
			boardingHouse.RoomList.Add(room1);
			boardingHouse.RoomList.Add(room2);
			boardingHouse.RoomList.Add(room3);
			boardingHouse.ShowRoomList();
			Console.Read();
		}
	}
}
